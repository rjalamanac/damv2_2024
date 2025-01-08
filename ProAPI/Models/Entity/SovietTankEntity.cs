using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestAPI.Models.Entity
{
    public class SovietTankEntity
    {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [Required]
            [MaxLength(50)]
            public string Name { get; set; }
            public DateTime CreatedDate { get; set; }
            [Required]
            public int Damage { get; set; }

            [Required, MaxLength(50)]
            public string Bastidor { get; set; }

    }
}
