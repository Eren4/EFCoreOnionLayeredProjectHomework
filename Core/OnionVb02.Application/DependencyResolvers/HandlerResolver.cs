using Microsoft.Extensions.DependencyInjection;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Modify.AppUserProfiles;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Modify.AppUsers;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Modify.Categories;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Modify.Orders;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Modify.Products;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Read.AppUserProfiles;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Read.AppUsers;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Read.Categories;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Read.Orders;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Read.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.DependencyResolvers
{
    
    public static class HandlerResolver
    {
        public static void AddHandlerService(this IServiceCollection services)
        {
            // Categories
            services.AddScoped<GetCategoryQueryHandler>();
            services.AddScoped<GetCategoryByIdQueryHandler>();
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<UpdateCategoryCommandHandler>();
            services.AddScoped<RemoveCategoryCommandHandler>();

            // AppUsers
            services.AddScoped<GetAppUserQueryHandler>();
            services.AddScoped<GetAppUserByIdQueryHandler>();
            services.AddScoped<CreateAppUserCommandHandler>();
            services.AddScoped<UpdateAppUserCommandHandler>();
            services.AddScoped<RemoveAppUserCommandHandler>();

            // AppUserProfiles
            services.AddScoped<GetAppUserProfileQueryHandler>();
            services.AddScoped<GetAppUserProfileByIdQueryHandler>();
            services.AddScoped<CreateAppUserProfileCommandHandler>();
            services.AddScoped<UpdateAppUserProfileCommandHandler>();
            services.AddScoped<RemoveAppUserProfileCommandHandler>();

            // Orders
            services.AddScoped<GetOrderQueryHandler>();
            services.AddScoped<GetOrderByIdQueryHandler>();
            services.AddScoped<CreateOrderCommandHandler>();
            services.AddScoped<UpdateOrderCommandHandler>();
            services.AddScoped<RemoveOrderCommandHandler>();

            // Products
            services.AddScoped<GetProductQueryHandler>();
            services.AddScoped<GetProductByIdQueryHandler>();
            services.AddScoped<CreateProductCommandHandler>();
            services.AddScoped<UpdateProductCommandHandler>();
            services.AddScoped<RemoveProductCommandHandler>();

            services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(GetCategoryByIdQueryHandler).Assembly));
        }
    }
}
