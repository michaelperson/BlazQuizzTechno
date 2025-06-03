using BlazQuizz.Domain;

namespace BlazQuizz.Services.Interfaces
{
    public interface IQuizzService
    {
        public Task<IEnumerable<Themes>?> GetThemesAsync();
    }
}
