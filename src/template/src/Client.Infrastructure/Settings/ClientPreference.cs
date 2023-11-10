using GenocsBlazor.Shared.Constants.Localization;
using GenocsBlazor.Shared.Settings;

namespace GenocsBlazor.Client.Infrastructure.Settings;

public record ClientPreference : IPreference
{
    public bool IsDarkMode { get; set; }
    public bool IsRTL { get; set; }
    public bool IsDrawerOpen { get; set; }
    public string PrimaryColor { get; set; }
    public string LanguageCode { get; set; } = LocalizationConstants.SupportedLanguages.FirstOrDefault()?.Code ?? "en-US";
}