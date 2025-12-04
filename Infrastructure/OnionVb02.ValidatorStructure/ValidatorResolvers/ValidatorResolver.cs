using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using OnionVb02.ValidatorStructure.Validators.AppUser;
using OnionVb02.ValidatorStructure.Validators.AppUserProfile;
using OnionVb02.ValidatorStructure.Validators.Category;
using OnionVb02.ValidatorStructure.Validators.Order;
using OnionVb02.ValidatorStructure.Validators.Product;

namespace OnionVb02.ValidatorResolvers
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
