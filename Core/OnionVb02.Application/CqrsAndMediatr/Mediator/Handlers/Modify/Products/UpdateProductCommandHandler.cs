using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.ProductCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.Products
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _repository;

        public UpdateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            Product value = await _repository.GetByIdAsync(command.Id);

            value.ProductName = command.ProductName;
            value.UnitPrice = command.UnitPrice;
            value.CategoryId = command.CategoryId;

            value.UpdatedDate = DateTime.Now;
            value.Status = Domain.Enums.DataStatus.Updated;

            await _repository.SaveChangesAsync();
        }
    }
}
