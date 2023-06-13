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

namespace Moppen_API.Tests
{
    [TestClass]

    public class AuthorsContollerTests
    {

        private AuthorsController _authorsController;
        public AuthorsContollerTests()
        {
            _authorsController = new AuthorsController(Substitute.For<IConfiguration>());
        }

        [TestMethod]
        public async Task Get_All_Authors_Should_Not_Be_Null()
        {
            var response = _authorsController.getAllAuthors();
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task Get_All_Authors_Should_Be_Type_Of_Joke()
        {
            var response = _authorsController.getAllAuthors();
            response.Should().BeOfType<Task<IEnumerable<Author>>>();
        }
    }
}
