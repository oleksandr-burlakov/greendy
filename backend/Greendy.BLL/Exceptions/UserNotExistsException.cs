using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Greendy.BLL.Exceptions
{
    public class UserNotExistsException : ArgumentException
    {
        public UserNotExistsException() : base()
        {
        }

        public UserNotExistsException(string? message) : base(message)
        {
        }

        public UserNotExistsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public UserNotExistsException(string? message, string? paramName) : base(message, paramName)
        {
        }

        public UserNotExistsException(string? message, string? paramName, Exception? innerException) : base(message, paramName, innerException)
        {
        }
    }
}