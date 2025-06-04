using BlazQuizz.Domain;
using BlazQuizz.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BlazQuizz.Components.Pages
{
    public partial class QuestionForm
    {

        [SupplyParameterFromForm]
        public QuestionModel LaQuestion { get;set; }
        [Inject]
        public IQuizzService quizzService { get; set; }
        public bool IsSend { get; set; } = false;
        public List<string> LesThemes { get; set; } = new List<string>() { "tv_cinema", "art_litterature", "musique", "actu_politique", "culture_generale", "sport", "jeux_videos" };

        public enum Difficulty
        {
            facile, normal, difficile
        }

        protected override Task OnInitializedAsync()
        {
            LaQuestion = new QuestionModel();
            LaQuestion.Texte = "Votre question";
            return base.OnInitializedAsync();
        }
 

        public async Task SendForm()
        {
            //1- tranformer le retour du form en Api
            QuestionAddApi QA = new QuestionAddApi
            {
                Texte = LaQuestion.Texte,
                Answer = LaQuestion.Answer,
                BadAnswers = new List<string> { LaQuestion.MauvaiseReponse1, LaQuestion.MauvaiseReponse2, LaQuestion.MauvaiseReponse3 },
                 Category = LaQuestion.Category,
                 Difficulty = LaQuestion.Difficulty
            };

            IsSend = await quizzService.PostQuestion(QA);

        }

    }
}
