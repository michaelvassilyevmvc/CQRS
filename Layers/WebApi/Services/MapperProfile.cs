
using ApplicationServices.Interfaces;
using AutoMapper;
using Entities;


namespace WebApi.Services
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Entities.Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<ChangeOrderDto, Entities.Order>();
        }
    }
}
