using System.ComponentModel.DataAnnotations;

namespace RentCar.Data.Request
{
    public class CustomerRequest
    {
        public int Id { get; set; }
        public string Cedula { get; set; } = null!;
        [MinLength(3, ErrorMessage = "El nombre no puede tener menos de tres letras"), Required(ErrorMessage = "El nombre del cliente es obligatorio")]
        public string Name { get; set; } = null!;
        [MaxLength(10, ErrorMessage ="Demaciados digitos"),MinLength(10, ErrorMessage ="Faltan números"), Required(ErrorMessage = "El número telefonico es obligatorio")]
        public string PhoneNumber { get; set; } = null!;
        public string? Email { get; set; }
    }
}
