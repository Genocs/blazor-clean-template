using Genocs.BlazorClean.Template.Application.Interfaces.Common;
using Genocs.BlazorClean.Template.Application.Requests.Identity;
using Genocs.BlazorClean.Template.Application.Responses.Identity;
using Genocs.BlazorClean.Template.Shared.Wrapper;

namespace Genocs.BlazorClean.Template.Application.Interfaces.Services.Identity;

public interface IRoleService : IService
{
    Task<Result<List<RoleResponse>>> GetAllAsync();

    Task<int> GetCountAsync();

    Task<Result<RoleResponse>> GetByIdAsync(string id);

    Task<Result<string>> SaveAsync(RoleRequest request);

    Task<Result<string>> DeleteAsync(string id);

    Task<Result<PermissionResponse>> GetAllPermissionsAsync(string roleId);

    Task<Result<string>> UpdatePermissionsAsync(PermissionRequest request);
}