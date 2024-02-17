using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentCar.Data.Context;
using RentCar.Data.Models;
using RentCar.Data.Request;
using RentCar.Data.Response;
using System.Diagnostics.Contracts;

namespace RentCar.Data.Services
{
    public class UserServices : IUserServices
    {
        private readonly IRentCarDbContext dbContext;

        public UserServices(IRentCarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result> Crear(UserRequest request)
        {
            try
            {
                var contacto = User.Crear(request);
                dbContext.Users.Add(contacto);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result> Modificar(UserRequest request)
        {
            try
            {
                var user = await dbContext.Users
                    .FirstOrDefaultAsync(c => c.Id == request.Id);
                if (user == null)
                    return new Result() { Message = "No se encontro el usuario", Success = false };

                if (user.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result> Eliminar(UserRequest request)
        {
            try
            {
                var contacto = await dbContext.Users
                    .FirstOrDefaultAsync(c => c.Id == request.Id);
                if (contacto == null)
                    return new Result() { Message = "No se encontro el usuario", Success = false };

                dbContext.Users.Remove(contacto);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result<List<UserResponse>>> Consultar(string filtro)
        {
            try
            {
                var usuarios = await dbContext.Users
                    .Where(u =>
                        (u.Name + " " + u.Username + " " + u.Password)
                        .ToLower()
                        .Contains(filtro.ToLower()
                        )
                    )
                    .Select(u => u.ToResponse())
                    .ToListAsync();
                return new Result<List<UserResponse>>()
                {
                    Message = "Ok",
                    Success = true,
                    Data = usuarios
                };
            }
            catch (Exception E)
            {
                return new Result<List<UserResponse>>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }
        public async Task<Result<User>> Login(string username, string password)
        {
            try
            {
                var user = await dbContext.Users
                    .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

                if (user != null)
                {
                    return new Result<User>
                    {
                        Success = true,
                        Data = user,
                        Message = "Inicio de sesión exitoso"
                    };
                }
                else
                {
                    return new Result<User>
                    {
                        Success = false,
                        Message = "Credenciales de inicio de sesión incorrectas"
                    };
                }
            }
            catch (Exception ex)
            {
                return new Result<User>
                {
                    Success = false,
                    Message = $"Error en el inicio de sesión: {ex.Message}"
                };
            }
        }

    }
}
