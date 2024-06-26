using AutoMapper;
using Genocs.BlazorClean.Template.Application.Features.Documents.Commands.AddEdit;
using Genocs.BlazorClean.Template.Application.Features.Documents.Queries.GetById;
using Genocs.BlazorClean.Template.Domain.Entities.Misc;

namespace Genocs.BlazorClean.Template.Application.Mappings;

public class DocumentProfile : Profile
{
    public DocumentProfile()
    {
        CreateMap<AddEditDocumentCommand, Document>().ReverseMap();
        CreateMap<GetDocumentByIdResponse, Document>().ReverseMap();
    }
}