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
        public JokesController()
        {
            _jokesDataContext = new JokesDataContext();
        }

        [HttpGet("random")]
        public async Task<Joke> getRandomJoke()
        {
            var result = await _jokesDataContext.SelectRandomJoke();
            return result;
        }


        [HttpGet("{author}")]
        public async Task<IEnumerable<Joke>> getJokesBasedOnAuthor(string author)
        {
            var result = await _jokesDataContext.SelectJokesBasedOnAuthor(author);
            return result;
        }

        [HttpGet("{subject}")]
        public async Task<IEnumerable<Joke>> getJokesBasedOnSubject(string subject)
        {
            var result = await _jokesDataContext.SelectJokesBasedOnSubject(subject);
            return result;
        }
    }

}