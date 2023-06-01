using DapperQueryBuilder;
using Microsoft.Data.SqlClient;
using Moppen_API.Models;

namespace Moppen_API.DataContext
{
    public class JokesDBDataContext : IJokesDBDataContext
    {
        private readonly string _JokesDBConnectionString;

        public JokesDBDataContext(IConfiguration configuration)
        {
            _JokesDBConnectionString = configuration.GetConnectionString("JokesDB");
        }

        public async Task<IEnumerable<String>> SelectJokesBasedOnAuthor(string author)
        {
            try
            {
                await using SqlConnection connection = new(_JokesDBConnectionString);

                IEnumerable<String> result = await connection.QueryBuilder($@"

                    SELECT FullJoke As FullJoke
                    FROM dbo.Jokes
                    WHERE Author = {author}

                    ").QueryAsync<String>();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<String>> SelectJokesBasedOnSubject(string subject)
        {
            try
            {
                await using SqlConnection connection = new(_JokesDBConnectionString);

                IEnumerable<String> result = await connection.QueryBuilder($@"

                    SELECT FullJoke As FullJoke
                    FROM dbo.Jokes
                    WHERE Subject = {subject}

                    ").QueryAsync<String>();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Joke> SelectRandomJoke()
        {
            try
            {
                await using SqlConnection connection = new(_JokesDBConnectionString);

                Joke result = await connection.QueryBuilder($@"

                    SELECT RAND() As FullJoke
                    FROM dbo.Jokes

                    ").QuerySingleAsync<Joke>();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Joke> InsertJoke(Joke newJoke)    
        {
            try
            {
                await using SqlConnection connection = new(_JokesDBConnectionString);

                await connection.QueryBuilder($@"

                    INSERT INTO dbo.Jokes (author, subject, fulljoke)
                    VALUES ({newJoke.Author}, {newJoke.Subject}, {newJoke.FullJoke});

                    ").ExecuteAsync();

                return newJoke;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
