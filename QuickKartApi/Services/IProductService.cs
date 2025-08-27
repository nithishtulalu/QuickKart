using QuickKartApi.DTO_s;
using QuickKartApi.Models;

namespace QuickKartApi.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(string id);
        Task<List<Product>> GetBySellerAsync(string sellerId);
        Task<Product> CreateAsync(ProductCreateDto dto, string sellerId);
        Task<bool> UpdateAsync(string id, ProductUpdateDto dto, string sellerId);
        Task<bool> DeleteAsync(string id, string sellerId);
    }
}
