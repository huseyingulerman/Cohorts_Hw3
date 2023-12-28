using AutoMapper;
using Cohorts_Hw3.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace Cohorts_Hw3.Api.Aplications.BookOperations.Queries
{
    public class GetBookQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBookQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<BooksModel> Handle()
        {
            var books = _dbContext.Books.Include(x => x.Genre).Include(x => x.Author).OrderBy(x => x.Title);
            List<BooksModel> booksModel = _mapper.Map<List<BooksModel>>(books);
            return booksModel;
        }
    }
    public class BooksModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Author { get; set; }
    }
}
