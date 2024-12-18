﻿using ApiPelicula.Models.DTOs.CategoryDto;
using ApiPelicula.Models.DTOs.UserDto;
using AutoMapper;
using RestAPI.Models.DTOs.LibroDTO;
using RestAPI.Models.Entity;

namespace ApiPelicula.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<LibroEntity, LibroDTO>().ReverseMap();
            CreateMap<LibroEntity, CreateLibroDTO>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
