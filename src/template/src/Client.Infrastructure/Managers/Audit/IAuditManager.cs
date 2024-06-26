using Genocs.BlazorClean.Template.Application.Responses.Audit;
using Genocs.BlazorClean.Template.Shared.Wrapper;

namespace Genocs.BlazorClean.Template.Client.Infrastructure.Managers.Audit;

public interface IAuditManager : IManager
{
    Task<IResult<IEnumerable<AuditResponse>>> GetCurrentUserTrailsAsync();

    Task<IResult<string>> DownloadFileAsync(string searchString = "", bool searchInOldValues = false, bool searchInNewValues = false);
}