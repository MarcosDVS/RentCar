using RentCar.Data.Request;
using RentCar.Data.Response;

namespace RentCar.Data.Services
{
    public interface IVehicleServices
    {
        Task<Result<List<VehicleResponse>>> Consultar(string filtro);
        Task<Result> Crear(VehicleRequest request);
        Task<Result> Eliminar(VehicleRequest request);
        Task<Result> Modificar(VehicleRequest request);
        Task<bool> MarkAsRented(int? carId);
    }
}