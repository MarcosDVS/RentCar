using RentCar.Data.Request;
using RentCar.Data.Response;

namespace RentCar.Data.Services
{
    public interface ICustomerServices
    {
        Task<Result<List<CustomerResponse>>> Consultar(string filtro);
        Task<Result> Crear(CustomerRequest request);
        Task<Result> Eliminar(CustomerRequest request);
        Task<Result> Modificar(CustomerRequest request);
    }
}