using AutoMapper;
using Cohorts_Hw3.Api.Aplications.AuthorOperations.Commands;
using Cohorts_Hw3.Api.Aplications.AuthorOperations.Queries;
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
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<UpdateBookModel, Book>();

            CreateMap<Genre, GenreViewModel>();
            CreateMap<Genre, GenresViewModel>();

            CreateMap<Author, AuthorViewModel>();
            CreateMap<AddAuthorViewModel, Author>();
            CreateMap<Author, AuthorDetailViewModel>();
        }
    }
}
