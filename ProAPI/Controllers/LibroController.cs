
using ApiPelicula.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RestAPI.Controllers.RestAPI.Controllers;
using RestAPI.Models.DTOs.LibroDTO;
using RestAPI.Models.Entity;
using System.Diagnostics;

namespace ApiPelicula.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : BaseController<LibroEntity, LibroDTO, CreateLibroDTO>
    {
        public LibroController(ILibroRepository LibroRepository,
            IMapper mapper, ILogger<LibroController> logger)
            : base(LibroRepository, mapper, logger)
        {

        }
    }
}
