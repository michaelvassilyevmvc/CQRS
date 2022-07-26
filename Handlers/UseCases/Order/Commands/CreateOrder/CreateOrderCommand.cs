using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Handlers.UseCases.Order.Dto;

namespace UseCases.Order.Commands.CreateOrder
{
    public class CreateOrderCommand
    {
        public ChangeOrderDto Dto { get; set; }

    }
}