using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Exceptions
{
    internal class InvalidException : ApplicationException
    {
        public InvalidException() { }

        public InvalidException(string message) : base(message) { }

    }
}
