using Cohorts_Hw3.Api.Aplications.AuthorOperations.Queries;
using FluentValidation;

namespace Cohorts_Hw3.Api.Validator.Author
{
    public class GetByIdAuthorValidator : AbstractValidator<GetByIdAuthorQuery>
    {
        public GetByIdAuthorValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
