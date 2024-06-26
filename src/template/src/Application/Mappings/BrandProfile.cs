using AutoMapper;
using Genocs.BlazorClean.Template.Application.Features.Brands.Commands.AddEdit;
using Genocs.BlazorClean.Template.Application.Features.Brands.Queries.GetAll;
using Genocs.BlazorClean.Template.Application.Features.Brands.Queries.GetById;
using Genocs.BlazorClean.Template.Domain.Entities.Catalog;

namespace Genocs.BlazorClean.Template.Application.Mappings;

public class BrandProfile : Profile
{
    public BrandProfile()
    {
        CreateMap<AddEditBrandCommand, Brand>().ReverseMap();
        CreateMap<GetBrandByIdResponse, Brand>().ReverseMap();
        CreateMap<GetAllBrandsResponse, Brand>().ReverseMap();
    }
}