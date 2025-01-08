using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.Models.DTOs
{
    public class CreateSovietTankDTO
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50, ErrorMessage = "Max char is 50")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Damage is required")]
        public int Damage { get; set; }

        [Required(ErrorMessage = "Ubicacion is required")]
        [MaxLength(50, ErrorMessage = "Max char is 50")]
        public string Bastidor { get; set; }
    }
}