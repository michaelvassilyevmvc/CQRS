using System.Threading.Tasks;
using CqrsFramework;
using Handlers.UseCases.Order.Dto;
using Microsoft.AspNetCore.Mvc;
using UseCases.Order.Commands.CreateOrder;
using UseCases.Order.Queries.GetOrderById;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IRequestHandler<GetOrderByIdQuery, OrderDto> _getOrderByIdHandler;

        public OrdersController(IRequestHandler<GetOrderByIdQuery, OrderDto> getOrderByIdHandler)
        {
            this._getOrderByIdHandler = getOrderByIdHandler;
        }

        [HttpGet("{id}")]
        public async Task<OrderDto> GetByIdAsync(int id)
        {
            return await _getOrderByIdHandler.HandleAsync(new GetOrderByIdQuery { Id = id });
        }

        [HttpPost]
        public Task<int> CreateAsync([FromBody] ChangeOrderDto dto, [FromServices] IRequestHandler<CreateOrderCommand, int> handler)
        {
            return handler.HandleAsync(new CreateOrderCommand { Dto = dto });
        }

    }
}
