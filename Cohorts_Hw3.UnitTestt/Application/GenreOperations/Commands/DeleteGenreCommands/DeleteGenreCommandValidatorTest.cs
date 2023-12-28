using Cohorts_Hw3.Api.Aplications.GenreOperations.Commands;
using Cohorts_Hw3.Api.Validator.Genre;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cohorts_Hw3.UnitTest.Application.GenreOperations.Commands.DeleteGenreCommands
{
    public class DeleteGenreCommandValidatorTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenDeleteGenreIdValueIsLessThanAndEqualZero_Validator_ShouldBeReturnErrors(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(null);
            command.Id = id;

            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenDeleteGenreIdValueIsMoreThanZero_Validator_ShouldNotBeReturnError()
        {
            DeleteGenreCommand command = new DeleteGenreCommand(null);
            command.Id = 1;

            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);

        }
    }
}
