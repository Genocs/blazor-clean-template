﻿using GenocsBlazor.Shared.Settings;
using GenocsBlazor.Shared.Wrapper;
using System.Threading.Tasks;

namespace GenocsBlazor.Shared.Managers;

/// <summary>
/// The Preference Manager Interface definition.
/// </summary>
public interface IPreferenceManager
{
    /// <summary>
    /// Preference setter.
    /// </summary>
    /// <param name="preference">The preference</param>
    /// <returns></returns>
    Task SetPreference(IPreference preference);

    /// <summary>
    /// Preference getter.
    /// </summary>
    /// <returns>The preference settings</returns>
    Task<IPreference> GetPreference();

    /// <summary>
    /// Language change.
    /// </summary>
    /// <param name="languageCode">The language code</param>
    /// <returns></returns>
    Task<IResult> ChangeLanguageAsync(string languageCode);
}