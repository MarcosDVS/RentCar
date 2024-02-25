using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCar.Data.Request
{
    public class EmployeeRequest
    {
        public int Id { get; set; }
        [MinLength(3, ErrorMessage = "El nombre no puede tener menos de tres letras"), Required(ErrorMessage = "El nombre del empleado es obligatorio")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "La posición del empleado es obligatoria")]
        public string Position { get; set; } = null!;
        public decimal Salary { get; set; }
    }
}
