using AutoMapper;
using GenocsBlazor.Application.Features.Products.Commands.AddEdit;
using GenocsBlazor.Domain.Entities.Catalog;

namespace GenocsBlazor.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<AddEditProductCommand, Product>().ReverseMap();
        }
    }
}