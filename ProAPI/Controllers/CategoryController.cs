using ApiPelicula.Models.DTOs.CategoryDto;
using ApiPelicula.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RestAPI.Models.Entity;
using System.Diagnostics;

namespace ApiPelicula.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        private readonly ILogger<CategoryController> _logger;
        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper, ILogger<CategoryController> logger)
        {

            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var categories = _mapper.Map<List<CategoryDto>>(await _categoryRepository.GetCategoriesAsync());
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [AllowAnonymous]
        [HttpGet("{categoryId:int}", Name = "GetCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCategory(int categoryId)
        {
            try
            {
                var category = await _categoryRepository.GetCategoryAsync(categoryId);

                if (category == null)
                {
                    return NotFound(new { error = $"Category with ID {categoryId} not found." });
                }

                return Ok(_mapper.Map<CategoryDto>(category));
            }
            catch (Exception ex)
            {
                // Log the exception
                // Return a 500 Internal Server Error response
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto category)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { error = "Incorrect Input", message = ModelState });
                }

                if (category == null)
                {
                    return BadRequest(new { error = "Category not sent", message = ModelState });
                }

                if (await _categoryRepository.CategoryExistsAsync(category.Name))
                {
                    ModelState.AddModelError("", "Category Already Exists");
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }

                var newCategory = _mapper.Map<Category>(category);
                newCategory.CreatedDate = DateTime.Now;
                var createResult = await _categoryRepository.CreateCategoryAsync(newCategory);

                if (!createResult)
                {
                    ModelState.AddModelError("", $"Something went wrong saving {category.Name}");
                    return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
                }

                // Construct redirect URL manually
                var redirectUrl = Url.Action("GetCategory", new { categoryId = newCategory.Id });
                return Created(redirectUrl, newCategory);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }



        }

        [Authorize(Roles = "admin")]
        [HttpPatch("{categoryId:int}", Name = "UpdateCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCategory(int categoryId, [FromBody] CategoryDto categoryDto)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (categoryDto?.Id == null)
                {
                    return NotFound(new { error = $"Category with ID {categoryId} not found." });
                }

                var category = _mapper.Map<Category>(categoryDto);
                if (!await _categoryRepository.UpdateCategoryAsync(category))
                {
                    ModelState.AddModelError("", "An error occured trying to update category");
                    return BadRequest(ModelState);
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{categoryId:int}", Name = "DeleteCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            try
            {
                if (categoryId == 0)
                {
                    ModelState.AddModelError("", "Category Id is null or empty, please provide 1");
                    return BadRequest(ModelState);

                }
                if (!await _categoryRepository.CategoryExistsAsync(categoryId))
                {
                    return NotFound(new { error = $"Category with ID {categoryId} not found." });
                }

                if (!await _categoryRepository.DeleteCategoryAsync(categoryId))
                {
                    StatusCode(StatusCodes.Status500InternalServerError, $"Category with ID {categoryId} could not be deleted.");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
