using RentCar.Data.Request;
using RentCar.Data.Response;
using System.ComponentModel.DataAnnotations;

namespace RentCar.Data.Models
{
    // Modelo de Vehículo
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public string PlateNumber { get; set; } = null!;
		public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; } = 2002;
        public bool Rented { get; set; } = false;

        public static Vehicle Crear(VehicleRequest user) => new Vehicle()
        {
            PlateNumber = user.PlateNumber,
            Make = user.Make,
            Model = user.Model,
            Year = user.Year,
            Rented = user.Rented
        };
        public bool Modificar(VehicleRequest vehicle)
        {
            var cambio = false;
            if (PlateNumber != vehicle.PlateNumber) PlateNumber = vehicle.PlateNumber; cambio = true;
            if (Make != vehicle.Make) Make = vehicle.Make; cambio = true;
            if (Model != vehicle.Model) Model = vehicle.Model; cambio = true;
            if (Year != vehicle.Year) Year = vehicle.Year; cambio = true;
            if (Rented != vehicle.Rented) Rented = vehicle.Rented; cambio = true;

            return cambio;
        }
        public VehicleResponse ToResponse() => new()
        {
            Id = Id,
            PlateNumber = PlateNumber,
            Make = Make,
            Model = Model,
            Year = Year,
            Rented = Rented
        };
    }

}
