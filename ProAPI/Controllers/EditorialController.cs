using ApiPelicula.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Controllers.RestAPI.Controllers;
using RestAPI.Models.DTOs;
using RestAPI.Models.DTOs.LibroDTO;
using RestAPI.Models.Entity;
using RestAPI.Repository.IRepository;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialController : BaseController<EditorialEntity, EditorialDTO, CreateEditorialDTO>
    {
        public EditorialController(IEditorialRepository repository,
            IMapper mapper, ILogger<EditorialController> logger)
            : base(repository, mapper, logger)
        {

        }
    }
}
