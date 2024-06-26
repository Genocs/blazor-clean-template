using Genocs.BlazorClean.Template.Application.Features.Dashboards.Queries.GetData;
using Genocs.BlazorClean.Template.Shared.Wrapper;

namespace Genocs.BlazorClean.Template.Client.Infrastructure.Managers.Dashboard;

public interface IDashboardManager : IManager
{
    Task<IResult<DashboardDataResponse>> GetDataAsync();
}