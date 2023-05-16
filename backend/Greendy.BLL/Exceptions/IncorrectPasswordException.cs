using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Greendy.BLL.Exceptions
{
    public class IncorrectPasswordException : ArgumentException
    {
        public IncorrectPasswordException() : base()
        {
        }

        public IncorrectPasswordException(string? message) : base(message)
        {
        }

        public IncorrectPasswordException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public IncorrectPasswordException(string? message, string? paramName) : base(message, paramName)
        {
        }

        public IncorrectPasswordException(string? message, string? paramName, Exception? innerException) : base(message, paramName, innerException)
        {
        }
    }
}