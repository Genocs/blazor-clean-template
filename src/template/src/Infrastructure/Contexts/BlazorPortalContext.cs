﻿using Genocs.BlazorClean.Template.Application.Interfaces.Services;
using Genocs.BlazorClean.Template.Application.Models.Chat;
using Genocs.BlazorClean.Template.Domain.Contracts;
using Genocs.BlazorClean.Template.Domain.Entities.Catalog;
using Genocs.BlazorClean.Template.Domain.Entities.ExtendedAttributes;
using Genocs.BlazorClean.Template.Domain.Entities.Misc;
using Genocs.BlazorClean.Template.Infrastructure.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Genocs.BlazorClean.Template.Infrastructure.Contexts;

public class BlazorPortalContext : AuditableContext
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IDateTimeService _dateTimeService;

    public BlazorPortalContext(DbContextOptions<BlazorPortalContext> options, ICurrentUserService currentUserService, IDateTimeService dateTimeService)
        : base(options)
    {
        _currentUserService = currentUserService;
        _dateTimeService = dateTimeService;
    }

    public DbSet<ChatHistory<BlazorPortalUser>> ChatHistories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<DocumentType> DocumentTypes { get; set; }
    public DbSet<DocumentExtendedAttribute> DocumentExtendedAttributes { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        foreach (var entry in ChangeTracker.Entries<IAuditableEntity>().ToList())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedOn = _dateTimeService.NowUtc;
                    if (!string.IsNullOrWhiteSpace(_currentUserService.UserId)) entry.Entity.CreatedBy = _currentUserService.UserId;
                    if (string.IsNullOrWhiteSpace(entry.Entity.CreatedBy)) entry.Entity.CreatedBy = "System";
                    break;

                case EntityState.Modified:
                    entry.Entity.LastModifiedOn = _dateTimeService.NowUtc;
                    if (!string.IsNullOrWhiteSpace(_currentUserService.UserId)) entry.Entity.LastModifiedBy = _currentUserService.UserId;
                    break;
            }
        }

        if (_currentUserService.UserId == null)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
        else
        {
            return await base.SaveChangesAsync(_currentUserService.UserId, cancellationToken);
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        foreach (var property in builder.Model.GetEntityTypes()
        .SelectMany(t => t.GetProperties())
        .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
        {
            property.SetColumnType("decimal(18,2)");
        }

        foreach (var property in builder.Model.GetEntityTypes()
        .SelectMany(t => t.GetProperties())
        .Where(p => p.Name is "LastModifiedBy" or "CreatedBy"))
        {
            property.SetColumnType("nvarchar(128)");
        }

        base.OnModelCreating(builder);
        builder.Entity<ChatHistory<BlazorPortalUser>>(entity =>
        {
            entity.ToTable("ChatHistory");

            entity.HasOne(d => d.FromUser)
                .WithMany(p => p.ChatHistoryFromUsers)
                .HasForeignKey(d => d.FromUserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ToUser)
                .WithMany(p => p.ChatHistoryToUsers)
                .HasForeignKey(d => d.ToUserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        builder.Entity<BlazorPortalUser>(entity =>
        {
            entity.ToTable(name: "Users", "Identity");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        builder.Entity<BlazorPortalRole>(entity =>
        {
            entity.ToTable(name: "Roles", "Identity");
        });

        builder.Entity<IdentityUserRole<string>>(entity =>
        {
            entity.ToTable("UserRoles", "Identity");
        });

        builder.Entity<IdentityUserClaim<string>>(entity =>
        {
            entity.ToTable("UserClaims", "Identity");
        });

        builder.Entity<IdentityUserLogin<string>>(entity =>
        {
            entity.ToTable("UserLogins", "Identity");
        });

        builder.Entity<BlazorPortalRoleClaim>(entity =>
        {
            entity.ToTable(name: "RoleClaims", "Identity");

            entity.HasOne(d => d.Role)
                .WithMany(p => p.RoleClaims)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<IdentityUserToken<string>>(entity =>
        {
            entity.ToTable("UserTokens", "Identity");
        });
    }
}