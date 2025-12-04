using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.CategoryResults;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.ProductResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Read.Products
{
    public class GetProductQueryHandler
    {
        private readonly IProductRepository _repository;

        public GetProductQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetProductQueryResult>> Handle()
        {
            List<Product> values = await _repository.GetAllAsync();

            return values.Select(x => new GetProductQueryResult
            {
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                CategoryId = x.CategoryId,
                Id = x.Id
            }).ToList();
        }
    }
}
