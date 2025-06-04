using BlazQuizz.Domain;
using BlazQuizz.Services.Interfaces;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlazQuizz.Services
{
    public class QuizzService : IQuizzService
    {
        public async Task<IEnumerable<Themes>?> GetThemesAsync()
        {
            //1- me connecter à l'api
            HttpClient _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7079");

            //2- appeler le endpoint Theme
           HttpResponseMessage response = await _client.GetAsync("/api/Quizz");

            //2.1 S'assurer que nous avons un success
            response.EnsureSuccessStatusCode();

            //2.2 Deserializer le body
            var jason = await response.Content.ReadAsStringAsync();
            if(jason != null)
            {
                IEnumerable<Themes>? themes = JsonSerializer.Deserialize<IEnumerable<Themes>>(jason);

                //3 - retourner les themes
                return themes;
            }
            else
            {
                return Enumerable.Empty<Themes>();
            }
           

        }
    
        public async Task<RootResponseApiQuizz?> GetQuestions(string Theme)
        {
            HttpClient _client = new HttpClient();
            _client.BaseAddress = new Uri("https://quizzapi.jomoreschi.fr/api/v1/");
            HttpResponseMessage response = await _client.GetAsync($"quiz?limit=5&category={Theme}&difficulty=facile");
            //2.1 S'assurer que nous avons un success
            response.EnsureSuccessStatusCode();

            //2.2 Deserializer le body
            var jason = await response.Content.ReadAsStringAsync();
            if (jason != null)
            {
                RootResponseApiQuizz? Quizzes = JsonSerializer.Deserialize<RootResponseApiQuizz>(jason);

                //3 - retourner les themes
                return Quizzes;
            }
            else
            {
                return null;
            }
             
        }

        public async Task<bool> PostQuestion(QuestionAddApi qA)
        {
            HttpClient _client = new HttpClient();
            _client.BaseAddress = new Uri("https://quizzapi.jomoreschi.fr/api/v1/");
            JsonSerializer.Serialize<QuestionAddApi>(qA);
           HttpResponseMessage message = await _client.PostAsJsonAsync<QuestionAddApi>("create", qA);

            return message.IsSuccessStatusCode;
        }
    }
}
