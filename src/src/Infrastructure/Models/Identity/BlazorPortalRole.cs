using System;
using System.Collections.Generic;
using GenocsBlazor.Domain.Contracts;
using Microsoft.AspNetCore.Identity;

namespace GenocsBlazor.Infrastructure.Models.Identity;

public class BlazorPortalRole : IdentityRole, IAuditableEntity<string>
{
    public string Description { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTime? LastModifiedOn { get; set; }
    public virtual ICollection<BlazorPortalRoleClaim> RoleClaims { get; set; }

    public BlazorPortalRole() : base()
    {
        RoleClaims = new HashSet<BlazorPortalRoleClaim>();
    }

    public BlazorPortalRole(string roleName, string roleDescription = null) : base(roleName)
    {
        RoleClaims = new HashSet<BlazorPortalRoleClaim>();
        Description = roleDescription;
    }
}