using RentCar.Data.Request;

namespace RentCar.Data.Response
{
    public class VehicleResponse
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; } = null!;
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; } = 2002;

        public string CodigoDescripcion => $"{Make} {Model} {Year}";
        public VehicleRequest ToRequest()
        {
            return new VehicleRequest()
            {
                Id = Id,
                PlateNumber = PlateNumber,
                Make = Make,
                Model = Model,
                Year = Year
            };
        }
    }
}
