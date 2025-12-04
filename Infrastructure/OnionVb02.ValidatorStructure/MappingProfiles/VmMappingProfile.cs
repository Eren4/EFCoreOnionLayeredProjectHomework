using AutoMapper;
using OnionVb02.Application.DTOClasses;
using OnionVb02.ValidatorStructure.Models.RequestModels.AppUserProfiles;
using OnionVb02.ValidatorStructure.Models.RequestModels.AppUsers;
using OnionVb02.ValidatorStructure.Models.RequestModels.Categories;
using OnionVb02.ValidatorStructure.Models.RequestModels.Orders;
using OnionVb02.ValidatorStructure.Models.RequestModels.Products;
using OnionVb02.ValidatorStructure.Models.ResponseModels.AppUserProfiles;
using OnionVb02.ValidatorStructure.Models.ResponseModels.AppUsers;
using OnionVb02.ValidatorStructure.Models.ResponseModels.Categories;
using OnionVb02.ValidatorStructure.Models.ResponseModels.Orders;
using OnionVb02.ValidatorStructure.Models.ResponseModels.Products;

namespace OnionVb02.ValidatorStructure.MappingProfiles
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
