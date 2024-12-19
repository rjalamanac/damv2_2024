using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestAPI.Models.Entity
{

    public class EditorialEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        public int Beneficios { get; set; }
        [Required]
        [MaxLength(200)]
        public string Ubicacion { get; set; }
    }
}
