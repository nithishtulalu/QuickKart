using QuickKartApi.DTO_s;
using QuickKartApi.Models;
using QuickKartApi.Repository;

namespace QuickKartApi.Services
{
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<Orders>> GetAllAsync()=>
            await _orderRepository.GetAllAsync();
        public async Task<List<Orders>> GetByCustomerAsync(string customerId)=>
            await _orderRepository.GetByCustomerAsync(customerId);

       public async Task<Orders> CreateAsync(OrderCreateDto dto, string customerId)=>
            await _orderRepository.CreateAsync(dto, customerId);
    }
}
