using Cohorts_Hw3.Api.Aplications.AuthorOperations.Queries;
using Cohorts_Hw3.Api.Validator.Author;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cohorts_Hw3.UnitTest.Application.AuthorOperations.Query.GetAuthorDetailQueries
{
    public class GetAuthorDetailQueriesValidatorTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenAuthorIdValueIsLessThanAndEqualZero_Validator_ShouldBeReturnErrors(int id)
        {
            GetByIdAuthorQuery query = new GetByIdAuthorQuery(null, null);
            query.Id = id;

            GetByIdAuthorValidator validator = new GetByIdAuthorValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenAuthorIdValueIsMoreThanZero_Validator_ShouldNotBeReturnError()
        {
            GetByIdAuthorQuery query = new GetByIdAuthorQuery(null, null);
            query.Id = 1;

            GetByIdAuthorValidator validator = new GetByIdAuthorValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().Be(0);

        }
    }
}
