using QuickKartApi.DTO_s;
using QuickKartApi.Models;
using QuickKartApi.Repository;

namespace QuickKartApi.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

       public async Task<List<Product>> GetAllAsync()=>
            await _repository.GetAllAsync();
        public async Task<Product> GetByIdAsync(string id)=>
            await _repository.GetByIdAsync(id);
        public async Task<List<Product>> GetBySellerAsync(string sellerId) =>
             await _repository.GetBySellerAsync(sellerId);
       public async Task <Product> CreateAsync(ProductCreateDto dto, string sellerId)=>
            await _repository.CreateAsync(dto, sellerId);
       public async Task<bool> UpdateAsync(string id, ProductUpdateDto dto, string sellerId)=>
            await _repository.UpdateAsync(id, dto, sellerId);
       public async Task<bool> DeleteAsync(string id, string sellerId)=>
            await _repository.DeleteAsync(id, sellerId);
    }
}
