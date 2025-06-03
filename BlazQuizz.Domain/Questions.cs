using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazQuizz.Domain
{
    public class Questions
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("libelle")]
        public string Libelle { get; set; }

        [JsonPropertyName("reponse")]
        public string Reponse { get; set; }
    }
}
