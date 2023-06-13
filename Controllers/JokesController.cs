using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moppen_API.DataContext;
using Moppen_API.Models;

namespace Moppen_API.Controllers
{
    [ApiController]
    [Route("jokes")]

    public class JokesController : Controller
    {
        private readonly IJokesDBDataContext _jokesDataContext;
        public JokesController(IConfiguration configuration)
        {
            _jokesDataContext = new JokesDBDataContext(configuration);
        }

        [HttpGet("random")]
        public async Task<Joke> getRandomJoke()
        {
            var result = await _jokesDataContext.SelectRandomJoke();
            return result;
        }


        [HttpGet("author/{author}")]
        public async Task<IEnumerable<Joke>> getJokesBasedOnAuthor(string author)
        {
            var result = await _jokesDataContext.SelectJokesBasedOnAuthor(author);
            return result;
        }

        [HttpGet("subject/{subject}")]
        public async Task<IEnumerable<Joke>> getJokesBasedOnSubject(string subject)
        {
            var result = await _jokesDataContext.SelectJokesBasedOnSubject(subject);
            return result;
        }

        [HttpPost("create-new-joke")]
        public async Task<Joke> createNewJoke([FromBody]Joke Joke)
        {
            var result = await _jokesDataContext.InsertJoke(Joke);
            return result;
        }
    }

}