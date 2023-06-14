using GenocsBlazor.Domain.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using GenocsBlazor.Application.Interfaces.Chat;
using GenocsBlazor.Application.Models.Chat;

namespace GenocsBlazor.Infrastructure.Models.Identity
{
    public class BlazorPortalUser : IdentityUser<string>, IChatUser, IAuditableEntity<string>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string CreatedBy { get; set; }

        [Column(TypeName = "text")]
        public string ProfilePictureDataUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
        public bool IsActive { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public virtual ICollection<ChatHistory<BlazorPortalUser>> ChatHistoryFromUsers { get; set; }
        public virtual ICollection<ChatHistory<BlazorPortalUser>> ChatHistoryToUsers { get; set; }

        public BlazorPortalUser()
        {
            ChatHistoryFromUsers = new HashSet<ChatHistory<BlazorPortalUser>>();
            ChatHistoryToUsers = new HashSet<ChatHistory<BlazorPortalUser>>();
        }
    }
}