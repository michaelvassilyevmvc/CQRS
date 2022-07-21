using System.Threading.Tasks;

namespace ApplicationServices.Interfaces
{
    public interface IOrderService 
    {
        Task<OrderDTO> GetByIdAsync(int id);
    }
}
