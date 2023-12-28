using Cohorts_Hw3.Api.Aplications.AuthorOperations.Commands;
using Cohorts_Hw3.Api.Validator.Author;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cohorts_Hw3.UnitTest.Application.AuthorOperations.Commands.DeleteAuthorCommands
{
    public class DeleteAuthorCommandValidatorTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenDeleteAuthorIdValueIsLessThanAndEqualZero_Validator_ShouldBeReturnErrors(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(null);
            command.Id = id;

            DeleteAuthorValidator validator = new DeleteAuthorValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenDeleteAuthorIdValueIsMoreThanZero_Validator_ShouldNotBeReturnError()
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(null);
            command.Id = 1;

            DeleteAuthorValidator validator = new DeleteAuthorValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);

        }
    }
}
