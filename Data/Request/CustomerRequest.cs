using System.ComponentModel.DataAnnotations;

namespace RentCar.Data.Request
{
    public class CustomerRequest
    {
        public int Id { get; set; }
        [MaxLength(20, ErrorMessage = "El nombre no puede superar las 20 letras"), MinLength(3, ErrorMessage = "El nombre no puede tener menos de tres letras"), Required(ErrorMessage = "El nombre del cliente es obligatorio")]
        public string Name { get; set; } = null!;
        [MaxLength(12),MinLength(10, ErrorMessage ="Falta un número"), Required(ErrorMessage = "El número telefonico es obligatorio")]
        public string PhoneNumber { get; set; } = null!;
        public string? Email { get; set; }
    }
}
