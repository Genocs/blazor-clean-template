using AutoMapper;
using GenocsBlazor.Application.Features.Documents.Commands.AddEdit;
using GenocsBlazor.Application.Features.Documents.Queries.GetById;
using GenocsBlazor.Domain.Entities.Misc;

namespace GenocsBlazor.Application.Mappings
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            CreateMap<AddEditDocumentCommand, Document>().ReverseMap();
            CreateMap<GetDocumentByIdResponse, Document>().ReverseMap();
        }
    }
}