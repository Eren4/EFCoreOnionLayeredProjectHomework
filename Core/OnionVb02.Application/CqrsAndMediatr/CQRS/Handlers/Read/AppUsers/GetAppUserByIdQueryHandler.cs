using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Queries.ProductQueries;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.ProductResults;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.AppUserQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.AppUserResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Read.AppUsers
{
    public class GetAppUserByIdQueryHandler
    {
        private readonly IAppUserRepository _repository;

        public GetAppUserByIdQueryHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAppUserByIdQueryResult> Handle(GetAppUserByIdQuery query)
        {
            AppUser value = await _repository.GetByIdAsync(query.Id);
            return new GetAppUserByIdQueryResult
            {
                UserName = value.UserName,
                Password = value.Password,
                Id = value.Id
            };
        }
    }
}
