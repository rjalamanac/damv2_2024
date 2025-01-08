using System.Text.Json.Serialization;

namespace WPF_FirstAPP.DTO
{
    public class LibroDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Titulo { get; set; }
        [JsonPropertyName("isbn")]
        public string ISBN { get; set; }
        [JsonPropertyName("paginas")]
        public int NumPaginas { get; set; }
        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; }
    }
}
