namespace GtMotive.Estimate.Microservice.Domain.Enums
{
    /// <summary>
    /// Represents the type of fuel that a vehicle uses. The type of fuel a vehicle uses can have a significant impact on its performance,
    /// fuel efficiency, and environmental impact. For example, diesel and gasoline vehicles often have higher fuel efficiency than electric vehicles,
    /// but they also produce more emissions. Hybrid vehicles use a combination of gasoline and electric power, which can provide a balance of efficiency and lower emissions.
    /// Plug-in hybrids can be recharged by plugging into an external source of electric power, as well as by the vehicle's on-board engine and generator.
    /// </summary>
    public enum FuelType
    {
        /// <summary>
        /// Diesel fuel is a type of fuel that is used in diesel engines. It is more efficient and produces more torque than gasoline, but it also produces more emissions.
        /// </summary>
        Diesel,

        /// <summary>
        /// Gasoline is the most common type of fuel used in vehicles. It is less efficient than diesel, but it produces fewer emissions.
        /// </summary>
        Gasoline,

        /// <summary>
        /// Electric vehicles use electricity as their fuel. They produce zero emissions at the tailpipe, but they require charging infrastructure and have a limited range.
        /// </summary>
        Electric,

        /// <summary>
        /// Plug-in hybrid vehicles can use both gasoline and electricity as their fuel. They can be plugged in to charge the battery, and they can also use gasoline when the battery is depleted.
        /// </summary>
        PlugInHybrid,

        /// <summary>
        /// Hybrid vehicles use a combination of gasoline and electric power. They cannot be plugged in to charge the battery, but they can generate electricity through regenerative braking and by running the engine.
        /// </summary>
        Hybrid
    }
}
