using Microsoft.EntityFrameworkCore;
using RentCar.Data.Context;
using RentCar.Data.Models;
using RentCar.Data.Request;
using RentCar.Data.Response;

namespace RentCar.Data.Services
{
    public class RentalInvoiceServices : IRentalInvoiceServices
    {
        private readonly IRentCarDbContext dbContext;

        public RentalInvoiceServices(IRentCarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result> Crear(RentalInvoiceRequest request)
        {
            try
            {
                var rentalInvoice = RentalInvoice.Crear(request);
                dbContext.Invoices.Add(rentalInvoice);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result> Modificar(RentalInvoiceRequest request)
        {
            try
            {
                var invoice = await dbContext.Invoices
                    .FirstOrDefaultAsync(r => r.Id == request.Id);
                if (invoice == null)
                    return new Result() { Message = "No se encontro la factura de renta", Success = false };

                if (invoice.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result> Eliminar(RentalInvoiceRequest request)
        {
            try
            {
                var rentalInvoice = await dbContext.Invoices
                    .FirstOrDefaultAsync(r => r.Id == request.Id);
                if (rentalInvoice == null)
                    return new Result() { Message = "No se encontro la factura", Success = false };

                dbContext.Invoices.Remove(rentalInvoice);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result<List<RentalInvoiceResponse>>> Consultar(string filtro)
        {
            try
            {
                var facturas = await dbContext.Invoices
                    .Where(c =>
                    (c.Customer.Name)
                    .ToLower()
                    .Contains(filtro.ToLower()
                    )
                    )
                    .Select(c => c.ToResponse())
                    .ToListAsync();
                return new Result<List<RentalInvoiceResponse>>()
                {
                    Data = facturas,
                    Success = true,
                    Message = "Ok"
                };
            }
            catch (Exception E)
            {
                return new Result<List<RentalInvoiceResponse>>()
                {
                    Data = null,
                    Success = false,
                    Message = E.Message
                };
            }
        }
    }
}
