using Cohorts_Hw3.DataAccess.Context;

namespace Cohorts_Hw3.Api.Aplications.BookOperations.Command
{
    public class DeleteBookCommand
    {
        public int Id { get; set; }

        private readonly BookStoreDbContext _dbContext;
        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.Find(Id);
            if (book is null)
            {
                throw new InvalidDataException("Verilen id'de bir kitap yoktur.");
            }
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
    }
}
