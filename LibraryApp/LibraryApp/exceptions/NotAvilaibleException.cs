using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.exceptions
{
    internal class NotAvilaibleException : Exception
    {
        public NotAvilaibleException(string message = "Error") : base(message) { }
    }
}
