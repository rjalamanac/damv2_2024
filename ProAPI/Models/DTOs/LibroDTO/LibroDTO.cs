namespace RestAPI.Models.DTOs.LibroDTO
{
    public class LibroDTO : CreateLibroDTO
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
