using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// Exception that is thrown when a fleet is not found.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class FleetNotFoundException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FleetNotFoundException"/> class.
        /// </summary>
        public FleetNotFoundException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FleetNotFoundException"/> class.
        /// </summary>
        /// <param name="fleetId">The ID of the fleet that was not found.</param>
        public FleetNotFoundException(Guid fleetId)
            : base($"Fleet with ID {fleetId} was not found.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FleetNotFoundException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public FleetNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FleetNotFoundException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public FleetNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FleetNotFoundException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The System.Runtime.Serialization.SerializationInfo that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The System.Runtime.Serialization.StreamingContext that contains contextual information about the source or destination.</param>
        protected FleetNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
