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
    public class CreateAppUserCommandHandler
    {
        private readonly IAppUserRepository _repository;

        public CreateAppUserCommandHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAppUserCommand command)
        {
            await _repository.CreateAsync(new AppUser
            {
                UserName = command.UserName,
                Password = command.Password,
                CreatedDate = DateTime.Now,
                Status = Domain.Enums.DataStatus.Inserted,
            });
        }
    }
}
