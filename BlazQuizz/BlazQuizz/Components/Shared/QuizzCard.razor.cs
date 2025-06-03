using BlazQuizz.Domain;
using Microsoft.AspNetCore.Components;

namespace BlazQuizz.Components.Shared
{
    public partial class QuizzCard
    { 
        [Parameter]
        public Questions CurrentQuestion { get; set; }
        [Parameter]
        public EventCallback OnResponse { get; set; }

        public void Choix(string rep)
        {
            CurrentQuestion.Reponse = rep;
            OnResponse.InvokeAsync();
        }
    }
}
