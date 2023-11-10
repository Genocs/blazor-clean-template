using GenocsBlazor.Application.Features.Dashboards.Queries.GetData;
using GenocsBlazor.Shared.Wrapper;

namespace GenocsBlazor.Client.Infrastructure.Managers.Dashboard;

public interface IDashboardManager : IManager
{
    Task<IResult<DashboardDataResponse>> GetDataAsync();
}