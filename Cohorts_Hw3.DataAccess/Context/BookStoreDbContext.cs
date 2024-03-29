﻿using Cohorts_Hw3.Entities.DbSets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cohorts_Hw3.DataAccess.Context
{
    public class BookStoreDbContext:DbContext, IBookStoreDbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
            
        }
        public DbSet<Book>   Books   { get; set; }
        public DbSet<Genre>   Genres   { get; set; }
        public DbSet<Author>   Authors   { get; set; }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
