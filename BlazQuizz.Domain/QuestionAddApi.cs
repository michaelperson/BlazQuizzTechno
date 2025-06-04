using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazQuizz.Domain
{ 
    public class QuestionAddApi
    {
        [JsonPropertyName("question")]
        public string Texte { get; set; }

        [JsonPropertyName("answer")]
        public string Answer { get; set; }

        [JsonPropertyName("badAnswers")]
        public List<string> BadAnswers { get; set; }


        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("difficulty")]
        public string Difficulty { get; set; }
    }
}
