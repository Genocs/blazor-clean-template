using GenocsBlazor.Application.Features.Documents.Commands.AddEdit;
using GenocsBlazor.Application.Features.Documents.Queries.GetAll;
using GenocsBlazor.Application.Requests.Documents;
using GenocsBlazor.Shared.Wrapper;
using System.Threading.Tasks;
using GenocsBlazor.Application.Features.Documents.Queries.GetById;

namespace GenocsBlazor.Client.Infrastructure.Managers.Misc.Document
{
    public interface IDocumentManager : IManager
    {
        Task<PaginatedResult<GetAllDocumentsResponse>> GetAllAsync(GetAllPagedDocumentsRequest request);

        Task<IResult<GetDocumentByIdResponse>> GetByIdAsync(GetDocumentByIdQuery request);

        Task<IResult<int>> SaveAsync(AddEditDocumentCommand request);

        Task<IResult<int>> DeleteAsync(int id);
    }
}