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
    public class JokesControllerTests
    {
        private JokesController _jokesController;

        public JokesControllerTests()
        {
            _jokesController = new JokesController(Substitute.For<IConfiguration>());
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _jokesController = new JokesController(Substitute.For<IConfiguration>());
        }

        [TestMethod]
        public async Task Get_Random_Joke_Test_Should_Not_Be_Null()
        {
            var response = _jokesController.getRandomJoke();
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task Get_Random_Joke_Test_Should_Be_Type_Of_Joke()
        {
            var response = _jokesController.getRandomJoke();
            response.Should().BeOfType<Task<Joke>>();
        }

        [TestMethod]
        public async Task Get_Joke_Based_Author_Test_Should_Not_Be_Null()
        {

            var response = _jokesController.getJokesBasedOnAuthor("Samir");
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task Get_Joke_Based_Author_Test_Should_Be_Type_Of_List()
        {

            var response = _jokesController.getJokesBasedOnAuthor("Samir");
            response.Should().BeOfType<Task<IEnumerable<Joke>>>();
        }

        [TestMethod]
        public async Task Get_Joke_Based_Subject_Test_Should_Not_Be_Null()
        {
            var response = _jokesController.getJokesBasedOnAuthor("IT");
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task Get_Joke_Based_Subject_Test_Should_Be_Type_Of_List()
        {
            var response = _jokesController.getJokesBasedOnAuthor("IT");
            response.Should().BeOfType<Task<IEnumerable<Joke>>>();
        }
    }
}
