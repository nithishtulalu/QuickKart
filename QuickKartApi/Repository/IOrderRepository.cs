using QuickKartApi.DTO_s;
using QuickKartApi.Models;

namespace QuickKartApi.Repository
{
    public interface IOrderRepository
    {
        Task<List<Orders>> GetAllAsync();
        Task<List<Orders>> GetByCustomerAsync(string customerId);
        Task<Orders> CreateAsync(OrderCreateDto dto, string customerId);
    }
}
