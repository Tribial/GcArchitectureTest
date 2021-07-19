using System;
using Fabian.Domurad.Golden.Card.Research.Shared.Constant;
using Fabian.Domurad.Golden.Card.Research.Shared.Enum;

namespace Fabian.Domurad.Golden.Card.Research.Shared.CustomException
{
    public class BusinessLogicException : Exception
    {
        public ExceptionType Type { get; set; }

        public BusinessLogicException() : this(ErrorMessageConst.Default, ExceptionType.InternalServerError, null) { }
        public BusinessLogicException(string message) : this(message, ExceptionType.InternalServerError, null) { }
        public BusinessLogicException(string message, ExceptionType type) : this(message, type, null) { }

        public BusinessLogicException(Exception innerException) : this(innerException.Message,
            ExceptionType.InternalServerError, innerException) { }
        public BusinessLogicException(string message, ExceptionType type, Exception? innerException) : base(message, innerException)
        {
            Type = type;
        }
    }
}
