﻿using AutoMapper;
using Cohorts_Hw3.Api.Aplications.AuthorOperations.Commands;
using Cohorts_Hw3.DataAccess.Context;
using Cohorts_Hw3.Entities.DbSets;
using Cohorts_Hw3.UnitTest.Application.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cohorts_Hw3.UnitTest.Application.AuthorOperations.Commands.CreateAuthorCommands
{
    public class CreateAuthorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateAuthorCommandTests(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExistAuthorTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            var author = new Author()
            {
                Name = "Test",
                LastName = "Data",
                BirthDate = new DateTime(2020, 10, 02)
            };
            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges();

            AddAuthorCommand command = new AddAuthorCommand(_dbContext, _mapper);
            command.Model = new AddAuthorViewModel() { Name = author.Name, LastName = author.LastName };

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Girilen yazarın kaydı vardır.");
        }
        [Fact]
        public void WhenValidInputsAreGiven_Author_ShouldBeCreated()
        {
            AddAuthorCommand command = new AddAuthorCommand(_dbContext, _mapper);
            var author = new AddAuthorViewModel()
            {
                Name = "Marry",
                LastName = "Doe",
                BirthDate = new DateTime(2020, 10, 02)
            };
            command.Model = author;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var createdAuthor = _dbContext.Authors.SingleOrDefault(x => x.Name == author.Name);
            createdAuthor.Should().NotBeNull();
            createdAuthor.LastName.Should().Be(author.LastName);
            createdAuthor.BirthDate.Should().Be(author.BirthDate);

        }
    }
}
