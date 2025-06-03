using BlazQuizz.Domain;
using BlazQuizz.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BlazQuizz.Components.Pages
{
    public partial class Home
    {
        private string? _nickName;
        private IEnumerable<Themes>? _themes;
        private Themes? ThemeChoisi;
        [Inject]
        NavigationManager? _navigationManager { get;set; }

        [Inject]
        IQuizzService? quizzService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _themes = await quizzService.GetThemesAsync();
             
        }

        public void selectTheme(int ThemeId)
        {
            ThemeChoisi = _themes?.SingleOrDefault(t => t.Id == ThemeId);
        }

        public void startQuizz()
        { 
            _navigationManager?.NavigateTo($"/QuizzPage/{_nickName}/{ThemeChoisi.Nom}/{ThemeChoisi.Id}",true);
        }

    }
}
