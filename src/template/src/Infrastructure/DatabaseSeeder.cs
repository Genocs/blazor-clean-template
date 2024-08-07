﻿using Genocs.BlazorClean.Template.Application.Interfaces.Services;
using Genocs.BlazorClean.Template.Infrastructure.Contexts;
using Genocs.BlazorClean.Template.Infrastructure.Helpers;
using Genocs.BlazorClean.Template.Infrastructure.Models.Identity;
using Genocs.BlazorClean.Template.Shared.Constants.Permission;
using Genocs.BlazorClean.Template.Shared.Constants.Role;
using Genocs.BlazorClean.Template.Shared.Constants.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace Genocs.BlazorClean.Template.Infrastructure;

public class DatabaseSeeder : IDatabaseSeeder
{
    private readonly ILogger<DatabaseSeeder> _logger;
    private readonly IStringLocalizer<DatabaseSeeder> _localizer;
    private readonly BlazorPortalContext _db;
    private readonly UserManager<BlazorPortalUser> _userManager;
    private readonly RoleManager<BlazorPortalRole> _roleManager;

    public DatabaseSeeder(UserManager<BlazorPortalUser> userManager,
                          RoleManager<BlazorPortalRole> roleManager,
                          BlazorPortalContext db,
                          ILogger<DatabaseSeeder> logger,
                          IStringLocalizer<DatabaseSeeder> localizer)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _db = db;
        _logger = logger;
        _localizer = localizer;
    }

    public void Initialize()
    {
        AddAdministrator();
        AddBasicUser();
        _db.SaveChanges();
    }

    private void AddAdministrator()
    {
        Task.Run(async () =>
        {
            // Check if Role Exists
            var adminRoleInDb = await _roleManager.FindByNameAsync(RoleConstants.AdministratorRole);
            if (adminRoleInDb == null)
            {
                var adminRole = new BlazorPortalRole(RoleConstants.AdministratorRole, _localizer["Administrator role with full permissions"]);
                await _roleManager.CreateAsync(adminRole);
                adminRoleInDb = await _roleManager.FindByNameAsync(RoleConstants.AdministratorRole);
                _logger.LogInformation(_localizer["Seeded Administrator Role."]);
            }

            var basicRoleInDb = await _roleManager.FindByNameAsync(RoleConstants.BasicRole);
            if (basicRoleInDb == null)
            {
                var basicRole = new BlazorPortalRole(RoleConstants.BasicRole, _localizer["Basic role with full permissions"]);
                await _roleManager.CreateAsync(basicRole);
                basicRoleInDb = await _roleManager.FindByNameAsync(RoleConstants.BasicRole);
                _logger.LogInformation(_localizer["Seeded Administrator Role."]);
            }

            // Check if User Exists
            {
                var sysAdmin = new BlazorPortalUser("Administrator", "Sys")
                {
                    Email = "info@genocs.com",
                    UserName = "sysAdmin",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    CreatedOn = DateTime.Now,
                    IsActive = true
                };

                var sysAdminInDb = await _userManager.FindByEmailAsync(sysAdmin.Email);
                if (sysAdminInDb == null)
                {
                    await _userManager.CreateAsync(sysAdmin, UserConstants.DefaultPassword);
                    var result = await _userManager.AddToRoleAsync(sysAdmin, RoleConstants.AdministratorRole);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation(_localizer["Seeded Default SuperAdmin User."]);
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            _logger.LogError(error.Description);
                        }
                    }
                }
            }

            {
                var superUser = new BlazorPortalUser("Giovanni E.", "Nocco")
                {
                    Email = "giovanni.nocco@genocs.com",
                    UserName = "nocco",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    CreatedOn = DateTime.Now,
                    IsActive = true
                };
                var superUserInDb = await _userManager.FindByEmailAsync(superUser.Email);
                if (superUserInDb == null)
                {
                    await _userManager.CreateAsync(superUser, UserConstants.DefaultPassword);
                    var result = await _userManager.AddToRoleAsync(superUser, RoleConstants.BasicRole);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation(_localizer["Seeded Default BasicRole User."]);
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            _logger.LogError(error.Description);
                        }
                    }
                }
            }

            foreach (string permission in Permissions.GetRegisteredPermissions())
            {
                await _roleManager.AddPermissionClaim(adminRoleInDb, permission);
                await _roleManager.AddPermissionClaim(basicRoleInDb, permission);
            }

        }).GetAwaiter().GetResult();
    }

    private void AddBasicUser()
    {
        Task.Run(async () =>
        {
            // Check if Role Exists
            var basicRole = new BlazorPortalRole(RoleConstants.BasicRole, _localizer["Basic role with default permissions"]);
            var basicRoleInDb = await _roleManager.FindByNameAsync(RoleConstants.BasicRole);
            if (basicRoleInDb == null)
            {
                await _roleManager.CreateAsync(basicRole);
                _logger.LogInformation(_localizer["Seeded Basic Role."]);
            }

            // Check if User Exists
            var basicUser = new BlazorPortalUser("John", "Doe")
            {
                Email = "john@genocs.com",
                UserName = "johndoe",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                CreatedOn = DateTime.Now,
                IsActive = true
            };

            var basicUserInDb = await _userManager.FindByEmailAsync(basicUser.Email);
            if (basicUserInDb == null)
            {
                await _userManager.CreateAsync(basicUser, UserConstants.DefaultPassword);
                await _userManager.AddToRoleAsync(basicUser, RoleConstants.BasicRole);
                _logger.LogInformation(_localizer["Seeded User with Basic Role."]);
            }
        }).GetAwaiter().GetResult();
    }
}