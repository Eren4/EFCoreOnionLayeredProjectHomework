using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.ProductCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.Products
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand>
    {
        private readonly IProductRepository _repository;

        public RemoveProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveProductCommand command, CancellationToken cancellationToken)
        {
            Product value = await _repository.GetByIdAsync(command.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
