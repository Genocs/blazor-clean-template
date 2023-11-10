﻿using GenocsBlazor.Application.Interfaces.Services.Storage;
using GenocsBlazor.Server.Settings;
using GenocsBlazor.Shared.Constants.Storage;
using GenocsBlazor.Shared.Settings;
using GenocsBlazor.Shared.Wrapper;
using Microsoft.Extensions.Localization;

namespace GenocsBlazor.Server.Managers.Preferences;

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

    public async Task<Shared.Wrapper.IResult> ChangeLanguageAsync(string languageCode)
    {
        var preference = await GetPreference() as ServerPreference;
        if (preference != null)
        {
            preference.LanguageCode = languageCode;
            await SetPreference(preference);
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

    public async Task<IPreference> GetPreference()
    {
        return await _serverStorageService.GetItemAsync<ServerPreference>(StorageConstants.Server.Preference) ?? new ServerPreference();
    }

    public async Task SetPreference(IPreference preference)
    {
        await _serverStorageService.SetItemAsync(StorageConstants.Server.Preference, preference as ServerPreference);
    }
}