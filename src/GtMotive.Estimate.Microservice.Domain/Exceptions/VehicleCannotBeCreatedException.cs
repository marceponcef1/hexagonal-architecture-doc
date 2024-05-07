using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// Exception that is thrown when a vehicle cannot be created.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class VehicleCannotBeCreatedException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleCannotBeCreatedException"/> class.
        /// </summary>
        public VehicleCannotBeCreatedException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleCannotBeCreatedException"/> class.
        /// </summary>
        /// <param name="vin">The the vehicle with this VIN cannot be created.</param>
        public VehicleCannotBeCreatedException(string vin)
            : base($"Vehicle with VIM '{vin}' cannot be created because it has a manufacture date older than 5 years.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleCannotBeCreatedException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the curbe created exception, or a null reference if no inner exception is specified.</param>
        public VehicleCannotBeCreatedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleCannotBeCreatedException"/> class.
        /// </summary>
        /// <param name="serializationInfo">The System.Runtime.Serialization.SerializationInfo that holds the serialized object data about the exception being thrown.</param>
        /// <param name="streamingContext">The System.Runtime.Serialization.StreamingContext that contains contextual information about the source or destination.</param>
        protected VehicleCannotBeCreatedException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}
