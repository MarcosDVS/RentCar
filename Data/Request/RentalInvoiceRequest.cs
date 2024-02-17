using RentCar.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace RentCar.Data.Request
{
    public class RentalInvoiceRequest
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? VehicleId { get; set; }
        [Required(ErrorMessage = "Seleccionar la fecha de renta es obligatoria")]
        public DateTime RentalDate { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Seleccionar la fecha de devolución es obligatoria")]
        public DateTime ReturnDate { get; set; } = DateTime.Now.AddDays(+2);
        [Required(ErrorMessage = "Fijar un precio por día es obligatoria")]
        public decimal PriceDay { get; set; } = 1500; 
        public decimal TotalAmount { get; set; } = 3000;
    }
}
