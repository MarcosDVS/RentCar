using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCar.Data.Request
{
    public class VehicleRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El número de placa es obligatorio")]
        public string PlateNumber { get; set; } = null!;
        [Required(ErrorMessage = "La marca del vehiculo es obligatoria")]
        public string Make { get; set; } = null!;
        [Required(ErrorMessage = "El modelo del vehiculo es obligatorio")]
        public string Model { get; set; } = null!;
        [Required(ErrorMessage = "El año del vehiculo es obligatorio")]
        public int Year { get; set; } = 2002;
        public bool Rented { get; set; } = false;
    }
}
