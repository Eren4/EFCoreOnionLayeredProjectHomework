using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.CategoryCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.ProductCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.CategoryResults;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.ProductResults;
using OnionVb02.Application.DTOClasses;

namespace OnionVb02.Application.MappingProfiles
{
    public class CommandResultMappingProfile : Profile
    {
        public CommandResultMappingProfile()
        {
            CreateMap<CreateCategoryCommand, CategoryDto>().ReverseMap();
            CreateMap<UpdateCategoryCommand, CategoryDto>().ReverseMap();
            CreateMap<RemoveCategoryCommand, CategoryDto>().ReverseMap();

            CreateMap<GetCategoryByIdQueryResult, CategoryDto>().ReverseMap();
            CreateMap<GetCategoryQueryResult, CategoryDto>().ReverseMap();

            CreateMap<CreateProductCommand, ProductDto>().ReverseMap();
            CreateMap<UpdateProductCommand, ProductDto>().ReverseMap();
            CreateMap<RemoveProductCommand, ProductDto>().ReverseMap();

            CreateMap<GetProductByIdQueryResult, ProductDto>().ReverseMap();
            CreateMap<GetProductQueryResult, ProductDto>().ReverseMap();
        }
    }
}
