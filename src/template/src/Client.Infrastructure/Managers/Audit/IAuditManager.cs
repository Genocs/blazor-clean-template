using GenocsBlazor.Application.Responses.Audit;
using GenocsBlazor.Shared.Wrapper;

namespace GenocsBlazor.Client.Infrastructure.Managers.Audit;

public interface IAuditManager : IManager
{
    Task<IResult<IEnumerable<AuditResponse>>> GetCurrentUserTrailsAsync();

    Task<IResult<string>> DownloadFileAsync(string searchString = "", bool searchInOldValues = false, bool searchInNewValues = false);
}