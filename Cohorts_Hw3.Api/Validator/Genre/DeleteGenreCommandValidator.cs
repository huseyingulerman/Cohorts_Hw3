using Cohorts_Hw3.Api.Aplications.GenreOperations.Commands;
using FluentValidation;

namespace Cohorts_Hw3.Api.Validator.Genre
{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
