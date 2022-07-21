using System.Linq;
using System.Threading.Tasks;
using ApplicationServices.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApplicationServices.Implementation
{
    public class OrderService : IOrderService
    {

        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderService(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<OrderDTO> GetByIdAsync(int id)
        {
            var result = await _dbContext.Orders
                .Where(x=>x.Id == id)
                .ProjectTo<OrderDTO>(_mapper.ConfigurationProvider)
                .SingleAsync();
            return result;
        }
    }
}
