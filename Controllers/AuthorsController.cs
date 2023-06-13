using Microsoft.AspNetCore.Mvc;
using Moppen_API.DataContext;
using Moppen_API.Models;

namespace Moppen_API.Controllers
{
    [ApiController]
    [Route("authors")]
    public class AuthorsController : Controller
    {
        private readonly IJokesDBDataContext _jokesDataContext;
        public AuthorsController(IConfiguration configuration)
        {
            _jokesDataContext = new JokesDBDataContext(configuration);
        }

        [HttpGet("all")]
        public async Task<IEnumerable<Author>> getAllAuthors()
        {
            var result = await _jokesDataContext.SelectAllAuthors();
            return result;
        }

        [HttpPost("create-new-author")]
        public async Task<Author> createNewAuthor([FromBody] Author author)
        {
            var result = await _jokesDataContext.InsertAuthor(author);
            return result;
        }
    }
}
