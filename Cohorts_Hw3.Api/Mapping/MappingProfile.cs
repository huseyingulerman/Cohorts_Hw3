using AutoMapper;
using Cohorts_Hw3.Api.Aplications.AuthorOperations.Commands;
using Cohorts_Hw3.Api.Aplications.AuthorOperations.Queries;
using Cohorts_Hw3.Api.Aplications.BookOperations.Command;
using Cohorts_Hw3.Api.Aplications.BookOperations.Queries;
using Cohorts_Hw3.Api.Aplications.GenreOperations.Queries;
using Cohorts_Hw3.Entities.DbSets;
using static Cohorts_Hw3.Api.Aplications.BookOperations.Command.UpdateBookCommand;
using static Cohorts_Hw3.Api.Aplications.BookOperations.Queries.GetByIdQuery;

namespace Cohorts_Hw3.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BooksViewModel>();
            CreateMap<UpdateBookModel, Book>();
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BooksModel>();

            CreateMap<Genre, GenreViewModel>();
            CreateMap<Genre, GenresViewModel>();

            CreateMap<Author, AuthorViewModel>();
            CreateMap<AddAuthorViewModel, Author>();
            CreateMap<Author, AuthorDetailViewModel>();
        }
    }
}
