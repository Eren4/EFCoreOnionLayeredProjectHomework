using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.Orders
{
    public class RemoveOrderCommandHandler : IRequestHandler<RemoveOrderCommand>
    {
        private readonly IOrderRepository _repository;

        public RemoveOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveOrderCommand command, CancellationToken cancellationToken)
        {
            Order value = await _repository.GetByIdAsync(command.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
