using Genocs.BlazorClean.Template.Shared.Constants.Localization;
using Genocs.BlazorClean.Template.Shared.Settings;

namespace Genocs.BlazorClean.Template.Client.Infrastructure.Settings;

public record ClientPreference : IPreference
{
    public bool IsDarkMode { get; set; }
    public bool IsRTL { get; set; }
    public bool IsDrawerOpen { get; set; }
    public string PrimaryColor { get; set; }
    public string LanguageCode { get; set; } = LocalizationConstants.SupportedLanguages.FirstOrDefault()?.Code ?? "en-US";
}