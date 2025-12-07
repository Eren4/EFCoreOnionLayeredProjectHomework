using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands
{
    public class UpdateOrderMediatorCommand : IRequest
    {
        public int Id { get; set; }
        public string ShippingAddress { get; set; }
        public int? AppUserId { get; set; }
    }
}
