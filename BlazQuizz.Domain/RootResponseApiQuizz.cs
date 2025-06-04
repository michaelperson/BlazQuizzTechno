using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazQuizz.Domain
{
    public class RootResponseApiQuizz
    {
        [JsonPropertyName("count")]
        public int NombreDeQuestions { get; set; }
        [JsonPropertyName("quizzes")]
        public List<Questions> Questions { get; set; }
    }
}
