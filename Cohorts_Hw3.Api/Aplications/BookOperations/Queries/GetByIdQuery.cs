using AutoMapper;
using Cohorts_Hw3.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace Cohorts_Hw3.Api.Aplications.BookOperations.Queries
{
    public class GetByIdQuery
    {
        public int Id { get; set; }


        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetByIdQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public BooksViewModel Handle()
        {
            var book = _dbContext.Books.Include(x => x.Genre).Where(x => x.Id==Id).SingleOrDefault();
            if (book == null)
                throw new InvalidOperationException("İlgili id ile bir kitap bulunamadı.");

            BooksViewModel vm = _mapper.Map<BooksViewModel>(book);
            return vm;
        }

        public class BooksViewModel
        {
            public string Title { get; set; }
            public string Genre { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string Author { get; set; }
        }
    }
}

