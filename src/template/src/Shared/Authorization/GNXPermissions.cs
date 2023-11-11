using System.Collections.ObjectModel;

namespace Genocs.BlazorClean.Template.Shared.Authorization;

public static class GNXAction
{
    public const string View = nameof(View);
    public const string Search = nameof(Search);
    public const string Create = nameof(Create);
    public const string Update = nameof(Update);
    public const string Delete = nameof(Delete);
    public const string Export = nameof(Export);
    public const string Import = nameof(Import);
    public const string Generate = nameof(Generate); // This is duplicated use Create instead
    public const string Clean = nameof(Clean);
    public const string UpgradeSubscription = nameof(UpgradeSubscription);
    public const string Chat = nameof(Chat);
}

public static class GNXResource
{
    public const string Tenants = nameof(Tenants);
    public const string Dashboard = nameof(Dashboard);
    public const string Hangfire = nameof(Hangfire);
    public const string Users = nameof(Users);
    public const string UserRoles = nameof(UserRoles);
    public const string Communication = nameof(Communication);
    public const string Preferences = nameof(Preferences);
    public const string Roles = nameof(Roles);
    public const string RoleClaims = nameof(RoleClaims);
    public const string AuditTrails = nameof(AuditTrails);
    public const string Products = nameof(Products);
    public const string Brands = nameof(Brands);
    public const string Documents = nameof(Documents);
    public const string DocumentTypes = nameof(DocumentTypes);
    public const string DocumentExtendedAttributes = nameof(DocumentExtendedAttributes);
}

