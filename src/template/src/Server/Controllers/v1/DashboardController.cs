﻿using Genocs.BlazorClean.Template.Shared.Constants.Permission;
using Genocs.BlazorClean.Template.Application.Features.Dashboards.Queries.GetData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Genocs.BlazorClean.Template.Server.Controllers.v1;

[ApiController]
public class DashboardController : BaseApiController<DashboardController>
{
    /// <summary>
    /// Get Dashboard Data
    /// </summary>
    /// <returns>Status 200 OK </returns>
    [Authorize(Policy = Permissions.Dashboards.View)]
    [HttpGet]
    public async Task<IActionResult> GetDataAsync()
    {
        var result = await _mediator.Send(new GetDashboardDataQuery());
        return Ok(result);
    }
}