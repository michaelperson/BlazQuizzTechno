using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazQuizz.Domain
{
    public class QuestionModel
    {
        [Required]
        [MinLength(10)]
        public string Texte { get; set; } 
        [Required]
        public string Answer { get; set; }
        [Required]
        public string MauvaiseReponse1 { get; set; }
        [Required]
        public string MauvaiseReponse2 { get; set; }
        [Required]
        public string MauvaiseReponse3 { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public  string Difficulty { get; set; }


    }
}
