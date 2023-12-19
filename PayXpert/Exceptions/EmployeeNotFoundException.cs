using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Exceptions
{
    internal class EmployeeNotFoundException : ApplicationException
    {

        public EmployeeNotFoundException() { }

        public EmployeeNotFoundException(String msg) : base(msg) { }

    }
}
