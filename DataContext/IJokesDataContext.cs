using Moppen_API.Models;

namespace Moppen_API.DataContext
{
    public interface IJokesDataContext
    {
        public Task<Joke> SelectRandomJoke();
        public Task<IEnumerable<String>> SelectJokesBasedOnAuthor(string author);
        public Task<IEnumerable<String>> SelectJokesBasedOnSubject(string subject);
    }
}
