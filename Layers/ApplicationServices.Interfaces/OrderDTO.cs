using System.Collections.Generic;

namespace ApplicationServices.Interfaces
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public List<OrderItemDTO> Items { get; set; }

    }
}
