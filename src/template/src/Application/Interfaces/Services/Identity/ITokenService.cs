using GenocsBlazor.Application.Interfaces.Common;
using GenocsBlazor.Application.Requests.Identity;
using GenocsBlazor.Application.Responses.Identity;
using GenocsBlazor.Shared.Wrapper;
using System.Threading.Tasks;

namespace GenocsBlazor.Application.Interfaces.Services.Identity
{
    public interface ITokenService : IService
    {
        Task<Result<TokenResponse>> LoginAsync(TokenRequest model);

        Task<Result<TokenResponse>> GetRefreshTokenAsync(RefreshTokenRequest model);
    }
}