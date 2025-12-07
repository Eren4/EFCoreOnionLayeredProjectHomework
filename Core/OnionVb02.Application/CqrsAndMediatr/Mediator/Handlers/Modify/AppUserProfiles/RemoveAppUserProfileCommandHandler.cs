using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.AppUserProfiles
{
    public class RemoveAppUserProfileCommandHandler : IRequestHandler<RemoveAppUserProfileMediatorCommand>
    {
        private readonly IAppUserProfileRepository _repository;

        public RemoveAppUserProfileCommandHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveAppUserProfileMediatorCommand command, CancellationToken cancellationToken)
        {
            AppUserProfile value = await _repository.GetByIdAsync(command.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
