using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.Orders
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderMediatorCommand>
    {
        private readonly IOrderRepository _repository;

        public CreateOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderMediatorCommand command, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Order
            {
                ShippingAddress = command.ShippingAddress,
                AppUserId = command.AppUserId,
                CreatedDate = DateTime.Now,
                Status = Domain.Enums.DataStatus.Inserted,
            });
        }
    }
}
