using Cohorts_Hw3.Api.Validator.Genre;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cohorts_Hw3.UnitTest.Application.GenreOperations.Commands.UpdateGenreCommands
{
    public class UpdateGenreCommandValidatorTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenUpdateGenreIdValueIsLessThanAndEqualZero_Validator_ShouldBeReturnErrors(int id)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(null);
            command.GenreId = id;
            command.Model = new UpdateGenreModel()
            {
                Name = "Biography"
            };
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Theory]
        [InlineData("aa")]
        public void WhenInvalidInputsAreGivenUpdateGenre_Validator_ShouldBeReturnErrors(string name)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(null);
            command.Model = new UpdateGenreModel
            {
                Name = name,
            };
            command.GenreId = 1;

            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Theory]
        [InlineData("Biography")]
        [InlineData("")]
        [InlineData(" ")]
        public void WhenValidInputsAreGivenUpdateGenre_Validator_ShouldNotBeReturnError(string name)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(null);
            command.Model = new UpdateGenreModel
            {
                Name = name,
            };
            command.GenreId = 1;
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}
