using Cohorts_Hw3.Api.Aplications.BookOperations.Command;
using Cohorts_Hw3.Api.Validator.Book;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cohorts_Hw3.UnitTest.Application.BookOperations.Commands.DeleteBookCommands
{
    public class DeleteBookCommandValidatorTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenDeleteBookIdValueIsLessThanAndEqualZero_Validator_ShouldBeReturnErrors(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(null);
            command.Id = id;

            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenDeleteBookIdValueIsMoreThanZero_Validator_ShouldNotBeReturnError()
        {
            DeleteBookCommand command = new DeleteBookCommand(null);
            command.Id = 1;

            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);

        }
    }
}
