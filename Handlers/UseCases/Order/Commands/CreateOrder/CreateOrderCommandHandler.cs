using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CqrsFramework;
using Infrastructure.Interfaces;

namespace UseCases.Order.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public CreateOrderCommandHandler(IDbContext dbContext, IMapper mapper, ICurrentUserService currentUserService)
        {
            this._dbContext = dbContext;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<int> HandleAsync(CreateOrderCommand request)
        {
            var order = _mapper.Map<Entities.Order>(request.Dto);
            order.UserEmail = _currentUserService.Email;
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            return order.Id;
        }
    }
}