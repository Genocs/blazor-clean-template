using Genocs.BlazorClean.Template.Shared.Wrapper;
using GenocsBlazor.Application.Requests.Identity;
using System.Security.Claims;

namespace GenocsBlazor.Client.Infrastructure.Managers.Identity.Authentication;

public interface IAuthenticationManager : IManager
{
    Task<IResult> Login(TokenRequest model);

    Task<IResult> Logout();

    Task<string> RefreshToken();

    Task<string> TryRefreshToken();

    Task<string> TryForceRefreshToken();

    Task<ClaimsPrincipal> CurrentUser();
}