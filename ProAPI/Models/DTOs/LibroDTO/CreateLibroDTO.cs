using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.Models.DTOs.LibroDTO
{
    public class CreateLibroDTO
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50, ErrorMessage = "Max char is 50")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Paginas is required")]
        public int Paginas { get; set; }
        [Required(ErrorMessage = "ISBN is required")]
        [MaxLength(50, ErrorMessage = "Max char is 50")]
        public string ISBN { get; set; }
    }
}