using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands
{
    public class RemoveAppUserProfileMediatorCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveAppUserProfileMediatorCommand(int id)
        {
            Id = id;
        }
    }
}
