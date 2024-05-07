using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// Exception that is thrown when a customer cannot rent a vehicle.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class CustomerCannotRentException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCannotRentException"/> class.
        /// </summary>
        public CustomerCannotRentException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCannotRentException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public CustomerCannotRentException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCannotRentException"/> class.
        /// </summary>
        /// <param name="customerId">The ID of the customer who cannot rent a vehicle.</param>
        public CustomerCannotRentException(Guid customerId)
            : base($"Customer with ID={customerId} cannot rent a vehicle because they have an active rental.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCannotRentException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public CustomerCannotRentException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCannotRentException"/> class.
        /// </summary>
        /// <param name="serializationInfo">The System.Runtime.Serialization.SerializationInfo that holds the serialized object data about the exception being thrown.</param>
        /// <param name="streamingContext">The System.Runtime.Serialization.StreamingContext that contains contextual information about the source or destination.</param>
        protected CustomerCannotRentException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}
