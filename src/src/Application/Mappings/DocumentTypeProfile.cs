using AutoMapper;
using GenocsBlazor.Application.Features.DocumentTypes.Commands.AddEdit;
using GenocsBlazor.Application.Features.DocumentTypes.Queries.GetAll;
using GenocsBlazor.Application.Features.DocumentTypes.Queries.GetById;
using GenocsBlazor.Domain.Entities.Misc;

namespace GenocsBlazor.Application.Mappings
{
    public class DocumentTypeProfile : Profile
    {
        public DocumentTypeProfile()
        {
            CreateMap<AddEditDocumentTypeCommand, DocumentType>().ReverseMap();
            CreateMap<GetDocumentTypeByIdResponse, DocumentType>().ReverseMap();
            CreateMap<GetAllDocumentTypesResponse, DocumentType>().ReverseMap();
        }
    }
}