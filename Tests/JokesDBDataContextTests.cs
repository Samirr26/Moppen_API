using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moppen_API.Controllers;
using Moppen_API.DataContext;
using Moppen_API.Models;
using NSubstitute;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Moppen_API_Tests
{
    [TestClass]
    public class JokesDBDataContextTests
    {
        private JokesDBDataContext _jokesDBDataContext;

        public JokesDBDataContextTests()
        {
            _jokesDBDataContext = new JokesDBDataContext(Substitute.For<IConfiguration>());
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _jokesDBDataContext = new JokesDBDataContext(Substitute.For<IConfiguration>());
        }

        [TestMethod]
        public async Task Select_Random_Joke_Test_Should_Not_Be_Null()
        {
            var response = _jokesDBDataContext.SelectRandomJoke();
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task Select_Random_Joke_Test_Should_Be_Type_Of_Joke()
        {
            var response = _jokesDBDataContext.SelectRandomJoke();
            response.Should().BeOfType<Task<Joke>>();
        }

        [TestMethod]
        public async Task Select_Joke_Based_Author_Test_Should_Not_Be_Null()
        {

            var response = _jokesDBDataContext.SelectJokesBasedOnAuthor("Samir");
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task Select_Joke_Based_Author_Test_Should_Be_Type_Of_List()
        {

            var response = _jokesDBDataContext.SelectJokesBasedOnAuthor("Samir");
            response.Should().BeOfType<Task<IEnumerable<Joke>>>();
        }

        [TestMethod]
        public async Task Select_Joke_Based_Subject_Test_Should_Not_Be_Null()
        {
            var response = _jokesDBDataContext.SelectJokesBasedOnSubject("IT");
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task Select_Joke_Based_Subject_Test_Should_Be_Type_Of_List()
        {
            var response = _jokesDBDataContext.SelectJokesBasedOnSubject("IT");
            response.Should().BeOfType<Task<IEnumerable<Joke>>>();
        }
    }
}
