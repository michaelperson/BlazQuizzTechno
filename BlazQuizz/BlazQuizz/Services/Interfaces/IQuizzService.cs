using BlazQuizz.Domain;

namespace BlazQuizz.Services.Interfaces
{
    public interface IQuizzService
    {
        Task<IEnumerable<Themes>?> GetThemesAsync();
        Task<RootResponseApiQuizz?> GetQuestions(string Theme);
    }
}
