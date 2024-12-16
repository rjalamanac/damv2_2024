using System.Text.Json.Serialization;

namespace Examen_Galaxy.DTO
{
    public class PlanetaDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }
        [JsonPropertyName("distancia")]
        public int Distancia { get; set; }
        [JsonPropertyName("tipo")]
        public string Tipo { get; set; }
        [JsonPropertyName("temperatura")]
        public string Temperatura { get; set; }
        [JsonPropertyName("atmosfera")]
        public string Atmosfera { get; set; }
        [JsonPropertyName("imageName")]
        public string ImageName { get; set; }
    }
}
