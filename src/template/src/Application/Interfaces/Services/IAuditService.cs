using Genocs.BlazorClean.Template.Shared.Wrapper;
using GenocsBlazor.Application.Responses.Audit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenocsBlazor.Application.Interfaces.Services
{
    public interface IAuditService
    {
        Task<IResult<IEnumerable<AuditResponse>>> GetCurrentUserTrailsAsync(string userId);

        Task<IResult<string>> ExportToExcelAsync(string userId, string searchString = "", bool searchInOldValues = false, bool searchInNewValues = false);
    }
}