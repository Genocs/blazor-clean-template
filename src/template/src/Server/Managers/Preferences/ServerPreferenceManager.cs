using Genocs.BlazorClean.Template.Shared.Constants.Storage;
using Genocs.BlazorClean.Template.Shared.Settings;
using Genocs.BlazorClean.Template.Shared.Wrapper;
using Genocs.BlazorClean.Template.Application.Interfaces.Services.Storage;
using Genocs.BlazorClean.Template.Server.Settings;
using Microsoft.Extensions.Localization;

namespace Genocs.BlazorClean.Template.Server.Managers.Preferences;

public class ServerPreferenceManager : IServerPreferenceManager
{
    private readonly IServerStorageService _serverStorageService;
    private readonly IStringLocalizer<ServerPreferenceManager> _localizer;

    public ServerPreferenceManager(
        IServerStorageService serverStorageService,
        IStringLocalizer<ServerPreferenceManager> localizer)
    {
        _serverStorageService = serverStorageService;
        _localizer = localizer;
    }

    public async Task<Genocs.BlazorClean.Template.Shared.Wrapper.IResult> ChangeLanguageAsync(string languageCode)
    {
        var preference = await GetPreferenceAsync() as ServerPreference;
        if (preference != null)
        {
            preference.LanguageCode = languageCode;
            await SetPreferenceAsync(preference);
            return new Result
            {
                Succeeded = true,
                Messages = new List<string> { _localizer["Server Language has been changed"] }
            };
        }

        return new Result
        {
            Succeeded = false,
            Messages = new List<string> { _localizer["Failed to get server preferences"] }
        };
    }

    public async Task<IPreference> GetPreferenceAsync()
    {
        return await _serverStorageService.GetItemAsync<ServerPreference>(StorageConstants.Server.Preference) ?? new ServerPreference();
    }

    public async Task SetPreferenceAsync(IPreference preference)
    {
        await _serverStorageService.SetItemAsync(StorageConstants.Server.Preference, preference as ServerPreference);
    }
}