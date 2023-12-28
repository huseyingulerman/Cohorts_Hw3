using Cohorts_Hw3.DataAccess.Context;
using Cohorts_Hw3.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cohorts_Hw3.UnitTest.Application.TestSetup.Data
{
    public static class Genres
    {
        public static void AddGenres(this BookStoreDbContext context)
        {
            context.Genres.AddRange(
           new Genre { Name = "Personal Growth" },
           new Genre { Name = "Science Fiction" },
           new Genre { Name = "Romance" });
        }
    }
}
