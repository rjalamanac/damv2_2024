using System.Text.Json.Serialization;

namespace WPF_FirstAPP.DTO
{
    public class LibroDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("titulo")]
        public string Titulo { get; set; }
        [JsonPropertyName("isbn")]
        public string ISBN { get; set; }
        [JsonPropertyName("numPaginas")]
        public int NumPaginas { get; set; }
    }
}
