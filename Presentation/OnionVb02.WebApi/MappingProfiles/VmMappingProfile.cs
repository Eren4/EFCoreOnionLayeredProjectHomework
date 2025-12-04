using AutoMapper;
using OnionVb02.Application.DTOClasses;
using Project.OnionVb02.Models.RequestModels.AppUserProfiles;
using Project.OnionVb02.Models.RequestModels.AppUsers;
using Project.OnionVb02.Models.RequestModels.Categories;
using Project.OnionVb02.Models.RequestModels.Orders;
using Project.OnionVb02.Models.RequestModels.Products;
using Project.OnionVb02.Models.ResponseModels.AppUserProfiles;
using Project.OnionVb02.Models.ResponseModels.AppUsers;
using Project.OnionVb02.Models.ResponseModels.Orders;
using Project.OnionVb02.Models.ResponseModels.Products;
using Project.WebApi.Models.ResponseModels.Categories;

namespace OnionVb02.WebApi.MappingProfiles
{
    public class VmMappingProfile : Profile
    {
        public VmMappingProfile()
        {
            CreateMap<CreateCategoryRequestModel, CategoryDto>();
            CreateMap<UpdateCategoryRequestModel,CategoryDto>();
            CreateMap<CategoryDto, CategoryResponseModel>();

            CreateMap<CreateProductRequestModel, ProductDto>();
            CreateMap<UpdateProductRequestModel, ProductDto>();
            CreateMap<ProductDto, ProductResponseModel>();

            CreateMap<CreateAppUserRequestModel, AppUserDto>();
            CreateMap<UpdateAppUserRequestModel, AppUserDto>();
            CreateMap<AppUserDto, AppUserResponseModel>();

            CreateMap<CreateAppUserProfileRequestModel, AppUserProfileDto>();
            CreateMap<UpdateAppUserProfileRequestModel, AppUserProfileDto>();
            CreateMap<AppUserProfileDto, AppUserProfileResponseModel>();

            CreateMap<CreateOrderRequestModel, OrderDto>();
            CreateMap<UpdateOrderRequestModel, OrderDto>();
            CreateMap<OrderDto, OrderResponseModel>();
        }
    }
}
