﻿using Blazored.LocalStorage;
using Genocs.BlazorClean.Template.Shared.Constants.Permission;
using Genocs.BlazorClean.Template.Client.Infrastructure.Authentication;
using Genocs.BlazorClean.Template.Client.Infrastructure.Managers;
using Genocs.BlazorClean.Template.Client.Infrastructure.Managers.ExtendedAttribute;
using Genocs.BlazorClean.Template.Client.Infrastructure.Managers.Preferences;
using Genocs.BlazorClean.Template.Domain.Entities.ExtendedAttributes;
using Genocs.BlazorClean.Template.Domain.Entities.Misc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;
using System.Globalization;
using System.Reflection;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace Genocs.BlazorClean.Template.Client.Extensions;

public static class WebAssemblyHostBuilderExtensions
{
    private const string ClientName = "BlazorPortal.API";

    public static WebAssemblyHostBuilder AddRootComponents(this WebAssemblyHostBuilder builder)
    {
        builder.RootComponents.Add<App>("#app");

        return builder;
    }

    public static WebAssemblyHostBuilder AddClientServices(this WebAssemblyHostBuilder builder)
    {
        builder
            .Services
            .AddLocalization(options =>
            {
                options.ResourcesPath = "Resources";
            })
            .AddAuthorizationCore(options =>
            {
                RegisterPermissionClaims(options);
            })
            .AddBlazoredLocalStorage()
            .AddMudServices(configuration =>
            {
                configuration.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
                configuration.SnackbarConfiguration.HideTransitionDuration = 100;
                configuration.SnackbarConfiguration.ShowTransitionDuration = 100;
                configuration.SnackbarConfiguration.VisibleStateDuration = 3000;
                configuration.SnackbarConfiguration.ShowCloseIcon = false;
            })
            .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
            .AddScoped<ClientPreferenceManager>()
            .AddScoped<GenocsPortalStateProvider>()
            .AddScoped<AuthenticationStateProvider, GenocsPortalStateProvider>()
            .AddManagers()
            .AddExtendedAttributeManagers()
            .AddTransient<AuthenticationHeaderHandler>()
            .AddScoped(sp => sp
                .GetRequiredService<IHttpClientFactory>()
                .CreateClient(ClientName).EnableIntercept(sp))
            .AddHttpClient(ClientName, client =>
            {
                client.DefaultRequestHeaders.AcceptLanguage.Clear();
                client.DefaultRequestHeaders.AcceptLanguage.ParseAdd(CultureInfo.DefaultThreadCurrentCulture?.TwoLetterISOLanguageName);
                client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
            })
            .AddHttpMessageHandler<AuthenticationHeaderHandler>();
        builder.Services.AddHttpClientInterceptor();
        return builder;
    }

    public static IServiceCollection AddManagers(this IServiceCollection services)
    {
        var managers = typeof(IManager);

        var types = managers
            .Assembly
            .GetExportedTypes()
            .Where(t => t.IsClass && !t.IsAbstract)
            .Select(t => new
            {
                Service = t.GetInterface($"I{t.Name}"),
                Implementation = t
            })
            .Where(t => t.Service != null);

        foreach (var type in types)
        {
            if (managers.IsAssignableFrom(type.Service))
            {
                services.AddTransient(type.Service, type.Implementation);
            }
        }

        return services;
    }

    public static IServiceCollection AddExtendedAttributeManagers(this IServiceCollection services)
    {
        // TODO - add managers with reflection!

        return services
            .AddTransient(typeof(IExtendedAttributeManager<int, int, Document, DocumentExtendedAttribute>), typeof(ExtendedAttributeManager<int, int, Document, DocumentExtendedAttribute>));
    }

    private static void RegisterPermissionClaims(AuthorizationOptions options)
    {
        foreach (var prop in typeof(Permissions).GetNestedTypes().SelectMany(c => c.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)))
        {
            var propertyValue = prop.GetValue(null);
            if (propertyValue is not null)
            {
                options.AddPolicy(propertyValue.ToString(), policy => policy.RequireClaim(ApplicationClaimTypes.Permission, propertyValue.ToString()));
            }
        }
    }
}