using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.AppUserProfileQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.CategoryQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.CategoryResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Read.Categories
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdQueryResult>
    {
        private readonly ICategoryRepository _repository;

        public GetCategoryByIdQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query, CancellationToken cancellationToken)
        {

            Category value = await _repository.GetByIdAsync(query.Id);
            return new GetCategoryByIdQueryResult
            {
                CategoryName = value.CategoryName,
                Description = value.Description,
                Id = value.Id
            };
        }
    }
}
