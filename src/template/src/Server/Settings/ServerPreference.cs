using System.Linq;
using Genocs.BlazorClean.Template.Shared.Constants.Localization;
using Genocs.BlazorClean.Template.Shared.Settings;

namespace Genocs.BlazorClean.Template.Server.Settings
{
    public record ServerPreference : IPreference
    {
        public string LanguageCode { get; set; } = LocalizationConstants.SupportedLanguages.FirstOrDefault()?.Code ?? "en-US";

        //TODO - add server preferences
    }
}