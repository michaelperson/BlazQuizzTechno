using BlazQuizz.Domain;
using BlazQuizz.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BlazQuizz.Components.Pages
{
    public partial class QuizzPage
    {
        [Inject]
        IQuizzService quizzService { get;set; }

        [Parameter]
        [SupplyParameterFromQuery]
        public string NickName { get; set; }
        [Parameter]
        [SupplyParameterFromQuery]
        public string Theme { get; set; }
        [Parameter]
        [SupplyParameterFromQuery]
        public string ThemeFilter { get; set; }

        private RootResponseApiQuizz? Quizzes { get;set; }
        private List<Questions>? ListQuestion { get { return Quizzes?.Questions; } }
        private int? nbQuestions { get { return Quizzes?.NombreDeQuestions; } }
        private int nbQuestionsRepondues { get; set; }

        private int QuestionIndex { get; set; }
        private Questions? CurrentQuestion { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Quizzes = await quizzService.GetQuestions(ThemeFilter);
            for (int i = 0; i < Quizzes?.Questions.Count; i++)
            {
                Quizzes.Questions[i].NumQuestion = i+1;
            }

            LoadQuestion();
             
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
            StateHasChanged();
        }

        
        public void ReponseHandler()
        {
            nbQuestionsRepondues++;
            //Si je suis à la dernière question affihcer uniquement les résultat
            if(nbQuestionsRepondues!= nbQuestions)
            {

                next();
            } 
        }
    }
}
