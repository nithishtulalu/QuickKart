using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuickKartApi.DTO_s;
using QuickKartApi.Services;

namespace QuickKartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController( IOrderService orderService)
        {
            _orderService = orderService;
        }
        private string GetUserId()=>User.FindFirst("id")?.Value;
        [HttpPost]
        [Authorize(Roles ="Customer")]
        public async Task<IActionResult> Create(OrderCreateDto dto)
        {
            var customerId=GetUserId();
            var order= await _orderService.CreateAsync(dto,customerId);
            return Ok(order);
        }

        [HttpGet("my")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> GetHistory()
        {
            var customerId=GetUserId();
            var order= await _orderService.GetByCustomerAsync(customerId);
            return Ok(order);
        }
        [HttpGet("all")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Getall()
        {
            var orders= await _orderService.GetAllAsync();
            return Ok(orders);
        }


    }

}
