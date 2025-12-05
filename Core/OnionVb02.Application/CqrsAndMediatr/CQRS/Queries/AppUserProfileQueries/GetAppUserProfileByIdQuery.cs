using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Queries.AppUserProfileQueries
{
    public class GetAppUserProfileByIdQuery
    {
        public int Id { get; set; }

        public GetAppUserProfileByIdQuery(int id)
        {
            Id = id;
        }
    }
}
