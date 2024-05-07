using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// Exception that is thrown when a vehicle already exists in the fleet.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class VehicleAlreadyExistsException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleAlreadyExistsException"/> class.
        /// </summary>
        public VehicleAlreadyExistsException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleAlreadyExistsException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public VehicleAlreadyExistsException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleAlreadyExistsException"/> class.
        /// </summary>
        /// <param name="vehicleId">The ID of the vehicle that already exists.</param>
        public VehicleAlreadyExistsException(Guid vehicleId)
            : base($"Vehicle with ID={vehicleId} already exists.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleAlreadyExistsException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public VehicleAlreadyExistsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleAlreadyExistsException"/> class.
        /// </summary>
        /// <param name="serializationInfo">The System.Runtime.Serialization.SerializationInfo that holds the serialized object data about the exception being thrown.</param>
        /// <param name="streamingContext">The System.Runtime.Serialization.StreamingContext that contains contextual information about the source or destination.</param>
        protected VehicleAlreadyExistsException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}
