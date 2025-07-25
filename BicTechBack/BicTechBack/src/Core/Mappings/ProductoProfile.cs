﻿using AutoMapper;
using BicTechBack.src.Core.DTOs;
using BicTechBack.src.Core.Entities;
namespace BicTechBack.src.Core.Mappings
{
    public class ProductoProfile : Profile
    {
        public ProductoProfile()
        {
            CreateMap<CrearProductoDTO, Producto>();

            CreateMap<Producto, ProductoDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Precio, opt => opt.MapFrom(src => src.Precio))
                .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
                .ForMember(dest => dest.CategoriaNombre, opt => opt.MapFrom(src => src.Categoria != null ? src.Categoria.Nombre : null))
                .ForMember(dest => dest.MarcaNombre, opt => opt.MapFrom(src => src.Marca != null ? src.Marca.Nombre : null))
                .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.Stock));
        }
    }
}
