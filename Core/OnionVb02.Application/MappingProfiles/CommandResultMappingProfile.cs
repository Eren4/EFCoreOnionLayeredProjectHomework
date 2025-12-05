using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.AppUserCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.AppUserProfileCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.CategoryCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.OrderCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.ProductCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.AppUserProfileResults;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.AppUserResults;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.CategoryResults;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.OrderResults;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.ProductResults;
using OnionVb02.Application.DTOClasses;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.MappingProfiles
{
    public class CommandResultMappingProfile : Profile
    {
        public CommandResultMappingProfile()
        {
            // Category
            CreateMap<CreateCategoryCommand, CategoryDto>().ReverseMap();
            CreateMap<UpdateCategoryCommand, CategoryDto>().ReverseMap();
            CreateMap<RemoveCategoryCommand, CategoryDto>().ReverseMap();

            CreateMap<GetCategoryByIdQueryResult, CategoryDto>().ReverseMap();
            CreateMap<GetCategoryQueryResult, CategoryDto>().ReverseMap();

            // Product
            CreateMap<CreateProductCommand, ProductDto>().ReverseMap();
            CreateMap<UpdateProductCommand, ProductDto>().ReverseMap();
            CreateMap<RemoveProductCommand, ProductDto>().ReverseMap();

            CreateMap<GetProductByIdQueryResult, ProductDto>().ReverseMap();
            CreateMap<GetProductQueryResult, ProductDto>().ReverseMap();

            // Order
            CreateMap<CreateOrderCommand, OrderDto>().ReverseMap();
            CreateMap<UpdateOrderCommand, OrderDto>().ReverseMap();
            CreateMap<RemoveOrderCommand, OrderDto>().ReverseMap();

            CreateMap<GetOrderByIdQueryResult, OrderDto>().ReverseMap();
            CreateMap<GetOrderQueryResult, OrderDto>().ReverseMap();

            // AppUser
            CreateMap<CreateAppUserCommand, AppUserDto>().ReverseMap();
            CreateMap<UpdateAppUserCommand, AppUserDto>().ReverseMap();
            CreateMap<RemoveAppUserCommand, AppUserDto>().ReverseMap();

            CreateMap<GetAppUserByIdQueryResult, AppUserDto>().ReverseMap();
            CreateMap<GetAppUserQueryResult, AppUserDto>().ReverseMap();

            // AppUserProfile
            CreateMap<CreateAppUserProfileCommand, AppUserProfileDto>().ReverseMap();
            CreateMap<UpdateAppUserProfileCommand, AppUserProfileDto>().ReverseMap();
            CreateMap<RemoveAppUserProfileCommand, AppUserProfileDto>().ReverseMap();

            CreateMap<GetAppUserProfileByIdQueryResult, AppUserProfileDto>().ReverseMap();
            CreateMap<GetAppUserProfileQueryResult, AppUserProfileDto>().ReverseMap();
        }
    }
}
