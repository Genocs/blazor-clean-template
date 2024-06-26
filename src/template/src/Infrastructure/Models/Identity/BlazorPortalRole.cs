using Genocs.BlazorClean.Template.Domain.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Genocs.BlazorClean.Template.Infrastructure.Models.Identity;

public class BlazorPortalRole : IdentityRole, IAuditableEntity<string>
{
    public string? Description { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModifiedOn { get; set; }
    public virtual ICollection<BlazorPortalRoleClaim> RoleClaims { get; set; }

    public BlazorPortalRole(string createdBy = "System")
        : base()
    {
        CreatedBy = createdBy;
        RoleClaims = new HashSet<BlazorPortalRoleClaim>();
    }

    public BlazorPortalRole(string roleName, string? roleDescription = null, string createdBy = "System")
        : base(roleName)
    {
        CreatedBy = createdBy;
        RoleClaims = new HashSet<BlazorPortalRoleClaim>();
        Description = roleDescription;
    }
}