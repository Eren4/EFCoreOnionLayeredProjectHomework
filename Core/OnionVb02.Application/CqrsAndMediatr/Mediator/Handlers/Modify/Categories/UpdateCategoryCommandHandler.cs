using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.Categories
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryMediatorCommand>
    {
        private readonly ICategoryRepository _repository;

        public UpdateCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCategoryMediatorCommand command, CancellationToken cancellationToken)
        {
            Category value = await _repository.GetByIdAsync(command.Id);
            value.CategoryName = command.CategoryName;
            value.Description = command.Description;
            value.UpdatedDate = DateTime.Now;
            value.Status = Domain.Enums.DataStatus.Updated;
            await _repository.SaveChangesAsync();
        }
    }
}
