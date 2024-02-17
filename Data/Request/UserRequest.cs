using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCar.Data.Request
{
    public class UserRequest
    {
        public int Id { get; set; }
        [MaxLength(20, ErrorMessage = "El nombre no puede superar las 20 letras"), MinLength(3, ErrorMessage = "El nombre no puede tener menos de tres letras"), Required(ErrorMessage = "El nombre del usuario es obligatorio")]
        public string Name { get; set; } = null!;
        [EmailAddress(ErrorMessage = "Esto no es un correo valido"), Required(ErrorMessage = "El correo del usuario es obligatorio")]
        public string Username { get; set; } = null!;
        [MaxLength(12, ErrorMessage = "La clave no puede tener mas de 12 digitos"), MinLength(8, ErrorMessage = "La clave no puede tener menos de 8 digitos"), Required(ErrorMessage = "La clave del usuario es obligatoria")]
        public string Password { get; set; } = null!;
    }
}
