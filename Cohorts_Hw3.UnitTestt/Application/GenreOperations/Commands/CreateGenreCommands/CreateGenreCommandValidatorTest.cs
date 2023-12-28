using Cohorts_Hw3.Api.Aplications.GenreOperations.Commands;
using Cohorts_Hw3.Api.Validator.Genre;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cohorts_Hw3.UnitTest.Application.GenreOperations.Commands.CreateGenreCommands
{
    public class CreateGenreCommandValidatorTest
    {
        [Theory]
        [InlineData("a")]
        [InlineData("")]
        [InlineData(" ")]
        public void WhenInvalidInputsAreGivenGenre_Validator_ShouldBeReturnErrors(string name)
        {
            CreateGenreCommand command = new CreateGenreCommand(null);
            command.Model = new CreateGenreModel()
            {
                Name=name
            };

            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenValidInputsAreGivenGenre_Validator_ShouldNotBeReturnError()
        {
            CreateGenreCommand command = new CreateGenreCommand(null);
            command.Model = new CreateGenreModel()
            {
                Name= "Attempt"
            };

            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);

        }
    }
}
