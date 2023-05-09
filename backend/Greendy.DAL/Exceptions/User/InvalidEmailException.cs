using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Greendy.DAL.Exceptions.User
{
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException() : base()
        {
        }

        public InvalidEmailException(string? message) : base(message)
        {
        }

        public InvalidEmailException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}