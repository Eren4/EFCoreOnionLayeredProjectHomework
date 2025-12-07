using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.Categories
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryMediatorCommand>
    {
        private readonly ICategoryRepository _repository;

        public RemoveCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCategoryMediatorCommand command, CancellationToken cancellationToken)
        {
            Category value = await _repository.GetByIdAsync(command.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
