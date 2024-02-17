using RentCar.Data.Request;

namespace RentCar.Data.Response
{
    public class EmployeeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Position { get; set; } = null!;

        public EmployeeRequest ToRequest()
        { 
            return new EmployeeRequest 
            { 
                Id = Id,
                Name = Name, 
                Position = Position 
            }; 
        }
    }
}
