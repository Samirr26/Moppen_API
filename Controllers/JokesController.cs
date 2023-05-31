using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moppen_API.DataContext;
using Moppen_API.Models;

namespace Moppen_API.Controllers
{
    [ApiController]
    [Route("jokes")]
    [Produces("application/json")]

    public class JokesController : Controller
    {

        private readonly IJokesDataContext _jokesDataContext;
        public JokesController(IConfiguration configuration)
        {
            _jokesDataContext = new JokesDataContext(configuration);
        }

        [HttpGet("random")]
        public async Task<Joke> getRandomJoke()
        {
            var result = await _jokesDataContext.SelectRandomJoke();
            return result;
        }


        [HttpGet("author/{author}")]
        public async Task<IEnumerable<String>> getJokesBasedOnAuthor(string author)
        {
            var result = await _jokesDataContext.SelectJokesBasedOnAuthor(author);
            return result;
        }

        [HttpGet("subject/{subject}")]
        public async Task<IEnumerable<String>> getJokesBasedOnSubject(string subject)
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