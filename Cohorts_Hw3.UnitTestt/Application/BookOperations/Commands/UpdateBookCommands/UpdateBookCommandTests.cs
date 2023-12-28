﻿using Cohorts_Hw3.Api.Aplications.BookOperations.Command;
using Cohorts_Hw3.DataAccess.Context;
using Cohorts_Hw3.UnitTest.Application.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cohorts_Hw3.Api.Aplications.BookOperations.Command.UpdateBookCommand;

namespace Cohorts_Hw3.UnitTest.Application.BookOperations.Commands.UpdateBookCommands
{
    public class UpdateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _dbContext;

        public UpdateBookCommandTests(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
        }
        [Fact]
        public void WhenTheUpdateBookIsNotFoundWithTheGivenId_InvalidOperationException_ShouldBeReturn()
        {
            UpdateBookCommand command = new UpdateBookCommand(_dbContext);
            UpdateBookModel model = new UpdateBookModel() { Title = "WhenTheBookIsNotFoundWithTheGivenId_InvalidOperationException_ShouldBeReturn", PageCount = 100, PublishDate = new DateTime(1999, 02, 02), GenreId=1, AuthorId=2 };
            var book = _dbContext.Books.OrderByDescending(x => x.Id).FirstOrDefault();
            command.Id = book.Id + 1;
            command.Model=model;

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Belirtilen ID ile bir kayıt bulunamadı.");
        }

        [Fact]
        public void WhenFoundTheUpdateBookWithTheGivenId_Book_ShouldBeUpdated()
        {

            UpdateBookCommand command = new UpdateBookCommand(_dbContext);
            var book = _dbContext.Books.OrderBy(x => x.Id).FirstOrDefault();
            UpdateBookModel model = new UpdateBookModel() { Title="Bu Da Geçecek", AuthorId=1, GenreId=2, PageCount=540, PublishDate=new DateTime(2000, 01, 25) };
            command.Id = book.Id;
            command.Model=model;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var updatedBook = _dbContext.Books.SingleOrDefault(x => x.Id == book.Id);
            updatedBook.Should().NotBeNull();
            updatedBook.Title.Should().Be(model.Title);
            updatedBook.AuthorId.Should().Be(model.AuthorId);
            updatedBook.GenreId.Should().Be(model.GenreId);
            updatedBook.PageCount.Should().Be(model.PageCount);
            updatedBook.PublishDate.Should().Be(model.PublishDate);

        }
    }
}
