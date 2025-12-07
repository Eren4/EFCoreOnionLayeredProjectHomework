using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands
{
    public class RemoveOrderMediatorCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveOrderMediatorCommand(int id)
        {
            Id = id;
        }
    }
}
