using Microsoft.EntityFrameworkCore;
using RentCar.Data.Context;
using RentCar.Data.Models;
using RentCar.Data.Request;
using RentCar.Data.Response;

namespace RentCar.Data.Services
{
    public class VehicleServices : IVehicleServices
    {
        private readonly IRentCarDbContext dbContext;

        public VehicleServices(IRentCarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result> Crear(VehicleRequest request)
        {
            try
            {
                var vehicle = Vehicle.Crear(request);
                dbContext.Vehicles.Add(vehicle);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result> Modificar(VehicleRequest request)
        {
            try
            {
                var vehicle = await dbContext.Vehicles
                    .FirstOrDefaultAsync(v => v.Id == request.Id);
                if (vehicle == null)
                    return new Result() { Message = "No se encontro el vehiculo", Success = false };

                if (vehicle.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result> Eliminar(VehicleRequest request)
        {
            try
            {
                var vehicle = await dbContext.Vehicles
                    .FirstOrDefaultAsync(v => v.Id == request.Id);
                if (vehicle == null)
                    return new Result() { Message = "No se encontro el usuario", Success = false };

                dbContext.Vehicles.Remove(vehicle);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result<List<VehicleResponse>>> Consultar(string filtro)
        {
            try
            {
                var usuarios = await dbContext.Vehicles
                    .Where(v =>
                        (v.PlateNumber + " " + v.Make + " " + v.Model + " " + v.Year)
                        .ToLower()
                        .Contains(filtro.ToLower()
                        )
                    )
                    .Select(v => v.ToResponse())
                    .ToListAsync();
                return new Result<List<VehicleResponse>>()
                {
                    Message = "Ok",
                    Success = true,
                    Data = usuarios
                };
            }
            catch (Exception E)
            {
                return new Result<List<VehicleResponse>>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }

    }
}
