using GenocsBlazor.Shared.Managers;
using MudBlazor;

namespace GenocsBlazor.Client.Infrastructure.Managers.Preferences;

public interface IClientPreferenceManager : IPreferenceManager
{
    Task<MudTheme> GetCurrentThemeAsync();

    Task<bool> ToggleDarkModeAsync();
}