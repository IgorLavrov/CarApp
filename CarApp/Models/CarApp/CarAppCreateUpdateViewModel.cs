namespace CarApp.Models.CarApp
{
    public class CarAppCreateUpdateViewModel
    {
        public Guid? Id { get; set; }
        public string Owner { get; set; }
        public string RegistrationNumber { get; set; }
        public string VinNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string TypeOfFuel { get; set; }
        public int EngineCapacity { get; set; }
        public int NumberOfCarDoors { get; set; }
        public int CarWeight { get; set; }
        public DateTime BuiltAt { get; set; }
        public DateTime RegistratedAt { get; set; }


    }
}
