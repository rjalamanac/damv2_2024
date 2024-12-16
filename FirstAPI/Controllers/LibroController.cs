using FirstAPI.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanetaController : Controller
    {
        private readonly ILogger<PlanetaDTO> _logger;

        private static List<PlanetaDTO> Libros = new List<PlanetaDTO>()
        {
            new PlanetaDTO
            {
                ISBN="123456",
                Id=1,
                NumPaginas=200,
                Titulo="Pocahontas"
            },
            new PlanetaDTO
            {
                ISBN="6666",
                Id=2,
                NumPaginas=3509,
                Titulo="El libro de la selva"
            }
        };

        public PlanetaController(ILogger<PlanetaDTO> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAllElement")]
        public IEnumerable<PlanetaDTO> Get()
        {
            return Libros;
        }

        [HttpGet("{id}")]
        public PlanetaDTO GetOne(int id)
        {
            return Libros.FirstOrDefault(x=>x.Id==id);
        }

        [HttpPost]
        public PlanetaDTO Post([FromBody] PlanetaDTO libro)
        {
            if (Libros.Any(x=> x.Id==libro.Id))
            {
                return null;
            }
            Libros.Add(libro);
            return libro;
        }

        [HttpPut("{id}")]
        public PlanetaDTO Put([FromBody] PlanetaDTO libro,int id)
        {
            if (id!=libro?.Id)
            {
                return null;
            }
            PlanetaDTO? libroBBDD = Libros.FirstOrDefault(x => x.Id == libro.Id);
            if (libroBBDD == null)
            {
                return null;
            }
            libroBBDD.ISBN = libro.ISBN;
            libroBBDD.NumPaginas = libro.NumPaginas;
            libroBBDD.Titulo = libro.Titulo;            
            return libroBBDD;
        }

        [HttpDelete("{id}")]
        public bool Remove(int id)
        {
            PlanetaDTO? libroBBDD = Libros.FirstOrDefault(x => x.Id == id);
            if (libroBBDD == null)
            {
                return false;
            }            
            return Libros.Remove(libroBBDD);
        }
    }


}
