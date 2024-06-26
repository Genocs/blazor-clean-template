using Genocs.BlazorClean.Template.Application.Requests.Identity;
using Genocs.BlazorClean.Template.Application.Responses.Identity;
using Genocs.BlazorClean.Template.Shared.Wrapper;

namespace Genocs.BlazorClean.Template.Client.Infrastructure.Managers.Identity.RoleClaims;

public interface IRoleClaimManager : IManager
{
    Task<IResult<List<RoleClaimResponse>>> GetRoleClaimsAsync();

    Task<IResult<List<RoleClaimResponse>>> GetRoleClaimsByRoleIdAsync(string roleId);

    Task<IResult<string>> SaveAsync(RoleClaimRequest role);

    Task<IResult<string>> DeleteAsync(string id);
}