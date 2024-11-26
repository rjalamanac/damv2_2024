using ApiPelicula.Models.DTOs.CategoryDto;
using ApiPelicula.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RestAPI.Controllers.RestAPI.Controllers;
using RestAPI.Models.Entity;
using System.Diagnostics;

namespace ApiPelicula.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController<Category, CategoryDto, CreateCategoryDto>
    {
        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper, ILogger<CategoryController> logger)
            : base(categoryRepository, mapper, logger)
        {

        }
    }
}
