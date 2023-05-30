using DapperQueryBuilder;
using Microsoft.Data.SqlClient;
using Moppen_API.Models;

namespace Moppen_API.DataContext
{
    public class JokesDataContext : IJokesDataContext
    {
        private readonly string _JokesDBConnectionString;

        public JokesDataContext(IConfiguration configuration)
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
            return null;
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
    }
}
