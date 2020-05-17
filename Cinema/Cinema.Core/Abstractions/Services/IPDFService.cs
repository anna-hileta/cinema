using Cinema.Core.Entities;
using System.Threading.Tasks;

namespace Cinema.Core.Abstractions.Services
{
    public interface IPDFService
    {
        Task<byte[]> DecesionCreatePDFAsync(Check pdfData);
        Task<byte[]> DecesionCreatePDFAsyncForFood(FoodcourtCheck pdfData);
    }
}