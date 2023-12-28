using Cohorts_Hw3.Api.Aplications.BookOperations.Queries;
using FluentValidation;

namespace Cohorts_Hw3.Api.Validator.Book
{
    public class GetByIdQueryValidator : AbstractValidator<GetByIdQuery>
    {
        public GetByIdQueryValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}
