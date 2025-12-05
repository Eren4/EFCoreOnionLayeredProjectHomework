using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.AppUserCommands
{
    public class RemoveAppUserCommand
    {
        public int Id { get; set; }

        public RemoveAppUserCommand(int id)
        {
            Id = id;
        }
    }
}
