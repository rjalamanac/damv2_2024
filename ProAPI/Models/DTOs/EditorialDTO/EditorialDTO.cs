

namespace RestAPI.Models.DTOs
{
    public class EditorialDTO : CreateEditorialDTO
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
