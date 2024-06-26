using AutoMapper;
using Genocs.BlazorClean.Template.Application.Features.Products.Commands.AddEdit;
using Genocs.BlazorClean.Template.Domain.Entities.Catalog;

namespace Genocs.BlazorClean.Template.Application.Mappings;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<AddEditProductCommand, Product>().ReverseMap();
    }
}