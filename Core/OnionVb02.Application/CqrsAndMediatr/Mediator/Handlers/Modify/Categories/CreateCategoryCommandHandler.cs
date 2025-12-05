using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.Categories
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _repository;

        public CreateCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }
        
        public async Task Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Category
            {
                CategoryName = command.CategoryName,
                CreatedDate = DateTime.Now,
                Status = Domain.Enums.DataStatus.Inserted,
                Description = command.Description
            });
        }
    }
}
