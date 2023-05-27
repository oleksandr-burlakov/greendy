using System.Runtime.Serialization;

namespace Greendy.BLL.Exceptions
{
    public class IncorrectTrackStorageNameException : Exception
    {
        public IncorrectTrackStorageNameException()
        {
        }

        public IncorrectTrackStorageNameException(string? message) : base(message)
        {
        }

        public IncorrectTrackStorageNameException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected IncorrectTrackStorageNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
