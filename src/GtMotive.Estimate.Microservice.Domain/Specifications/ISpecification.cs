namespace GtMotive.Estimate.Microservice.Domain.Specifications
{
    /// <summary>
    /// Represents a business rule that an entity must satisfy.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public interface ISpecification<in T>
    {
        /// <summary>
        /// Checks if the entity satisfies the specification.
        /// </summary>
        /// <param name="entity">The entity to check.</param>
        /// <returns>True if the entity satisfies the specification, false otherwise.</returns>
        bool IsSatisfiedBy(T entity);
    }
}
