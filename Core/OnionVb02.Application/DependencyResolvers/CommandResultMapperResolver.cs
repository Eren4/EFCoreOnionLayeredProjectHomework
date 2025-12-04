using Microsoft.Extensions.DependencyInjection;
using OnionVb02.Application.MappingProfiles;

namespace OnionVb02.Application.DependencyResolvers
{
    public static class CommandResultMapperResolver
    {
        public static void AddCommandResultMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CommandResultMappingProfile));
        }
    }
}
