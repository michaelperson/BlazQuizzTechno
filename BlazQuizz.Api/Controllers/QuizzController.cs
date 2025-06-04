using BlazQuizz.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazQuizz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetThemes()
        {
            List<Themes> lesThemes = new List<Themes>()
            {
                new Themes(){ Id=1, Nom="Musique", FilterName="musique"},
                new Themes(){ Id=2, Nom="Cinema", FilterName="tv_cinema"},
                new Themes(){ Id=3, Nom="Jeux Vidéo", FilterName = "jeux_videos"},
                new Themes(){ Id=4, Nom="Literature", FilterName="art_litterature"},
            };
            return Ok(lesThemes);
        }
    }
}
