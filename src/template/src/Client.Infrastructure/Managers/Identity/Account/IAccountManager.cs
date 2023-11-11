using Genocs.BlazorClean.Template.Shared.Wrapper;
using GenocsBlazor.Application.Requests.Identity;

namespace GenocsBlazor.Client.Infrastructure.Managers.Identity.Account;

public interface IAccountManager : IManager
{
    Task<IResult> ChangePasswordAsync(ChangePasswordRequest model);

    Task<IResult> UpdateProfileAsync(UpdateProfileRequest model);

    Task<IResult<string>> GetProfilePictureAsync(string userId);

    Task<IResult<string>> UpdateProfilePictureAsync(UpdateProfilePictureRequest request, string userId);
}