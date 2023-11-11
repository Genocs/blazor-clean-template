using Genocs.BlazorClean.Template.Shared.Wrapper;
using GenocsBlazor.Application.Requests.Identity;
using GenocsBlazor.Application.Responses.Identity;

namespace GenocsBlazor.Client.Infrastructure.Managers.Identity.RoleClaims;

public interface IRoleClaimManager : IManager
{
    Task<IResult<List<RoleClaimResponse>>> GetRoleClaimsAsync();

    Task<IResult<List<RoleClaimResponse>>> GetRoleClaimsByRoleIdAsync(string roleId);

    Task<IResult<string>> SaveAsync(RoleClaimRequest role);

    Task<IResult<string>> DeleteAsync(string id);
}