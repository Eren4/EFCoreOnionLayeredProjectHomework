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
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, List<GetCategoryQueryResult>>
    {
        private readonly ICategoryRepository _repository;

        public GetCategoryQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        //Todo : Mapper profiles icin ödev
        public async Task<List<GetCategoryQueryResult>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            List<Category> values = await _repository.GetAllAsync();

            return values.Select(x => new GetCategoryQueryResult
            {
                CategoryName = x.CategoryName,
                Description = x.Description,
                Id = x.Id
            }).ToList();
        }
    }
}
