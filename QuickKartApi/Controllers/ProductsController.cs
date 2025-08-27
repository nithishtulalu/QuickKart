using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickKartApi.DTO_s;
using QuickKartApi.Services;

namespace QuickKartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService service)
        {
            _productService = service;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll() =>
            Ok(await _productService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var product = await _productService.GetByIdAsync(id);
            return product == null ? NotFound() : Ok(product);

        }

        [HttpGet("byseller/{sellerId}")]
        [Authorize(Roles ="Seller")]
        public async Task<IActionResult> GetBySeller(string sellerId)
        {
            var product= await _productService.GetBySellerAsync(sellerId);
            return product == null ? NotFound() : Ok( product);

        }

        [HttpPost("create")]
        [Authorize(Roles ="Seller")]
        public async Task<IActionResult> Create(ProductCreateDto dto)
        {
            var sellerId= User.FindFirst("UserId")?.Value;
            var product = await _productService.CreateAsync(dto, sellerId);
            return Ok(product);
        }

        [HttpPut("{id}")]
        [Authorize(Roles ="Seller")]
        public async Task<IActionResult> Update(string id, ProductUpdateDto dto)
        {
            var sellerId = User.FindFirst("UserId")?.Value;
            var success= await _productService.UpdateAsync(id,dto,sellerId);
            return success? NoContent() : Unauthorized();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles ="Seller")]
        public async Task<IActionResult> Delete(string id)
        {
            var sellerId = User.FindFirst("UserId")?.Value;
            var success= await _productService.DeleteAsync(id,sellerId);
            return success? NoContent() : Unauthorized();
        }



    }
}
