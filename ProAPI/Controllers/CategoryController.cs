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
        public CategoryController(ICategoryRepository categoryRepository, 
            IMapper mapper, ILogger<CategoryController> logger)
            : base(categoryRepository, mapper, logger)
        {

        }

        [AllowAnonymous]
        [HttpGet(Name = "lol")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLol()
        {
            try
            {
                var entities = _mapper.Map<List<CategoryDto>>(await _repository.GetAllAsync());
                return Ok(entities);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching data");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
