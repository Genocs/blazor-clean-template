using Genocs.BlazorClean.Template.Application.Responses.Identity;

namespace Genocs.BlazorClean.Template.Application.Requests.Identity;

public class UpdateUserRolesRequest
{
    public string UserId { get; set; }
    public IList<UserRoleModel> UserRoles { get; set; }
}