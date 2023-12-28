﻿using AutoMapper;
using Cohorts_Hw3.Api.Aplications.BookOperations.Queries;
using Cohorts_Hw3.DataAccess.Context;
using Cohorts_Hw3.UnitTest.Application.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cohorts_Hw3.UnitTest.Application.BookOperations.Query.GetBookDetailQueries
{
    public class GetBookDetailQueriesTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBookDetailQueriesTests(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenTheBookIsNotFoundWithTheGivenId_InvalidOperationException_ShouldBeReturn()
        {
            GetByIdQuery query = new GetByIdQuery(_dbContext, _mapper);
            var book = _dbContext.Books.OrderByDescending(x => x.Id).FirstOrDefault();
            query.Id = book.Id + 1;

            FluentActions.Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("İlgili id ile bir kitap bulunamadı.");

        }
        [Fact]
        public void WhenFoundTheBookWithTheGivenId_Book_ShouldBeGet()
        {
            GetByIdQuery query = new GetByIdQuery(_dbContext, _mapper);
            var book = _dbContext.Books.OrderBy(x => x.Id).FirstOrDefault();
            query.Id = book.Id;

            var getBook = FluentActions.Invoking(() => query.Handle()).Invoke();

            getBook.Should().NotBeNull();
            getBook.PageCount.Should().Be(book.PageCount);
            getBook.Title.Should().Be(book.Title);
            getBook.Author.Should().Be(book.Author.ToString());
            getBook.Genre.Should().Be(book.Genre.ToString());

        }
    }
}
