using AutoMapper;
using Cohorts_Hw3.DataAccess.Context;

namespace Cohorts_Hw3.Api.Aplications.GenreOperations.Queries
{
    public class GetGenreQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetGenreQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GenreViewModel> Handle()
        {
            var genres = _context.Genres.Where(x => x.IsActive==true).OrderBy(x => x.Id);
            List<GenreViewModel> returnObj = _mapper.Map<List<GenreViewModel>>(genres);
            return returnObj;
        }
    }
    public class GenreViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
