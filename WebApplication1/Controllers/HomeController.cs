using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

      
        [HttpGet(Name = "GetElementalWords/{word}")]
        public List<List<string>> GetElementalWords(string word)
        {
            return PeriodicElementWords.Form(word);
        }
    }
}

