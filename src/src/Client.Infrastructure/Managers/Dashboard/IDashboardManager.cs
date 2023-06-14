using GenocsBlazor.Shared.Wrapper;
using System.Threading.Tasks;
using GenocsBlazor.Application.Features.Dashboards.Queries.GetData;

namespace GenocsBlazor.Client.Infrastructure.Managers.Dashboard
{
    public interface IDashboardManager : IManager
    {
        Task<IResult<DashboardDataResponse>> GetDataAsync();
    }
}