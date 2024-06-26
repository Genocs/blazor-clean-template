using Genocs.BlazorClean.Template.Application.Requests.Identity;
using Genocs.BlazorClean.Template.Shared.Wrapper;

namespace Genocs.BlazorClean.Template.Client.Infrastructure.Managers.Identity.Account;

public interface IAccountManager : IManager
{
    Task<IResult> ChangePasswordAsync(ChangePasswordRequest model);

    Task<IResult> UpdateProfileAsync(UpdateProfileRequest model);

    Task<IResult<string>> GetProfilePictureAsync(string userId);

    Task<IResult<string>> UpdateProfilePictureAsync(UpdateProfilePictureRequest request, string userId);
}