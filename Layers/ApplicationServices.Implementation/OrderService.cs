using System.Linq;
using System.Threading.Tasks;
using ApplicationServices.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApplicationServices.Implementation
{
    public class OrderService : IOrderService
    {

        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public OrderService(IDbContext dbContext, IMapper mapper, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<OrderDto> GetByIdAsync(int id)
        {
            var result = await _dbContext.Orders
                .Where(x => x.Id == id)
                .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
                .SingleAsync();
            return result;
        }

        public async Task<int> CreateOrderAsync(CreateOrderDto dto)
        {
            var order = _mapper.Map<Order>(dto);
            order.UserEmail = _currentUserService.Email;
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            return order.Id;
        }
    }
}
