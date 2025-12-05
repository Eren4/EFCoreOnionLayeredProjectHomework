using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Queries.AppUserProfileQueries;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.AppUserProfileResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Read.AppUserProfiles
{
    public class GetAppUserProfileByIdQueryHandler
    {
        private readonly IAppUserProfileRepository _repository;

        public GetAppUserProfileByIdQueryHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAppUserProfileByIdQueryResult> Handle(GetAppUserProfileByIdQuery query)
        {
            AppUserProfile value = await _repository.GetByIdAsync(query.Id);
            return new GetAppUserProfileByIdQueryResult
            {
                FirstName = value.FirstName,
                LastName = value.LastName,
                Id = value.Id
            };
        }
    }
}
