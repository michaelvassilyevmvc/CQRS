using Microsoft.AspNetCore.Mvc;
using ApplicationServices.Interfaces;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{id}")]
        public async Task<OrderDto> GetByIdAsync(int id)
        {
            return await _orderService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<int> CreateAsync([FromBody]CreateOrderDto dto){
            return await _orderService.CreateOrderAsync(dto);
        }

    }
}
