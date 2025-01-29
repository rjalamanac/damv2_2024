

namespace RestAPI.Models.DTOs
{
    public class HouseDTO : CreateHouseDTO
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
