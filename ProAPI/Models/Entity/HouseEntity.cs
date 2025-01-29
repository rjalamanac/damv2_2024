using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.Models.Entity
{
    public class HouseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(200, ErrorMessage = "Max char is 200")]
        public string Name { get; set; }

        [Required(ErrorMessage = "City is required")]
        [MaxLength(200, ErrorMessage = "Max char is 200")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [MaxLength(200, ErrorMessage = "Max char is 200")]
        public string State { get; set; }

        [Required(ErrorMessage = "Photo is required")]
        public string Photo { get; set; }

        [Required(ErrorMessage = "AvailableUnits is required")]
        public int AvailableUnits { get; set; }

        public DateTime CreatedDate { get; set; }
        public bool Wifi { get; set; }
        public bool laundry { get; set; }

    }
}
