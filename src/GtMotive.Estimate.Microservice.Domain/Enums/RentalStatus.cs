namespace GtMotive.Estimate.Microservice.Domain.Enums
{
    /// <summary>
    /// Represents the status of a rental transaction. The status of a rental can change over time and can be used to track the progress of the rental.
    /// </summary>
    public enum RentalStatus
    {
        /// <summary>
        /// The rental is pending. This is the initial status of a rental when it is first created. The vehicle is reserved for the customer, but the rental period has not yet started.
        /// </summary>
        Pending,

        /// <summary>
        /// The rental is active. This status indicates that the rental period has started and the vehicle is currently being rented by the customer.
        /// </summary>
        Active,

        /// <summary>
        /// The rental is completed. This status indicates that the rental period has ended and the vehicle has been returned by the customer.
        /// </summary>
        Completed
    }
}
