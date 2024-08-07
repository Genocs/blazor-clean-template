﻿using Genocs.BlazorClean.Template.Application.Interfaces.Chat;
using Genocs.BlazorClean.Template.Application.Models.Chat;
using Genocs.BlazorClean.Template.Domain.Contracts;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Genocs.BlazorClean.Template.Infrastructure.Models.Identity;

public class BlazorPortalUser : IdentityUser<string>, IChatUser, IAuditableEntity<string>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CreatedBy { get; set; }

    [Column(TypeName = "text")]
    public string? ProfilePictureDataUrl { get; set; }

    public DateTime CreatedOn { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedOn { get; set; }
    public bool IsActive { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
    public virtual ICollection<ChatHistory<BlazorPortalUser>> ChatHistoryFromUsers { get; set; }
    public virtual ICollection<ChatHistory<BlazorPortalUser>> ChatHistoryToUsers { get; set; }

    public BlazorPortalUser(string firstName, string lastName, string createdBy = "System")
    {
        FirstName = firstName;
        LastName = lastName;
        CreatedBy = createdBy;
        ChatHistoryFromUsers = new HashSet<ChatHistory<BlazorPortalUser>>();
        ChatHistoryToUsers = new HashSet<ChatHistory<BlazorPortalUser>>();
    }
}