using AutoMapper;
using Cohorts_Hw3.DataAccess.Context;

namespace Cohorts_Hw3.Api.Aplications.AuthorOperations.Queries
{
    public class GetAuthorQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAuthorQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<AuthorViewModel> Handle()
        {
            var author = _dbContext.Authors.OrderBy(x => x.Name);
            List<AuthorViewModel> viewModel = _mapper.Map<List<AuthorViewModel>>(author);
            return viewModel;
        }
    }
    public class AuthorViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
