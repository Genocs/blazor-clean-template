using Genocs.BlazorClean.Template.Client.Extensions;
using Genocs.BlazorClean.Template.Client.Infrastructure.Managers.Preferences;
using Genocs.BlazorClean.Template.Client.Infrastructure.Settings;
using Genocs.BlazorClean.Template.Shared.Constants.Localization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Globalization;

namespace Genocs.BlazorClean.Template.Client;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder
                      .CreateDefault(args)
                      .AddRootComponents()
                      .AddClientServices();
        var host = builder.Build();
        var storageService = host.Services.GetRequiredService<ClientPreferenceManager>();

        if (storageService != null)
        {
            CultureInfo culture;
            var preference = await storageService.GetPreferenceAsync() as ClientPreference;
            if (preference != null)
                culture = new CultureInfo(preference.LanguageCode);
            else
                culture = new CultureInfo(LocalizationConstants.SupportedLanguages.FirstOrDefault()?.Code ?? "en-US");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }

        await builder.Build().RunAsync();
    }
}