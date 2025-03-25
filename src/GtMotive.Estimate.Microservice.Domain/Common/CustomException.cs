using System;

namespace GtMotive.Estimate.Microservice.Domain.Common
{
    /// <summary>
    /// CustomException.
    /// </summary>
    public class CustomException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomException"/> class.
        /// CustomException.
        /// </summary>
        /// <param name="message">string.</param>
        public CustomException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomException"/> class.
        /// </summary>
        /// <param name="message">string.</param>
        /// <param name="innerException">exception.</param>
        public CustomException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomException"/> class.
        /// </summary>
        public CustomException()
        {
        }
    }
}
