using QuickKartApi.DTO_s;
using QuickKartApi.Models;

namespace QuickKartApi.Services
{
    public interface IOrderService
    {
        Task<List<Orders>> GetAllAsync();
        Task<List<Orders>> GetByCustomerAsync(string customerId);
        Task<Orders> CreateAsync(OrderCreateDto dto, string customerId);
    }
}
