using RentCar.Data.Request;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RentCar.Data.Response
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;

        public UserRequest ToRequest()
		{
			return new UserRequest
			{
				Id = Id,
				Name = Name,
				Username = Username,
				Password = Password,
				Role = Role
			};
		}
	}
}
