using RentCar.Data.Request;
using RentCar.Data.Response;

namespace RentCar.Data.Services
{
    public interface IRentalInvoiceServices
    {
        Task<Result<List<RentalInvoiceResponse>>> Consultar();
        Task<Result> Crear(RentalInvoiceRequest request);
        Task<Result> Eliminar(RentalInvoiceRequest request);
        Task<Result> Modificar(RentalInvoiceRequest request);
    }
}