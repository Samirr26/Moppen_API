using Moppen_API.Models;

namespace Moppen_API.DataContext
{
    public class JokesDataContext : IJokesDataContext
    {
        public async Task<IEnumerable<Joke>> SelectJokesBasedOnAuthor(string author)
        {
            return new List<Joke>();
        }

        public async Task<IEnumerable<Joke>> SelectJokesBasedOnSubject(string subject)
        {
            return new List<Joke>();
        }

        public async Task<Joke> SelectRandomJoke()
        {
            return new Joke(1, "Samir", "IT", "Why did the programmer need glasses? Because he couldnt C#");
        }
    }
}
