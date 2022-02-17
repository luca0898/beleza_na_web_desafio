using System;
using System.Net;

namespace BelezanaWeb.SystemObjects.Exceptions
{
    public class BelezanaWebApplicationException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public BelezanaWebApplicationException(
            string message,
            HttpStatusCode statusCode = HttpStatusCode.BadRequest
            ) : base(message)
        {
            StatusCode = statusCode;
        }

        public BelezanaWebApplicationException(
            string message,
            Exception exception,
            HttpStatusCode statusCode = HttpStatusCode.BadRequest
            ) : base(message, exception)
        {
            StatusCode = statusCode;
        }
    }
}
