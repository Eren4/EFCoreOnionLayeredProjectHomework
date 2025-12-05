using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.ProductQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.ProductResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Read.Products
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdQueryResult>
    {
        private readonly IProductRepository _repository;

        public GetProductByIdQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {

            Product value = await _repository.GetByIdAsync(query.Id);
            return new GetProductByIdQueryResult
            {
                ProductName = value.ProductName,
                UnitPrice = value.UnitPrice,
                CategoryId = value.CategoryId,
                Id = value.Id
            };

        }
    }
}
