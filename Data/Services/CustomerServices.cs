using Microsoft.EntityFrameworkCore;
using RentCar.Data.Context;
using RentCar.Data.Models;
using RentCar.Data.Request;
using RentCar.Data.Response;

namespace RentCar.Data.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly IRentCarDbContext dbContext;

        public CustomerServices(IRentCarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result> Crear(CustomerRequest request)
        {
            try
            {
                var customer = Customer.Crear(request);
                dbContext.Customers.Add(customer);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result> Modificar(CustomerRequest request)
        {
            try
            {
                var vehicle = await dbContext.Customers
                    .FirstOrDefaultAsync(c => c.Id == request.Id);
                if (vehicle == null)
                    return new Result() { Message = "No se encontro el cliente", Success = false };

                if (vehicle.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result> Eliminar(CustomerRequest request)
        {
            try
            {
                var customer = await dbContext.Customers
                    .FirstOrDefaultAsync(c => c.Id == request.Id);
                if (customer == null)
                    return new Result() { Message = "No se encontro el cliente", Success = false };

                dbContext.Customers.Remove(customer);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result<List<CustomerResponse>>> Consultar(string filtro)
        {
            try
            {
                var customer = await dbContext.Customers
                    .Where(c =>
                        (c.Name + " " + c.PhoneNumber + " " + c.Email)
                        .ToLower()
                        .Contains(filtro.ToLower()
                        )
                    )
                    .Select(v => v.ToResponse())
                    .ToListAsync();
                return new Result<List<CustomerResponse>>()
                {
                    Message = "Ok",
                    Success = true,
                    Data = customer
                };
            }
            catch (Exception E)
            {
                return new Result<List<CustomerResponse>>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }

    }
}
