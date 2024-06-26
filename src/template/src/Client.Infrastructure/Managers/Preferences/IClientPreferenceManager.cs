using Genocs.BlazorClean.Template.Shared.Managers;
using MudBlazor;

namespace Genocs.BlazorClean.Template.Client.Infrastructure.Managers.Preferences;

public interface IClientPreferenceManager : IPreferenceManager
{
    Task<MudTheme> GetCurrentThemeAsync();

    Task<bool> ToggleDarkModeAsync();
}