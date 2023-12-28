using Cohorts_Hw3.DataAccess.Context;
using Cohorts_Hw3.Entities.DbSets;

namespace Cohorts_Hw3.Api.Aplications.AuthorOperations.Commands
{
    public class UpdateAuthorCommand
    {
        public UpdateAuthorViewModel Model { get; set; }
        public int Id { get; set; }

        private readonly BookStoreDbContext _dbContext;

        public UpdateAuthorCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var author = _dbContext.Authors.Find(Id);
            if (author == null)
                throw new InvalidOperationException("İlgili yazar bulunamadı.");

            if (_dbContext.Authors.Any(x => x.Name.ToLower() == Model.Name.ToLower()&&x.LastName.ToLower() ==Model.LastName.ToLower()))
                throw new InvalidOperationException("Aynı isimli yazar zaten mevcut");

            author = new Author();
            author.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? author.Name : Model.Name;
            author.LastName = string.IsNullOrEmpty(Model.LastName.Trim()) ? author.LastName : Model.LastName;
            author.BirthDate = string.IsNullOrEmpty(Model.BirthDate.ToString()) ? author.BirthDate : Model.BirthDate;

            _dbContext.SaveChanges();
        }
    }
    public class UpdateAuthorViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
