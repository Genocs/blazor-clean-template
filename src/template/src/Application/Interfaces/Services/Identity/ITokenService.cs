using Genocs.BlazorClean.Template.Shared.Wrapper;
using GenocsBlazor.Application.Interfaces.Common;
using GenocsBlazor.Application.Requests.Identity;
using GenocsBlazor.Application.Responses.Identity;
using System.Threading.Tasks;

namespace GenocsBlazor.Application.Interfaces.Services.Identity
{
    public interface ITokenService : IService
    {
        Task<Result<TokenResponse>> LoginAsync(TokenRequest model);

        Task<Result<TokenResponse>> GetRefreshTokenAsync(RefreshTokenRequest model);
    }
}