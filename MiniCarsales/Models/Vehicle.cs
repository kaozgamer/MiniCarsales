namespace MiniCarsales.Models
{
    public class Vehicle
    {
        /// <summary>
        /// The id of the vehicle
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Type of vehicle.
        /// </summary>
        public VehicleType Type { get; set; }

        /// <summary>
        /// The make of this vehicle.
        /// </summary>
        public string Make { get; set; }

        /// <summary>
        /// The model of this vehicle.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// The engine used in this vehicle.
        /// </summary>
        public string Engine { get; set; }
    }
}
