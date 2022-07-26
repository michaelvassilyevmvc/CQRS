using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationServices.Interfaces
{
    public class CreateOrderDto
    {
        public List<OrderItemDto> Items { get; set; }
    }
}