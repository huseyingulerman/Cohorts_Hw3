﻿using Cohorts_Hw3.Api.Validator.Genre;
using Cohorts_Hw3.DataAccess.Context;
using Cohorts_Hw3.UnitTest.Application.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cohorts_Hw3.UnitTest.Application.GenreOperations.Commands.UpdateGenreCommands
{
    public class UpdateGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _dbContext;

        public UpdateGenreCommandTests(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
        }
        [Fact]
        public void WhenTheUpdateGenreIsNotFoundWithTheGivenId_InvalidOperationException_ShouldBeReturn()
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_dbContext);
            var genre = _dbContext.Genres.OrderByDescending(x => x.Id).FirstOrDefault();
            UpdateGenreModel model = new UpdateGenreModel()
            {
                Name="Poem"
            };
            command.GenreId = genre.Id + 1;
            command.Model = model;

            FluentActions.Invoking(() => command.Handle())
              .Should().Throw<InvalidOperationException>()
              .And.Message.Should().Be("Kitap türü bulunamadı.");

        }
        [Fact]
        public void WhenAlreadyExistGenreIsGiven_InvalidOperationException_ShouldBeReturn()
        {

            UpdateGenreCommand command = new UpdateGenreCommand(_dbContext);
            var genre = _dbContext.Genres.OrderBy(x => x.Id).FirstOrDefault();
            command.GenreId = genre.Id;
            command.Model = new UpdateGenreModel() { Name=genre.Name };

            FluentActions.Invoking(() => command.Handle())
              .Should().Throw<InvalidOperationException>()
              .And.Message.Should().Be("Aynı isimli bir kitap türü zaten mevcut.");
        }
        [Fact]
        public void WhenValidInputsAreGiven_Genre_ShouldBeUpdated()
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_dbContext);
            var genre = _dbContext.Genres.OrderBy(x => x.Id).FirstOrDefault();
            command.GenreId = genre.Id;
            UpdateGenreModel model = new UpdateGenreModel() { Name="Poem" };
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var updatedGenre = _dbContext.Genres.SingleOrDefault(x => x.Id == genre.Id);
            updatedGenre.Should().NotBeNull();
            updatedGenre.Name.Should().Be(model.Name);

        }
    }
}
