using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.Orders
{
    public class UpdateOrderCommandHandler
    {
        private readonly IOrderRepository _repository;

        public UpdateOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderCommand command)
        {
            Order value = await _repository.GetByIdAsync(command.Id);

            value.ShippingAddress = command.ShippingAddress;
            value.AppUserId = command.AppUserId;

            value.UpdatedDate = DateTime.Now;
            value.Status = Domain.Enums.DataStatus.Updated;

            await _repository.SaveChangesAsync();
        }
    }
}
