using Genocs.BlazorClean.Template.Shared.Constants.Localization;
using GenocsBlazor.Client.Extensions;
using GenocsBlazor.Client.Infrastructure.Managers.Preferences;
using GenocsBlazor.Client.Infrastructure.Settings;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Globalization;

namespace GenocsBlazor.Client;

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