using Cohorts_Hw3.DataAccess.Context;
using Cohorts_Hw3.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cohorts_Hw3.UnitTest.Application.TestSetup.Data
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
            context.Books.AddRange(
                new Book { Id = 1, Title = "Lean Startup", GenreId = 1, PageCount = 250, PublishDate = new DateTime(2001, 10, 12), AuthorId = 1 },
               new Book { Id = 2, Title = "Herland", GenreId = 1, PageCount = 250, PublishDate = new DateTime(2011, 05, 12), AuthorId = 2 },
                new Book { Id = 3, Title = "Dune", GenreId = 2, PageCount = 540, PublishDate = new DateTime(2001, 12, 12), AuthorId = 2 });
        }
    }
}
