using Cohorts_Hw3.DataAccess.Context;

namespace Cohorts_Hw3.Api.Aplications.BookOperations.Command
{
    public class UpdateBookCommand
    {
        public int Id { get; set; }
        public UpdateBookModel Model { get; set; }

        private readonly BookStoreDbContext _dbContext;
        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var book = _dbContext.Books.Find(Id);
            if (book == null)
            {
                throw new ArgumentNullException("Belirtilen ID ile bir kayıt bulunamadı.");

            }

            book.Title = Model.Title != default ? Model.Title : book.Title;
            book.Genre.Name = Model.Genre != default ? Model.Genre : book.Genre.Name;
            book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
            book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;
            _dbContext.Update(book);
            _dbContext.SaveChanges();
        }
        public class UpdateBookModel
        {
            public string Title { get; set; }
            public string Genre { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}
