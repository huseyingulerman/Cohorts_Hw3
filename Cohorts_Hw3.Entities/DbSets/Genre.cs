using Cohorts_Hw3.Entities.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cohorts_Hw3.Entities.DbSets
{
    public class Genre:BaseEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
        public List<Genre> Books { get; set; }
    }
}
