using System;

namespace GtMotive.Estimate.Microservice.Domain.Common
{
    /// <summary>
    /// Represents a base class for entities and aggregates.
    /// </summary>
    public abstract class EntityBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBase"/> class and sets its <see cref="Id"/> as new value of type Guid.
        /// </summary>
        protected EntityBase()
        {
            // Generate a new Guid for the Id property
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Gets or sets the unique identifier of the entity.
        /// </summary>
        public virtual Guid Id { get; protected set; }
    }
}
