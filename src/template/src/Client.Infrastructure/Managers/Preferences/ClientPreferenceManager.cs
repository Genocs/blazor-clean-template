using Blazored.LocalStorage;
using Genocs.BlazorClean.Template.Client.Infrastructure.Settings;
using Genocs.BlazorClean.Template.Shared.Constants.Storage;
using Genocs.BlazorClean.Template.Shared.Settings;
using Genocs.BlazorClean.Template.Shared.Wrapper;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Genocs.BlazorClean.Template.Client.Infrastructure.Managers.Preferences;

public class ClientPreferenceManager : IClientPreferenceManager
{
    private readonly ILocalStorageService _localStorageService;
    private readonly IStringLocalizer<ClientPreferenceManager> _localizer;

    public ClientPreferenceManager(
        ILocalStorageService localStorageService,
        IStringLocalizer<ClientPreferenceManager> localizer)
    {
        _localStorageService = localStorageService;
        _localizer = localizer;
    }

    public async Task<bool> ToggleDarkModeAsync()
    {
        var preference = await GetPreferenceAsync() as ClientPreference;
        if (preference != null)
        {
            preference.IsDarkMode = !preference.IsDarkMode;
            await SetPreferenceAsync(preference);
            return !preference.IsDarkMode;
        }

        return false;
    }

    public async Task<bool> ToggleLayoutDirection()
    {
        var preference = await GetPreferenceAsync() as ClientPreference;
        if (preference != null)
        {
            preference.IsRTL = !preference.IsRTL;
            await SetPreferenceAsync(preference);
            return preference.IsRTL;
        }

        return false;
    }

    public async Task<IResult> ChangeLanguageAsync(string languageCode)
    {
        var preference = await GetPreferenceAsync() as ClientPreference;
        if (preference != null)
        {
            preference.LanguageCode = languageCode;
            await SetPreferenceAsync(preference);
            return new Result
            {
                Succeeded = true,
                Messages = new List<string> { _localizer["Client Language has been changed"] }
            };
        }

        return new Result
        {
            Succeeded = false,
            Messages = new List<string> { _localizer["Failed to get client preferences"] }
        };
    }

    public async Task<MudTheme> GetCurrentThemeAsync()
    {
        var preference = await GetPreferenceAsync() as ClientPreference;
        if (preference != null)
        {
            if (preference.IsDarkMode) return GenocsPortalTheme.DarkTheme;
        }

        return GenocsPortalTheme.DefaultTheme;
    }

    public async Task<bool> IsRTL()
    {
        var preference = await GetPreferenceAsync() as ClientPreference;
        if (preference != null)
        {
            if (preference.IsDarkMode) return false;
        }

        return preference.IsRTL;
    }

    public async Task<IPreference> GetPreferenceAsync()
    {
        return await _localStorageService.GetItemAsync<ClientPreference>(StorageConstants.Local.Preference) ?? new ClientPreference();
    }

    public async Task SetPreferenceAsync(IPreference preference)
    {
        await _localStorageService.SetItemAsync(StorageConstants.Local.Preference, preference as ClientPreference);
    }
}