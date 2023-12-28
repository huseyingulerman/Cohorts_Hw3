using Cohorts_Hw3.Api.Aplications.BookOperations.Command;
using FluentValidation;

namespace Cohorts_Hw3.Api.Validator.Book
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}
