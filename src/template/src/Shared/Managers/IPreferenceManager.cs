using Genocs.BlazorClean.Template.Shared.Settings;
using Genocs.BlazorClean.Template.Shared.Wrapper;

namespace Genocs.BlazorClean.Template.Shared.Managers;

/// <summary>
/// The Preference Manager Interface definition.
/// </summary>
public interface IPreferenceManager
{
    /// <summary>
    /// Preference setter.
    /// </summary>
    /// <param name="preference">The preference.</param>
    /// <returns></returns>
    Task SetPreferenceAsync(IPreference preference);

    /// <summary>
    /// Preference getter.
    /// </summary>
    /// <returns>The preference settings.</returns>
    Task<IPreference> GetPreferenceAsync();

    /// <summary>
    /// Language change.
    /// </summary>
    /// <param name="languageCode">The language code.</param>
    /// <returns></returns>
    Task<IResult> ChangeLanguageAsync(string languageCode);
}