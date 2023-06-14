using System.Linq;
using GenocsBlazor.Shared.Constants.Localization;
using GenocsBlazor.Shared.Settings;

namespace GenocsBlazor.Server.Settings
{
    public record ServerPreference : IPreference
    {
        public string LanguageCode { get; set; } = LocalizationConstants.SupportedLanguages.FirstOrDefault()?.Code ?? "en-US";

        //TODO - add server preferences
    }
}