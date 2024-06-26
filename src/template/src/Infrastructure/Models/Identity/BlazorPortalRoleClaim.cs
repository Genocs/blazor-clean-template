using Genocs.BlazorClean.Template.Domain.Contracts;
using Microsoft.AspNetCore.Identity;
using System;

namespace Genocs.BlazorClean.Template.Infrastructure.Models.Identity;

public class BlazorPortalRoleClaim : IdentityRoleClaim<string>, IAuditableEntity<int>
{
    public string? Description { get; set; }
    public string? Group { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModifiedOn { get; set; }
    public virtual BlazorPortalRole Role { get; set; }

    public BlazorPortalRoleClaim()
        : base()
    {

    }

    public BlazorPortalRoleClaim(string? roleClaimDescription = null, string? roleClaimGroup = null)
        : base()
    {
        Description = roleClaimDescription;
        Group = roleClaimGroup;
    }
}