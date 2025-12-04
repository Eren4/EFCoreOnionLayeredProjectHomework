using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Project.OnionVb02.Validators.AppUser;
using Project.OnionVb02.Validators.AppUserProfile;
using Project.OnionVb02.Validators.Category;
using Project.OnionVb02.Validators.Order;
using Project.OnionVb02.Validators.Product;

namespace Project.OnionVb02.ValidatorResolvers
{
    public static class ValidatorResolver
    {
        public static void AddValidatorService(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CreateAppUserRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateAppUserProfileRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateCategoryRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateOrderRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateProductRequestValidator>();
        }
    }
}
