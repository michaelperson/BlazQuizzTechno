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
                new Themes(){ Id=1, Nom="Musique"},
                new Themes(){ Id=2, Nom="Cinema"},
                new Themes(){ Id=3, Nom="Voyage"},
                new Themes(){ Id=4, Nom="Literature"},
            };
            return Ok(lesThemes);
        }
    }
}
