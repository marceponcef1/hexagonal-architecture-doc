using System;
using System.Diagnostics.CodeAnalysis;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// Exception thrown when a rental is not found.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class RentalNotFoundException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentalNotFoundException"/> class.
        /// </summary>
        public RentalNotFoundException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RentalNotFoundException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public RentalNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RentalNotFoundException"/> class.
        /// </summary>
        /// <param name="rentalId">The ID of the rental that was not found.</param>
        public RentalNotFoundException(Guid rentalId)
            : base($"Rental with ID {rentalId} was not found.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RentalNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public RentalNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RentalNotFoundException"/> class.
        /// </summary>
        /// <param name="serializationInfo">The System.Runtime.Serialization.SerializationInfo that holds the serialized object data about the exception being thrown.</param>
        /// <param name="streamingContext">The System.Runtime.Serialization.StreamingContext that contains contextual information about the source or destination.</param>
        protected RentalNotFoundException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}
