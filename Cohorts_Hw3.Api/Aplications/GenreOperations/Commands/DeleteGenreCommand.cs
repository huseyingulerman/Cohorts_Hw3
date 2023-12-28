using Cohorts_Hw3.DataAccess.Context;

namespace Cohorts_Hw3.Api.Aplications.GenreOperations.Commands
{
    public class DeleteGenreCommand
    {
        public int Id { get; set; }

        private readonly BookStoreDbContext _dbContext;

        public DeleteGenreCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x => x.Id==Id);
            if (genre == null)
            {
                throw new InvalidOperationException("Kitap türü bulunamadı");
            }
            _dbContext.Genres.Remove(genre);
            _dbContext.SaveChanges();
        }
    }
}
