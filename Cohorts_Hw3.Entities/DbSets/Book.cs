using Cohorts_Hw3.Entities.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cohorts_Hw3.Entities.DbSets
{
    public class Book:BaseEntity
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
    }
}
