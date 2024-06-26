using AutoMapper;
using Genocs.BlazorClean.Template.Application.Features.ExtendedAttributes.Commands.AddEdit;
using Genocs.BlazorClean.Template.Application.Features.ExtendedAttributes.Queries.GetAll;
using Genocs.BlazorClean.Template.Application.Features.ExtendedAttributes.Queries.GetAllByEntityId;
using Genocs.BlazorClean.Template.Application.Features.ExtendedAttributes.Queries.GetById;
using Genocs.BlazorClean.Template.Domain.Entities.ExtendedAttributes;

namespace Genocs.BlazorClean.Template.Application.Mappings;

public class ExtendedAttributeProfile : Profile
{
    public ExtendedAttributeProfile()
    {
        CreateMap(typeof(AddEditExtendedAttributeCommand<,,,>), typeof(DocumentExtendedAttribute))
            .ForMember(nameof(DocumentExtendedAttribute.Entity), opt => opt.Ignore())
            .ForMember(nameof(DocumentExtendedAttribute.CreatedBy), opt => opt.Ignore())
            .ForMember(nameof(DocumentExtendedAttribute.CreatedOn), opt => opt.Ignore())
            .ForMember(nameof(DocumentExtendedAttribute.LastModifiedBy), opt => opt.Ignore())
            .ForMember(nameof(DocumentExtendedAttribute.LastModifiedOn), opt => opt.Ignore());

        CreateMap(typeof(GetExtendedAttributeByIdResponse<,>), typeof(DocumentExtendedAttribute)).ReverseMap();
        CreateMap(typeof(GetAllExtendedAttributesResponse<,>), typeof(DocumentExtendedAttribute)).ReverseMap();
        CreateMap(typeof(GetAllExtendedAttributesByEntityIdResponse<,>), typeof(DocumentExtendedAttribute)).ReverseMap();
    }
}