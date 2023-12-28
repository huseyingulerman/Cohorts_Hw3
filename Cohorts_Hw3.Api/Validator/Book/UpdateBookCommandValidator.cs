using Cohorts_Hw3.Api.Aplications.BookOperations.Command;
using FluentValidation;

namespace Cohorts_Hw3.Api.Validator.Book
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
            RuleFor(command => command.Model.PublishDate).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.PageCount).GreaterThan(0);
            RuleFor(command => command.Model.Genre).NotEmpty();
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);


        }
    }
}
