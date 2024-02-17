using RentCar.Data.Request;
using RentCar.Data.Response;
using System.ComponentModel.DataAnnotations;

namespace RentCar.Data.Models
{
    // Modelo de Cliente
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Email { get; set; }

        public static Customer Crear(CustomerRequest user) => new Customer()
        {
            Name = user.Name,
            PhoneNumber = user.PhoneNumber,
            Email = user.Email
        };
        public bool Modificar(CustomerRequest customer)
        {
            var cambio = false;
            if (Name != customer.Name) Name = customer.Name; cambio = true;
            if (PhoneNumber != customer.PhoneNumber) PhoneNumber = customer.PhoneNumber; cambio = true;
            if (Email != customer.Email) Email = customer.Email; cambio = true;

            return cambio;
        }
        public CustomerResponse ToResponse() => new()
        {
            Id = Id,
            Name = Name,
            PhoneNumber = PhoneNumber,
            Email = Email
        };
    }

}
