using GenocsBlazor.Shared.Settings;
using GenocsBlazor.Shared.Wrapper;
using System.Threading.Tasks;

namespace GenocsBlazor.Shared.Managers
{
    public interface IPreferenceManager
    {
        Task SetPreference(IPreference preference);

        Task<IPreference> GetPreference();

        Task<IResult> ChangeLanguageAsync(string languageCode);
    }
}