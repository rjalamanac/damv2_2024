using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RestAPI.Models.Entity
{
    [Index(nameof(ISBN), IsUnique = true)]
    public class LibroEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        public int Paginas { get; set; }
        [Required, MaxLength(50)]
        public string ISBN { get; set; }

    }
}
