
using RestAPI.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RestAPI.Controllers.RestAPI.Controllers;
using RestAPI.Models.DTOs;
using RestAPI.Models.Entity;
using System.Diagnostics;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : BaseController<HouseEntity, HouseDTO, CreateHouseDTO>
    {
        public HouseController(IHouseRepository HouseRepository,
            IMapper mapper, ILogger<HouseController> logger)
            : base(HouseRepository, mapper, logger)
        {

        }
    }
}
