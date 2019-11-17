namespace MiniCarsales.Models
{
    public class Car : Vehicle
    {
        /// <summary>
        /// The number of doors on this car.
        /// </summary>
        public int NumberOfDoors { get; set; }

        /// <summary>
        /// Number of wheels on this car.
        /// </summary>
        public int NumberOfWheels { get; set; }

        /// <summary>
        /// The body type of this car.
        /// </summary>
        public CarBodyType BodyType { get; set; }
    }
}
