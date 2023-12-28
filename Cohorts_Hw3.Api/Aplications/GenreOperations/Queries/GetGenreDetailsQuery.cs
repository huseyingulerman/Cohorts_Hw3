using AutoMapper;
using Cohorts_Hw3.DataAccess.Context;

namespace Cohorts_Hw3.Api.Aplications.GenreOperations.Queries
{
    public class GetGenreDetailsQuery
    {
        public int Id { get; set; }

        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetGenreDetailsQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GenresViewModel Handle()
        {
            var genres = _context.Genres.SingleOrDefault(x => x.IsActive == true && x.Id==Id);
            if (genres == null)
            {
                throw new InvalidOperationException("Kitap Türü Bulunamadı.");
            }
            GenresViewModel returnObj = _mapper.Map<GenresViewModel>(genres);
            return returnObj;
        }
    }
    public class GenresViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
