using Genocs.BlazorClean.Template.Shared.Wrapper;
using GenocsBlazor.Application.Features.Dashboards.Queries.GetData;

namespace GenocsBlazor.Client.Infrastructure.Managers.Dashboard;

public interface IDashboardManager : IManager
{
    Task<IResult<DashboardDataResponse>> GetDataAsync();
}