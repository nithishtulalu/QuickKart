using QuickKartApi.Models;

namespace QuickKartApi.DTO_s
{
    public class OrderCreateDto
    {
        public List<string> ProductIds { get; set; }
        public decimal TotalAmount {  get; set; }

    }
}
