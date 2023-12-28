using Cohorts_Hw3.Api.Aplications.GenreOperations.Queries;
using FluentValidation;

namespace Cohorts_Hw3.Api.Validator.Genre
{
    public class GetGenreDetailQueryValidator : AbstractValidator<GetGenreDetailsQuery>
    {
        public GetGenreDetailQueryValidator()
        {
            RuleFor(query => query.Id).GreaterThan(0);
        }
    }
}
