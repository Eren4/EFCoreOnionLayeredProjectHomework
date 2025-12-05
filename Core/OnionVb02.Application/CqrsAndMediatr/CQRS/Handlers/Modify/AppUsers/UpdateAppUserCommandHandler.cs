using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.AppUserCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.ProductCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Modify.AppUsers
{
    public class UpdateAppUserCommandHandler
    {
        private readonly IAppUserRepository _repository;

        public UpdateAppUserCommandHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAppUserCommand command)
        {
            AppUser value = await _repository.GetByIdAsync(command.Id);

            value.UserName = command.UserName;
            value.Password = command.Password;

            value.UpdatedDate = DateTime.Now;
            value.Status = Domain.Enums.DataStatus.Updated;

            await _repository.SaveChangesAsync();
        }
    }
}
