using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.AppUserProfileResults;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.OrderResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Read.Orders
{
    public class GetOrderQueryHandler
    {
        private readonly IOrderRepository _repository;

        public GetOrderQueryHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderQueryResult>> Handle()
        {
            List<Order> values = await _repository.GetAllAsync();

            return values.Select(x => new GetOrderQueryResult
            {
                ShippingAddress = x.ShippingAddress,
                AppUserId = x.AppUserId,
                Id = x.Id
            }).ToList();
        }
    }
}
