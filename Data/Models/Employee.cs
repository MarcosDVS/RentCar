using RentCar.Data.Request;
using RentCar.Data.Response;
using System.ComponentModel.DataAnnotations;

namespace RentCar.Data.Models
{
    // Modelo de Empleado
    public class Employee
    {
       
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Position { get; set; } = null!;

        public static Employee Crear(EmployeeRequest employee) => new Employee()
        {
            Name = employee.Name,
            Position = employee.Position
        };
        public bool Modificar(EmployeeRequest employee)
        {
            var cambio = false;
            if (Name != employee.Name) Name = employee.Name; cambio = true;
            if (Position != employee.Position) Position = employee.Position; cambio = true;

            return cambio;
        }
        public EmployeeResponse ToResponse() => new()
        {
            Id = Id,
            Name = Name,
            Position = Position
        };
    }

}
