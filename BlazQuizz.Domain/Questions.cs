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
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("question")]
        public string Libelle { get; set; }

        [JsonPropertyName("answer")]
        public string Answer { get; set; }

        [JsonPropertyName("badAnswers")]
        public List<string> BadAnswer { get; set; }


        [JsonIgnore]
        public Proposition Reponse { get; set; }

        [JsonIgnore]
        public int NumQuestion { get; set; }
    }
}
