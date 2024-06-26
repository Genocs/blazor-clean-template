using Genocs.BlazorClean.Template.Application.Interfaces.Common;
using Genocs.BlazorClean.Template.Application.Requests.Identity;
using Genocs.BlazorClean.Template.Shared.Wrapper;

namespace Genocs.BlazorClean.Template.Application.Interfaces.Services.Account;

public interface IAccountService : IService
{
    Task<IResult> UpdateProfileAsync(UpdateProfileRequest model, string userId);

    Task<IResult> ChangePasswordAsync(ChangePasswordRequest model, string userId);

    Task<IResult<string>> GetProfilePictureAsync(string userId);

    Task<IResult<string>> UpdateProfilePictureAsync(UpdateProfilePictureRequest request, string userId);
}