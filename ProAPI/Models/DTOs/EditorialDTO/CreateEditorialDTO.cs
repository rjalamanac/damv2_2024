using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.Models.DTOs
{
    public class CreateEditorialDTO
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(200, ErrorMessage = "Max char is 200")]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Beneficios is required")]
        public int Beneficios { get; set; }

        [Required(ErrorMessage = "Ubicacion is required")]
        [MaxLength(200, ErrorMessage = "Max char is 200")]
        public string Ubicacion { get; set; }
    }
}