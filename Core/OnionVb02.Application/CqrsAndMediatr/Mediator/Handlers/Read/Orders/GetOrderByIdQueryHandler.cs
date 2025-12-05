using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.OrderQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Read.Orders
{
    public class GetOrderByIdQueryHandler
    {
        private readonly IOrderRepository _repository;

        public GetOrderByIdQueryHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderByIdQueryResult> Handle(GetOrderByIdQuery query)
        {
            Order value = await _repository.GetByIdAsync(query.Id);
            return new GetOrderByIdQueryResult
            {
                ShippingAddress = value.ShippingAddress,
                AppUserId = value.AppUserId,
                Id = value.Id
            };
        }
    }
}
