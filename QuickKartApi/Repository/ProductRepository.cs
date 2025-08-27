using Microsoft.AspNetCore.Http.HttpResults;
using MongoDB.Driver;
using QuickKartApi.DTO_s;
using QuickKartApi.Models;

namespace QuickKartApi.Repository
{
    public class ProductRepository:IProductRepository
    {
        private readonly IMongoCollection<Product> _products;
        public ProductRepository(IMongoDatabase db)
        {
            _products = db.GetCollection<Product>("Products");
        }
        public async Task<List<Product>> GetAllAsync()
        {
            try
            {
                var products= await _products.Find( t=>true).ToListAsync();
                return products;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllAsync: {ex.Message}");
                return new List<Product>();
            }
        }
        public async Task<Product> GetByIdAsync(string id)
        {
            try
            {
                var product=await _products.Find(f=>f.Id==id).FirstOrDefaultAsync();
                if (product == null) return null;
                return product;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetByIdAsync: {ex.Message}");
                return null;
            }
        }
        public async Task<List<Product>> GetBySellerAsync(string sellerId)
        {
            try
            {
                var seller= await _products.Find(p=>p.SellerId==sellerId).ToListAsync();
                if (seller == null) return null;
                return seller;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetBySellerAsync: {ex.Message}");
                return new List<Product>();
            }
        }
       public async  Task<Product> CreateAsync(ProductCreateDto dto, string sellerId)
        {
            try
            {
                var product = new Product
                {
                    ProductName = dto.ProductName,
                    ProductDescription = dto.ProductDescription,
                    Price = dto.Price,
                    SellerId = sellerId
                };
                await _products.InsertOneAsync(product);
                return product;


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CreateAsync: {ex.Message}");
                return null;
            }
        }
        public async Task<bool> UpdateAsync(string id, ProductUpdateDto dto, string sellerId)
        {
            try
            {
                var product= await GetByIdAsync(id);
                if (product == null || product.SellerId != sellerId) return false;

                product.ProductName = dto.ProductName;
                product.ProductDescription = dto.ProductDescription;
                product.Price = dto.Price;

                var result= await _products.ReplaceOneAsync(p=>p.Id==id, product);
                return result.ModifiedCount > 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateAsync:{ex.Message}");
                return false;
            }
        }
       public async Task<bool> DeleteAsync(string id,string sellerId)
        {
            try
            {
                var product= await GetByIdAsync(id);
                if(product == null || product.SellerId!=sellerId) return false;
                var result= await _products.DeleteOneAsync(p => p.Id == id);
                return result.DeletedCount > 0;

    
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteAsync: {ex.Message}");
                return false;
            }
        }
    }
}
