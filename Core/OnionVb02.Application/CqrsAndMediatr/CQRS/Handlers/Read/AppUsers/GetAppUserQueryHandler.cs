using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.AppUserResults;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.ProductResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Read.AppUsers
{
    public class GetAppUserQueryHandler
    {
        private readonly IAppUserRepository _repository;

        public GetAppUserQueryHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAppUserQueryResult>> Handle()
        {
            List<AppUser> values = await _repository.GetAllAsync();

            return values.Select(x => new GetAppUserQueryResult
            {
                UserName = x.UserName,
                Password = x.Password,
                Id = x.Id
            }).ToList();
        }
    }
}
