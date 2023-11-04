using GenocsBlazor.Application.Requests.Identity;
using GenocsBlazor.Shared.Wrapper;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GenocsBlazor.Client.Infrastructure.Managers.Identity.Authentication
{
    public interface IAuthenticationManager : IManager
    {
        Task<IResult> Login(TokenRequest model);

        Task<IResult> Logout();

        Task<string> RefreshToken();

        Task<string> TryRefreshToken();

        Task<string> TryForceRefreshToken();

        Task<ClaimsPrincipal> CurrentUser();
    }
}