using MongoDB.Driver;
using QuickKartApi.DTO_s;
using QuickKartApi.Models;

namespace QuickKartApi.Repository
{
    public class OrderRepository:IOrderRepository
    {
        private readonly IMongoCollection<Orders> _orders;
        public OrderRepository(IMongoDatabase db)
        {
            _orders = db.GetCollection<Orders>("Orders");
        }

        public async Task<List<Orders>> GetAllAsync()
        {
            try
            {
                return await _orders.Find(t=>true).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllAsync: {ex.Message}");
                return new List<Orders>();

            }
        }
        public async Task<List<Orders>> GetByCustomerAsync(string customerId)
        {

            try
            {
                return  await _orders.Find(o=>o.CustomerId== customerId).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetByCustomerAsync: {ex.Message}");
                return new List<Orders>();

            }
        }
       public async Task<Orders> CreateAsync(OrderCreateDto dto, string customerId)
        {

            try
            {
                var order = new Orders
                {
                    CustomerId = customerId,
                    ProductIds = dto.ProductIds,
                    TotalAmount = dto.TotalAmount,
                    OrderDate = DateTime.UtcNow,
                    Status = "Completed"
                };
                await _orders.InsertOneAsync(order);
                return order;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CreateAsync: {ex.Message}");
                return null;

            }
        }
    }
}
