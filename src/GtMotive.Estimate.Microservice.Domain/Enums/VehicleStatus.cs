namespace GtMotive.Estimate.Microservice.Domain.Enums
{
    /// <summary>
    /// Represents the current status of a vehicle. The status of a vehicle can change over time and can be used to track the vehicle's availability for use.
    /// For example, a vehicle may be available for rent, currently rented out to a customer, or in maintenance.
    /// This enumeration is used to categorize vehicles in a way that can be useful for various features of the application,
    /// such as filtering vehicles by status or determining the appropriate actions to take with a vehicle based on its status.
    /// </summary>
    public enum VehicleStatus
    {
        /// <summary>
        /// The vehicle is available for use. This could mean that the vehicle is available for rent, or that it is available for a customer to pick up.
        /// </summary>
        Available,

        /// <summary>
        /// The vehicle is currently rented out to a customer. During this time, the vehicle is not available for use by other customers.
        /// </summary>
        Rented,

        /// <summary>
        /// The vehicle is currently in maintenance. This could mean that the vehicle is undergoing routine maintenance, or that it is being repaired after a breakdown.
        /// </summary>
        InMaintenance
    }
}
