using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cohorts_Hw3.Business.Abstract
{
    public interface ILoggerService
    {
        public void Write(string message);
    }
}
