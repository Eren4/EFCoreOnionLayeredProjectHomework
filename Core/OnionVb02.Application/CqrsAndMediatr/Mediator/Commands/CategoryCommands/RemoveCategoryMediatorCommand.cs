using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands
{
    public class RemoveCategoryMediatorCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveCategoryMediatorCommand(int id)
        {
            Id = id;
        }
    }
}
