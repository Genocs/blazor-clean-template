using Genocs.BlazorClean.Template.Application.Features.Documents.Commands.AddEdit;
using Genocs.BlazorClean.Template.Application.Features.Documents.Queries.GetAll;
using Genocs.BlazorClean.Template.Application.Features.Documents.Queries.GetById;
using Genocs.BlazorClean.Template.Application.Requests.Documents;
using Genocs.BlazorClean.Template.Shared.Wrapper;

namespace Genocs.BlazorClean.Template.Client.Infrastructure.Managers.Misc.Document;

public interface IDocumentManager : IManager
{
    Task<PaginatedResult<GetAllDocumentsResponse>> GetAllAsync(GetAllPagedDocumentsRequest request);

    Task<IResult<GetDocumentByIdResponse>> GetByIdAsync(GetDocumentByIdQuery request);

    Task<IResult<int>> SaveAsync(AddEditDocumentCommand request);

    Task<IResult<int>> DeleteAsync(int id);
}