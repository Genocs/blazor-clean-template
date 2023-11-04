using GenocsBlazor.Application.Interfaces.Common;
using GenocsBlazor.Application.Requests.Identity;
using GenocsBlazor.Shared.Wrapper;
using System.Threading.Tasks;

namespace GenocsBlazor.Application.Interfaces.Services.Account
{
    public interface IAccountService : IService
    {
        Task<IResult> UpdateProfileAsync(UpdateProfileRequest model, string userId);

        Task<IResult> ChangePasswordAsync(ChangePasswordRequest model, string userId);

        Task<IResult<string>> GetProfilePictureAsync(string userId);

        Task<IResult<string>> UpdateProfilePictureAsync(UpdateProfilePictureRequest request, string userId);
    }
}