public static class GNXPermissions
{
    private static readonly GNXPermission[] _all = new GNXPermission[]
    {
        new("View Dashboard", GNXAction.View, GNXResource.Dashboard),
        new("View Hangfire", GNXAction.View, GNXResource.Hangfire),
        new("View Users", GNXAction.View, GNXResource.Users),
        new("Search Users", GNXAction.Search, GNXResource.Users),
        new("Create Users", GNXAction.Create, GNXResource.Users),
        new("Update Users", GNXAction.Update, GNXResource.Users),
        new("Delete Users", GNXAction.Delete, GNXResource.Users),
        new("Export Users", GNXAction.Export, GNXResource.Users),
        new("View UserRoles", GNXAction.View, GNXResource.UserRoles),
        new("Update UserRoles", GNXAction.Update, GNXResource.UserRoles),
        new("View Roles", GNXAction.View, GNXResource.Roles),
        new("Create Roles", GNXAction.Create, GNXResource.Roles),
        new("Update Roles", GNXAction.Update, GNXResource.Roles),
        new("Delete Roles", GNXAction.Delete, GNXResource.Roles),
        new("View RoleClaims", GNXAction.View, GNXResource.RoleClaims),
        new("Search RoleClaims", GNXAction.Search, GNXResource.RoleClaims),
        new("Create RoleClaims", GNXAction.Create, GNXResource.RoleClaims),
        new("Update RoleClaims", GNXAction.Update, GNXResource.RoleClaims),
        new("Delete RoleClaims", GNXAction.Delete, GNXResource.RoleClaims),
        new("View AuditTrails", GNXAction.View, GNXResource.AuditTrails),
        new("Search AuditTrails", GNXAction.Search, GNXResource.AuditTrails),
        new("Export AuditTrails", GNXAction.Search, GNXResource.AuditTrails),
        new("View Preferences", GNXAction.View, GNXResource.Products, IsBasic: true),

        // new("Search Preferences", GNXAction.Search, GNXResource.Preferences, IsBasic: true),
        // new("Create Preferences", GNXAction.Create, GNXResource.Preferences),
        new("Update Preferences", GNXAction.Update, GNXResource.Preferences),

        // new("Delete Preferences", GNXAction.Delete, GNXResource.Preferences),
        // new("Export Preferences", GNXAction.Export, GNXResource.Preferences),
        new("View Products", GNXAction.View, GNXResource.Products, IsBasic: true),
        new("Search Products", GNXAction.Search, GNXResource.Products, IsBasic: true),
        new("Create Products", GNXAction.Create, GNXResource.Products),
        new("Update Products", GNXAction.Update, GNXResource.Products),
        new("Delete Products", GNXAction.Delete, GNXResource.Products),
        new("Export Products", GNXAction.Export, GNXResource.Products),
        new("View Documents", GNXAction.View, GNXResource.Documents, IsBasic: true),
        new("Search Documents", GNXAction.Search, GNXResource.Documents, IsBasic: true),
        new("Create Documents", GNXAction.Create, GNXResource.Documents),
        new("Update Documents", GNXAction.Update, GNXResource.Documents),
        new("Delete Documents", GNXAction.Delete, GNXResource.Documents),
        new("Export Documents", GNXAction.Export, GNXResource.Documents),
        new("View Document Types", GNXAction.View, GNXResource.DocumentTypes, IsBasic: true),
        new("Search Document Types", GNXAction.Search, GNXResource.DocumentTypes, IsBasic: true),
        new("Create Document Types", GNXAction.Create, GNXResource.DocumentTypes),
        new("Update Document Types", GNXAction.Update, GNXResource.DocumentTypes),
        new("Delete Document Types", GNXAction.Delete, GNXResource.DocumentTypes),
        new("Export Document Types", GNXAction.Export, GNXResource.DocumentTypes),
        new("View Document Extended Attributes", GNXAction.View, GNXResource.DocumentExtendedAttributes, IsBasic: true),
        new("Search Document Extended Attributes", GNXAction.Search, GNXResource.DocumentExtendedAttributes, IsBasic: true),
        new("Create Document Extended Attributes", GNXAction.Create, GNXResource.DocumentExtendedAttributes),
        new("Update Document Extended Attributes", GNXAction.Update, GNXResource.DocumentExtendedAttributes),
        new("Delete Document Extended Attributes", GNXAction.Delete, GNXResource.DocumentExtendedAttributes),
        new("Export Document Extended Attributes", GNXAction.Export, GNXResource.DocumentExtendedAttributes),
        new("View Brands", GNXAction.View, GNXResource.Brands, IsBasic: true),
        new("Search Brands", GNXAction.Search, GNXResource.Brands, IsBasic: true),
        new("Create Brands", GNXAction.Create, GNXResource.Brands),
        new("Update Brands", GNXAction.Update, GNXResource.Brands),
        new("Delete Brands", GNXAction.Delete, GNXResource.Brands),
        new("Generate Brands", GNXAction.Generate, GNXResource.Brands),
        new("Clean Brands", GNXAction.Clean, GNXResource.Brands),
        new("View Tenants", GNXAction.View, GNXResource.Tenants, IsRoot: true),
        new("Create Tenants", GNXAction.Create, GNXResource.Tenants, IsRoot: true),
        new("Update Tenants", GNXAction.Update, GNXResource.Tenants, IsRoot: true),
        new("Upgrade Tenant Subscription", GNXAction.UpgradeSubscription, GNXResource.Tenants, IsRoot: true),
        new("Update Communication Chat", GNXAction.Chat, GNXResource.Communication, IsRoot: true)
    };

    public static IReadOnlyList<GNXPermission> All { get; } = new ReadOnlyCollection<GNXPermission>(_all);
    public static IReadOnlyList<GNXPermission> Root { get; } = new ReadOnlyCollection<GNXPermission>(_all.Where(p => p.IsRoot).ToArray());
    public static IReadOnlyList<GNXPermission> Admin { get; } = new ReadOnlyCollection<GNXPermission>(_all.Where(p => !p.IsRoot).ToArray());
    public static IReadOnlyList<GNXPermission> Basic { get; } = new ReadOnlyCollection<GNXPermission>(_all.Where(p => p.IsBasic).ToArray());
}

public record GNXPermission(string Description, string Action, string Resource, bool IsBasic = false, bool IsRoot = false)
{
    public string Name => NameFor(Action, Resource);
    public static string NameFor(string action, string resource) => $"Permissions.{resource}.{action}";
}