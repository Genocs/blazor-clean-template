using Genocs.BlazorClean.Template.Application.Interfaces.Services;
using Genocs.BlazorClean.Template.Application.Interfaces.Services.Identity;
using Genocs.BlazorClean.Template.Application.Requests.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Genocs.BlazorClean.Template.Server.Controllers.Identity;

[Route("api/identity/token")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly ITokenService _identityService;

    public TokenController(ITokenService identityService, ICurrentUserService currentUserService)
    {
        _identityService = identityService;
    }

    /// <summary>
    /// Get Token (Email, Password).
    /// </summary>
    /// <param name="model">The model</param>
    /// <returns>Status 200 OK.</returns>
    [HttpPost]
    public async Task<ActionResult> GetAsync(TokenRequest model)
    {
        var response = await _identityService.LoginAsync(model);
        return Ok(response);
    }

    /// <summary>
    /// Refresh Token.
    /// </summary>
    /// <param name="model"></param>
    /// <returns>Status 200 OK.</returns>
    [HttpPost("refresh")]
    public async Task<ActionResult> RefreshAsync([FromBody] RefreshTokenRequest model)
    {
        var response = await _identityService.GetRefreshTokenAsync(model);
        return Ok(response);
    }
}