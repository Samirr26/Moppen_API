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

        public async Task<IEnumerable<Joke>> SelectJokesBasedOnAuthor(string author)
        {
            try
            {
                await using SqlConnection connection = new(_JokesDBConnectionString);

                IEnumerable<Joke> result = await connection.QueryBuilder($@"

                    SELECT *
                    FROM dbo.Jokes
                    WHERE Author = {author}

                    ").QueryAsync<Joke>();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<Joke>> SelectJokesBasedOnSubject(string subject)
        {
            try
            {
                await using SqlConnection connection = new(_JokesDBConnectionString);

                IEnumerable<Joke> result = await connection.QueryBuilder($@"

                    SELECT *
                    FROM dbo.Jokes
                    WHERE Subject = {subject}

                    ").QueryAsync<Joke>();

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

                    SELECT TOP (1) *
                    FROM [JokesDB].[dbo].[Jokes]
                    ORDER BY NEWID()                 
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

        public async Task<IEnumerable<Author>> SelectAllAuthors()
        {
            try
            {
                await using SqlConnection connection = new(_JokesDBConnectionString);

                IEnumerable<Author> result = await connection.QueryBuilder($@"

                    SELECT *
                    FROM dbo.Authors

                    ").QueryAsync<Author>();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Author> InsertAuthor(Author author)
        {
            try
            {
                await using SqlConnection connection = new(_JokesDBConnectionString);

                await connection.QueryBuilder($@"

                    INSERT INTO dbo.Authors (AuthorName)
                    VALUES ({author.AuthorName});

                    ").ExecuteAsync();

                return author;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
