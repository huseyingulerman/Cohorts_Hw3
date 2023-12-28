using Cohorts_Hw3.Api.Aplications.GenreOperations.Commands;
using FluentValidation;

namespace Cohorts_Hw3.Api.Validator.Genre
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(query => query.Model.Name).NotEmpty().MinimumLength(4);
        }
    }
}
