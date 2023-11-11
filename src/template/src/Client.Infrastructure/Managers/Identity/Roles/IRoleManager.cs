using Genocs.BlazorClean.Template.Shared.Wrapper;
using GenocsBlazor.Application.Requests.Identity;
using GenocsBlazor.Application.Responses.Identity;

namespace GenocsBlazor.Client.Infrastructure.Managers.Identity.Roles;

public interface IRoleManager : IManager
{
    Task<IResult<List<RoleResponse>>> GetRolesAsync();

    Task<IResult<string>> SaveAsync(RoleRequest role);

    Task<IResult<string>> DeleteAsync(string id);

    Task<IResult<PermissionResponse>> GetPermissionsAsync(string roleId);

    Task<IResult<string>> UpdatePermissionsAsync(PermissionRequest request);
}