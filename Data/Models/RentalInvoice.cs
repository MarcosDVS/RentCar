using RentCar.Data.Request;
using RentCar.Data.Response;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCar.Data.Models
{ 
    // Modelo de Factura de Renta de Vehículo
    public class RentalInvoice
    {
        [Key]
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer? Customer { get; set; }
        public int? VehicleId { get; set; }
        [ForeignKey("VehicleId")]
        public virtual Vehicle? Vehicle { get; set; }
        public DateTime RentalDate { get; set; } = DateTime.Now;
        public DateTime ReturnDate { get; set; } = DateTime.Now.AddDays(+2);
        public decimal PriceDay { get; set; } = 1500;
        public decimal TotalAmount { get; set; }

        public static RentalInvoice Crear(RentalInvoiceRequest invoice) => new RentalInvoice()
        {
            CustomerId = invoice.CustomerId,
            VehicleId = invoice.VehicleId,
            RentalDate = invoice.RentalDate,
            ReturnDate = invoice.ReturnDate,
            PriceDay = invoice.PriceDay,
            TotalAmount = invoice.TotalAmount
        };
        public bool Modificar(RentalInvoiceRequest rentalInvoice)
        {
            var cambio = false;
            if (CustomerId != rentalInvoice.CustomerId) CustomerId = rentalInvoice.CustomerId; cambio = true;
            if (VehicleId != rentalInvoice.VehicleId) VehicleId = rentalInvoice.VehicleId; cambio = true;
            if (RentalDate != rentalInvoice.RentalDate) RentalDate = rentalInvoice.RentalDate; cambio = true;
            if (ReturnDate != rentalInvoice.ReturnDate) ReturnDate = rentalInvoice.ReturnDate; cambio = true;
            if (PriceDay != rentalInvoice.PriceDay) PriceDay = rentalInvoice.PriceDay; cambio = true;
            if (TotalAmount != rentalInvoice.TotalAmount) TotalAmount = rentalInvoice.TotalAmount; cambio = true;

            return cambio;
        }
        public RentalInvoiceResponse ToResponse() => new()
        {
            Id = Id,
            CustomerId = CustomerId,
            Customer = Customer != null? Customer!.ToResponse(): null,
            VehicleId = VehicleId,
            Vehicle = Vehicle != null? Vehicle!.ToResponse() : null,
            RentalDate = RentalDate,
            ReturnDate = ReturnDate,
            PriceDay = PriceDay,
            TotalAmount = TotalAmount
        };
    }

}
