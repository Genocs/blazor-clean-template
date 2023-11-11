using Genocs.BlazorClean.Template.Shared.Constants.Permission;
using GenocsBlazor.Server.Managers.Preferences;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GenocsBlazor.Server.Controllers.Utilities;

[Route("api/[controller]")]
[ApiController]
public class PreferencesController : ControllerBase
{
    private readonly ServerPreferenceManager _serverPreferenceManager;

    public PreferencesController(ServerPreferenceManager serverPreferenceManager)
    {
        _serverPreferenceManager = serverPreferenceManager;
    }

    /// <summary>
    /// Change Language Preference
    /// </summary>
    /// <param name="languageCode"></param>
    /// <returns>Status 200 OK</returns>
    [Authorize(Policy = Permissions.Preferences.ChangeLanguage)]
    [HttpPost("changeLanguage")]
    public async Task<IActionResult> ChangeLanguageAsync(string languageCode)
    {
        var result = await _serverPreferenceManager.ChangeLanguageAsync(languageCode);
        return Ok(result);
    }

    //TODO - add actions
}