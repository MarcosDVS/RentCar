using Microsoft.EntityFrameworkCore;
using RentCar.Data.Context;
using RentCar.Data.Models;
using RentCar.Data.Request;
using RentCar.Data.Response;

namespace RentCar.Data.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IRentCarDbContext dbContext;

        public EmployeeServices(IRentCarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result> Crear(EmployeeRequest request)
        {
            try
            {
                var employee = Employee.Crear(request);
                dbContext.Employees.Add(employee);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result> Modificar(EmployeeRequest request)
        {
            try
            {
                var employee = await dbContext.Employees
                    .FirstOrDefaultAsync(e => e.Id == request.Id);
                if (employee == null)
                    return new Result() { Message = "No se encontro el empleado", Success = false };

                if (employee.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result> Eliminar(EmployeeRequest request)
        {
            try
            {
                var employee = await dbContext.Employees
                    .FirstOrDefaultAsync(v => v.Id == request.Id);
                if (employee == null)
                    return new Result() { Message = "No se encontro el usuario", Success = false };

                dbContext.Employees.Remove(employee);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result<List<EmployeeResponse>>> Consultar(string filtro)
        {
            try
            {
                var usuarios = await dbContext.Employees
                    .Where(e =>
                        (e.Name + " " + e.Position)
                        .ToLower()
                        .Contains(filtro.ToLower()
                        )
                    )
                    .Select(e => e.ToResponse())
                    .ToListAsync();
                return new Result<List<EmployeeResponse>>()
                {
                    Message = "Ok",
                    Success = true,
                    Data = usuarios
                };
            }
            catch (Exception E)
            {
                return new Result<List<EmployeeResponse>>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }

    }
}
