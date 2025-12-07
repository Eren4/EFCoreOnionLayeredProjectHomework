using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.ProductCommands
{
    public class RemoveProductMediatorCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveProductMediatorCommand(int id)
        {
            Id = id;
        }
    }
}
