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
    public class SovietTankController : BaseController<SovietTankEntity, SovietTankDTO, CreateSovietTankDTO>
    {
        public SovietTankController(ISovietTanksRepository sovietTanksRepository,
            IMapper mapper, ILogger<SovietTankController> logger)
            : base(sovietTanksRepository, mapper, logger)
        {

        }
    }
}
