﻿using BicTechBack.src.Core.Entities;
using BicTechBack.src.Core.Interfaces;
using BicTechBack.src.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BicTechBack.src.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;

        public AuthRepository(AppDbContext context)
        {
           _context = context;
        }

        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _context.Usuarios
                .Include(u => u.Carritos)
                .Include(u => u.Pedidos)
                .FirstOrDefaultAsync(u => u.Email == email);



        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Usuarios
                .Include(u => u.Carritos)
                .Include(u => u.Pedidos)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> UpdatePasswordAsync(int id, string newPassword)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return false;
            }
            else
            {
                usuario.Password = newPassword;
                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
