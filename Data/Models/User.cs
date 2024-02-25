using RentCar.Data.Request;
using RentCar.Data.Response;
using System.ComponentModel.DataAnnotations;

namespace RentCar.Data.Models
{
    // Modelo de Usuario
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Username { get; set; } = null!;
		public string Password { get; set; } = null!;
		public string Role { get; set; } = null!;

		public static User Crear(UserRequest user) => new User()
        {
            Name = user.Name,
            Username = user.Username,
            Password = user.Password,
            Role = user.Role
        };
        public bool Modificar(UserRequest user)
        {
            var cambio = false;
            if (Name != user.Name) Name = user.Name; cambio = true;
            if (Username != user.Username) Username = user.Username; cambio = true;
            if (Password != user.Password) Password = user.Password; cambio = true;
            if (Role != user.Role) Role = user.Role; cambio = true;

            return cambio;
        }
        public UserResponse ToResponse() => new()
        {
            Id = Id,
            Name = Name,
            Username = Username,
            Password = Password,
            Role = Role
        };
    }

}
