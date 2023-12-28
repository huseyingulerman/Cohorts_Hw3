﻿using Cohorts_Hw3.DataAccess.Context;
using Cohorts_Hw3.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cohorts_Hw3.UnitTest.Application.TestSetup.Data
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext context)
        {
            context.Authors.AddRange(
                new Author { Name = "John", LastName = "Doe", BirthDate = new DateTime(1998, 02, 16) },
                new Author { Name = "Jeyn", LastName = "Doe", BirthDate = new DateTime(2007, 01, 24) },
                new Author { Name = "Tom", LastName = "Doe", BirthDate = new DateTime(1972, 08, 02) });
        }
    }
}
