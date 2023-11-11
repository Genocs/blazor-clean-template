using Genocs.BlazorClean.Template.Shared.Wrapper;
using GenocsBlazor.Application.Features.Dashboards.Queries.GetData;
using GenocsBlazor.Client.Infrastructure.Extensions;

namespace GenocsBlazor.Client.Infrastructure.Managers.Dashboard;

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