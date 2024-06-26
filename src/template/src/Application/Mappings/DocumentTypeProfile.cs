using AutoMapper;
using Genocs.BlazorClean.Template.Application.Features.DocumentTypes.Commands.AddEdit;
using Genocs.BlazorClean.Template.Application.Features.DocumentTypes.Queries.GetAll;
using Genocs.BlazorClean.Template.Application.Features.DocumentTypes.Queries.GetById;
using Genocs.BlazorClean.Template.Domain.Entities.Misc;

namespace Genocs.BlazorClean.Template.Application.Mappings;

public class DocumentTypeProfile : Profile
{
    public DocumentTypeProfile()
    {
        CreateMap<AddEditDocumentTypeCommand, DocumentType>().ReverseMap();
        CreateMap<GetDocumentTypeByIdResponse, DocumentType>().ReverseMap();
        CreateMap<GetAllDocumentTypesResponse, DocumentType>().ReverseMap();
    }
}