using RentCar.Data.Request;
using RentCar.Data.Response;

namespace RentCar.Data.Services
{
    public interface IEmployeeServices
    {
        Task<Result<List<EmployeeResponse>>> Consultar(string filtro);
        Task<Result> Crear(EmployeeRequest request);
        Task<Result> Eliminar(EmployeeRequest request);
        Task<Result> Modificar(EmployeeRequest request);
    }
}