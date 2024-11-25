using System.ComponentModel.DataAnnotations;

namespace ApiPelicula.Models.DTOs.CategoryDto
{
 
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "Max char is 100")]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
