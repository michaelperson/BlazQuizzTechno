using System.Text.Json.Serialization;

namespace BlazQuizz.Domain
{
    public class Themes
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nom")]
        public string Nom { get; set; }

        [JsonPropertyName("filterName")]
        public string FilterName { get;set; }
    }
}
