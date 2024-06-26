using Microsoft.Extensions.Localization;

namespace GenocsBlazor.Server.Localization;

internal class ServerLocalizer<T>
    where T : class
{
    public IStringLocalizer<T> Localizer { get; }

    public ServerLocalizer(IStringLocalizer<T> localizer)
    {
        Localizer = localizer;
    }
}
