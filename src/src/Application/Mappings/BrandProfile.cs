using AutoMapper;
using GenocsBlazor.Application.Features.Brands.Commands.AddEdit;
using GenocsBlazor.Application.Features.Brands.Queries.GetAll;
using GenocsBlazor.Application.Features.Brands.Queries.GetById;
using GenocsBlazor.Domain.Entities.Catalog;

namespace GenocsBlazor.Application.Mappings
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<AddEditBrandCommand, Brand>().ReverseMap();
            CreateMap<GetBrandByIdResponse, Brand>().ReverseMap();
            CreateMap<GetAllBrandsResponse, Brand>().ReverseMap();
        }
    }
}