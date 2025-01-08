using FirstAPI.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibroController : Controller
    {
        private readonly ILogger<LibroDTO> _logger;

        private static List<LibroDTO> Libros = new List<LibroDTO>()
        {
            new LibroDTO
            {
                ISBN="123456",
                Id=1,
                NumPaginas=200,
                Titulo="Pocahontas"
            },
            new LibroDTO
            {
                ISBN="6666",
                Id=2,
                NumPaginas=3509,
                Titulo="El libro de la selva"
            }
        };

        public LibroController(ILogger<LibroDTO> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAllElement")]
        public IEnumerable<LibroDTO> Get()
        {
            return Libros;
        }

        [HttpGet("{id}")]
        public LibroDTO GetOne(int id)
        {
            return Libros.FirstOrDefault(x=>x.Id==id);
        }

        [HttpPost]
        public LibroDTO Post([FromBody] LibroDTO libro)
        {
            if (Libros.Any(x=> x.Id==libro.Id))
            {
                return null;
            }
            Libros.Add(libro);
            return libro;
        }

        [HttpPut("{id}")]
        public LibroDTO Put([FromBody] LibroDTO libro,int id)
        {
            if (id!=libro?.Id)
            {
                return null;
            }
            LibroDTO? libroBBDD = Libros.FirstOrDefault(x => x.Id == libro.Id);
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
            LibroDTO? libroBBDD = Libros.FirstOrDefault(x => x.Id == id);
            if (libroBBDD == null)
            {
                return false;
            }            
            return Libros.Remove(libroBBDD);
        }
    }


}
