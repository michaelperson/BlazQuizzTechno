using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazQuizz.Domain
{
    public class Proposition
    {
        public string Letter { get; set; }
        public string Reponse { get; set; }
        public bool IsCorrect { get; set; }
    }
}
