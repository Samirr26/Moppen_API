namespace Moppen_API.Models
{
    public class Joke
    {
        public int Id { get; }
        public string Author { get; }
        public string Subject { get;  }
        public string FullJoke { get; }

        public Joke(int id, string author, string subject, string fullJoke)
        {
            Id = id;
            Author = author;
            Subject = subject;
            FullJoke = fullJoke;
        }
    }
}
