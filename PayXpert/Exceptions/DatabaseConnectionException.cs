﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Exceptions
{
    internal class DatabaseConnectionException : ApplicationException
    {

        public DatabaseConnectionException() { }

        public DatabaseConnectionException(string message) : base(message) { }
    }
}
