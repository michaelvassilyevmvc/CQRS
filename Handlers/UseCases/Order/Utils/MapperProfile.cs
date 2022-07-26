
using AutoMapper;
using Entities;
using Handlers.UseCases.Order.Dto;

namespace Handlers.UseCases.Order.Utils
{
    public class OrderMapperProfile : Profile
    {
        public OrderMapperProfile()
        {
            CreateMap<Entities.Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<ChangeOrderDto, Entities.Order>();
        }
    }
}
