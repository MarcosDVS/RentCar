using RentCar.Data.Models;
using RentCar.Data.Request;

namespace RentCar.Data.Response
{
    public class RentalInvoiceResponse
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public CustomerResponse? Customer { get; set; }
        public int? VehicleId { get; set; }
        public VehicleResponse? Vehicle { get; set; }
        public DateTime RentalDate { get; set; } = DateTime.Now;
        public DateTime ReturnDate { get; set; } = DateTime.Now.AddDays(+2);
        public decimal PriceDay { get; set; } = 1500;
        public decimal TotalAmount => (decimal)RentedDays * PriceDay;

        public int RentedDays => (int)(ReturnDate - RentalDate).TotalDays;
        public decimal ITBIS => TotalAmount * 0.18m;

        public string NombreCustomerTexto => Customer != null ? Customer.Name : "N/A";
        public string NombreVehicleTexto => Vehicle != null ? Vehicle.Make +" " + Vehicle.Model +" " + Vehicle.Year : "N/A";

        public RentalInvoiceRequest ToRequest()
        {
            return new RentalInvoiceRequest
            {
                Id = Id,
                CustomerId = CustomerId,
                VehicleId = VehicleId,
                RentalDate = RentalDate,
                ReturnDate = ReturnDate,
                PriceDay = PriceDay
            };
        }
    }
}
