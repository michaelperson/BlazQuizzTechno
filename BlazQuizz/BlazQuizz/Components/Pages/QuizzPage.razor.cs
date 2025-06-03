using BlazQuizz.Domain; 
using Microsoft.AspNetCore.Components;

namespace BlazQuizz.Components.Pages
{
    public partial class QuizzPage
    {
        [Parameter]
        [SupplyParameterFromQuery]
        public string NickName { get; set; }

        private List<Questions> ListQuestion { get; set; }
        private int nbQuestions { get { return ListQuestion.Count(); } }
        private int nbQuestionsRepondues { get; set; }

        private int QuestionIndex { get; set; }
        private Questions CurrentQuestion { get; set; }

        protected override Task OnInitializedAsync()
        {
            ListQuestion = new List<Questions>()
            {
                new Questions() { Id=1, Libelle="As-tu faim?" },
                new Questions() {Id= 2, Libelle="As-tu froid?" },
                new Questions() {Id= 3, Libelle="Aime-tu les légumes?" }
            };

            LoadQuestion();
            return base.OnInitializedAsync();
        }

        public void previous()
        {
            if(QuestionIndex>0)
            QuestionIndex--;
            LoadQuestion();
        }

        public void next()
        {
            if (QuestionIndex < ListQuestion.Count()-1)
                QuestionIndex++;
            LoadQuestion();
        }

        private void LoadQuestion()
        {
            CurrentQuestion = ListQuestion[QuestionIndex];
        }

        
        public void Etalorsjavaismisajouterreponse()
        {
            nbQuestionsRepondues++;
            //Si je suis à la dernière question affihcer uniquement les résultat
            if(nbQuestionsRepondues== nbQuestions)
            {
                //c'est la fin
            }
            else
            //sinon
            next();
        }
    }
}
