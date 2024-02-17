using RentCar.Data.Request;

namespace RentCar.Data.Response
{
    public class CustomerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Email { get; set; }

        public CustomerRequest ToRequest()
        {
            return new CustomerRequest()
            {
                Id = Id,
                Name = Name,
                PhoneNumber = PhoneNumber,
                Email = Email
            };
        }
    }
}
