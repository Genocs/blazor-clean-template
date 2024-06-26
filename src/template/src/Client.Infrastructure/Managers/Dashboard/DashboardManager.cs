using Genocs.BlazorClean.Template.Application.Features.Dashboards.Queries.GetData;
using Genocs.BlazorClean.Template.Client.Infrastructure.Extensions;
using Genocs.BlazorClean.Template.Shared.Wrapper;

namespace Genocs.BlazorClean.Template.Client.Infrastructure.Managers.Dashboard;

public class DashboardManager : IDashboardManager
{
    private readonly HttpClient _httpClient;

    public DashboardManager(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IResult<DashboardDataResponse>> GetDataAsync()
    {
        var response = await _httpClient.GetAsync(Routes.DashboardEndpoints.GetData);
        var data = await response.ToResult<DashboardDataResponse>();
        return data;
    }
}