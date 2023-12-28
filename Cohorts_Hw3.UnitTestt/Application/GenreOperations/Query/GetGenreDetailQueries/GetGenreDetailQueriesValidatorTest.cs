using Cohorts_Hw3.Api.Aplications.GenreOperations.Queries;
using Cohorts_Hw3.Api.Validator.Genre;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cohorts_Hw3.UnitTest.Application.GenreOperations.Query.GetGenreDetailQueries
{
    public class GetGenreDetailQueriesValidatorTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenGenreIdValueIsLessThanAndEqualZero_Validator_ShouldBeReturnErrors(int id)
        {
            GetGenreDetailsQuery query = new GetGenreDetailsQuery(null, null);
            query.Id = id;

            GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenGenreIdValueIsMoreThanZero_Validator_ShouldNotBeReturnError()
        {
            GetGenreDetailsQuery query = new GetGenreDetailsQuery(null, null);
            query.Id = 1;

            GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().Be(0);

        }
    }
}
