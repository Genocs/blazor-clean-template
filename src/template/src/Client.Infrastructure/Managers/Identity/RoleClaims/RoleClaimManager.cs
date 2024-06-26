using Genocs.BlazorClean.Template.Application.Requests.Identity;
using Genocs.BlazorClean.Template.Application.Responses.Identity;
using Genocs.BlazorClean.Template.Client.Infrastructure.Extensions;
using Genocs.BlazorClean.Template.Shared.Wrapper;
using System.Net.Http.Json;

namespace Genocs.BlazorClean.Template.Client.Infrastructure.Managers.Identity.RoleClaims;

public class RoleClaimManager : IRoleClaimManager
{
    private readonly HttpClient _httpClient;

    public RoleClaimManager(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IResult<string>> DeleteAsync(string id)
    {
        var response = await _httpClient.DeleteAsync($"{Routes.RoleClaimsEndpoints.Delete}/{id}");
        return await response.ToResult<string>();
    }

    public async Task<IResult<List<RoleClaimResponse>>> GetRoleClaimsAsync()
    {
        var response = await _httpClient.GetAsync(Routes.RoleClaimsEndpoints.GetAll);
        return await response.ToResult<List<RoleClaimResponse>>();
    }

    public async Task<IResult<List<RoleClaimResponse>>> GetRoleClaimsByRoleIdAsync(string roleId)
    {
        var response = await _httpClient.GetAsync($"{Routes.RoleClaimsEndpoints.GetAll}/{roleId}");
        return await response.ToResult<List<RoleClaimResponse>>();
    }

    public async Task<IResult<string>> SaveAsync(RoleClaimRequest role)
    {
        var response = await _httpClient.PostAsJsonAsync(Routes.RoleClaimsEndpoints.Save, role);
        return await response.ToResult<string>();
    }
}