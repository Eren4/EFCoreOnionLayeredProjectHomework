using Microsoft.Extensions.DependencyInjection;
using OnionVb02.ValidatorStructure.MappingProfiles;

namespace OnionVb02.ValidatorStructure.DependencyResolvers
{
    public static class VmMapperResolver
    {
        public static void AddVmMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(VmMappingProfile));
        }
    }
}
