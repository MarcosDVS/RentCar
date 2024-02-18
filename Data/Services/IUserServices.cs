using RentCar.Data.Models;
using RentCar.Data.Request;
using RentCar.Data.Response;

namespace RentCar.Data.Services
{
    public interface IUserServices
    {
        Task<Result<List<UserResponse>>> Consultar(string filtro);
        Task<Result> Crear(UserRequest request);
        Task<Result> Eliminar(UserRequest request);
        Task<Result<User>> Login(string username, string password);
        Task<Result> Modificar(UserRequest request);
        Task CreatUser();
    }
}