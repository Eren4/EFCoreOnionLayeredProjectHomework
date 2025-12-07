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
    public class UpdateAppUserProfileCommandHandler : IRequestHandler<UpdateAppUserProfileMediatorCommand>
    {
        private readonly IAppUserProfileRepository _repository;

        public UpdateAppUserProfileCommandHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAppUserProfileMediatorCommand command, CancellationToken cancellationToken)
        {
            AppUserProfile value = await _repository.GetByIdAsync(command.Id);

            value.FirstName = command.FirstName;
            value.LastName = command.LastName;

            value.UpdatedDate = DateTime.Now;
            value.Status = Domain.Enums.DataStatus.Updated;

            await _repository.SaveChangesAsync();
        }
    }
}
