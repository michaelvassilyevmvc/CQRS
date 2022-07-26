using System.Threading.Tasks;

namespace ApplicationServices.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> GetByIdAsync(int id);
        Task<int> CreateOrderAsync(CreateOrderDto dto);
    }
}
