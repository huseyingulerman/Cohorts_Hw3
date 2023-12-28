using Cohorts_Hw3.Api.Aplications.BookOperations.Command;
using Cohorts_Hw3.Api.Validator.Book;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cohorts_Hw3.Api.Aplications.BookOperations.Command.UpdateBookCommand;

namespace Cohorts_Hw3.UnitTest.Application.BookOperations.Commands.UpdateBookCommands
{
    public class UpdateBookCommandValidatorTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenUpdateBookIdValueIsLessThanAndEqualZero_Validator_ShouldBeReturnErrors(int id)
        {
            UpdateBookCommand command = new UpdateBookCommand(null);
            command.Id = id;
            command.Model = new UpdateBookModel()
            {
                Title="Görünmez Kentler",
                PageCount=250,
                AuthorId=1,
                GenreId=2,
                PublishDate=DateTime.Now.AddYears(-3)
            };
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Theory]
        [InlineData("aa")]
        [InlineData("")]
        [InlineData(" ")]
        public void WhenInvalidInputsAreGivenUpdateBook_Validator_ShouldBeReturnErrors(string title)
        {
            UpdateBookCommand command = new UpdateBookCommand(null);
            command.Model = new UpdateBookModel
            {
                Title = title,
                PageCount = 250,
                AuthorId = 1,
                GenreId = 2,
                PublishDate = DateTime.Now.AddYears(-3)
            };
            command.Id = 1;

            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenDateTimeEqualNowIsGivenUpdateBook_Validator_ShouldBeReturnError()
        {
            UpdateBookCommand command = new UpdateBookCommand(null);
            command.Model = new UpdateBookModel
            {
                Title = "Görünmez Kentler",
                PageCount = 250,
                AuthorId = 1,
                GenreId = 2,
                PublishDate = DateTime.Now.Date
            };
            command.Id = 1;
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenValidInputsAreGivenUpdateBook_Validator_ShouldNotBeReturnError()
        {
            UpdateBookCommand command = new UpdateBookCommand(null);
            command.Model = new UpdateBookModel
            {
                Title = "Görünmez Kentler",
                PageCount = 250,
                AuthorId = 1,
                GenreId = 2,
                PublishDate = DateTime.Now.AddYears(-3)
            };
            command.Id = 1;
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}
