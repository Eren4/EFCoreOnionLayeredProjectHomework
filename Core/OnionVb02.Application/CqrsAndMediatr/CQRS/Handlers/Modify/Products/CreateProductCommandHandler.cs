using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.CategoryCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.ProductCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Modify.Products
{
    public class CreateProductCommandHandler
    {
        private readonly IProductRepository _repository;

        public CreateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateProductCommand command)
        {
            await _repository.CreateAsync(new Product
            {
                ProductName = command.ProductName,
                CreatedDate = DateTime.Now,
                Status = Domain.Enums.DataStatus.Inserted,
                UnitPrice = command.UnitPrice,
                CategoryId = command.CategoryId
            });
        }
    }
}
