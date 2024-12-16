using Microsoft.AspNetCore.Mvc;
using PlanetsAPI.DTO;
using System.Xml.Linq;

namespace PlanetsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanetaController : Controller
    {
        private readonly ILogger<PlanetaDTO> _logger;


        private static List<PlanetaDTO> Planetas = new List<PlanetaDTO>()
        {
            new PlanetaDTO
            {
                Nombre="123456",
                Id=1,
                Atmosfera="200",
                Distancia=1,
                Temperatura="Caloh",
                Tipo="Tipazo"
                
            }
        };

        public PlanetaController(ILogger<PlanetaDTO> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAllElement")]
        public IEnumerable<PlanetaDTO> Get()
        {
            return Planetas;
        }

        
        [HttpPost]
        public PlanetaDTO Post([FromBody] PlanetaDTO libro)
        {
            if (Planetas.Any(x => x.Id == libro.Id))
            {
                return null;
            }
            Planetas.Add(libro);
            return libro;
        }


        [HttpDelete("{id}")]
        public bool Remove(int id)
        {
            PlanetaDTO? libroBBDD = Planetas.FirstOrDefault(x => x.Id == id);
            if (libroBBDD == null)
            {
                return false;
            }
            return Planetas.Remove(libroBBDD);
        }
    }
}
