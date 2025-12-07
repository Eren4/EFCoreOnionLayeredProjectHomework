using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.AppUsers
{
    public class UpdateAppUserCommandHandler : IRequestHandler<UpdateAppUserMediatorCommand>
    {
        private readonly IAppUserRepository _repository;

        public UpdateAppUserCommandHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAppUserMediatorCommand request, CancellationToken cancellationToken)
        {
            AppUser value = await _repository.GetByIdAsync(request.Id);
            value.UserName = request.UserName;
            value.Password =  request.Password;
            value.Status = Domain.Enums.DataStatus.Updated;
            value.UpdatedDate = DateTime.Now;
            await _repository.SaveChangesAsync();
        }
    }
}
