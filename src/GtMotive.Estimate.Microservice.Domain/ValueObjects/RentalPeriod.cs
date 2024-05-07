using System;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    /// <summary>
    /// Represents a rental period.
    /// </summary>
    public class RentalPeriod
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentalPeriod"/> class.
        /// </summary>
        /// <param name="startDate">The start date of the rental period.</param>
        /// <param name="endDate">The end date of the rental period.</param>
        public RentalPeriod(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
            {
                throw new ArgumentException("End date must be after start date.");
            }

            StartDate = startDate;
            EndDate = endDate;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RentalPeriod"/> class.
        /// Represents a rental period in the system.
        /// </summary>
        private RentalPeriod()
        {
        }

        /// <summary>
        /// Gets the start date of the rental period.
        /// </summary>
        public DateTime StartDate { get; }

        /// <summary>
        /// Gets the end date of the rental period.
        /// </summary>
        public DateTime EndDate { get; }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return obj is RentalPeriod other && StartDate == other.StartDate && EndDate == other.EndDate;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(StartDate, EndDate);
        }
    }
}
