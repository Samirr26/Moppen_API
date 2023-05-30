using Moppen_API.Models;

namespace Moppen_API.DataContext
{
    public interface IJokesDataContext
    {
        public Task<Joke> SelectRandomJoke();
        public Task<IEnumerable<Joke>> SelectJokesBasedOnAuthor(string author);
        public Task<IEnumerable<Joke>> SelectJokesBasedOnSubject(string subject);
    }
}
