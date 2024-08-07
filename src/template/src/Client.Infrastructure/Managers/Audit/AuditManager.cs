﻿using Genocs.BlazorClean.Template.Application.Responses.Audit;
using Genocs.BlazorClean.Template.Client.Infrastructure.Extensions;
using Genocs.BlazorClean.Template.Shared.Wrapper;

namespace Genocs.BlazorClean.Template.Client.Infrastructure.Managers.Audit;

public class AuditManager : IAuditManager
{
    private readonly HttpClient _httpClient;

    public AuditManager(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IResult<IEnumerable<AuditResponse>>> GetCurrentUserTrailsAsync()
    {
        var response = await _httpClient.GetAsync(Routes.AuditEndpoints.GetCurrentUserTrails);
        var data = await response.ToResult<IEnumerable<AuditResponse>>();
        return data;
    }

    public async Task<IResult<string>> DownloadFileAsync(string searchString = "", bool searchInOldValues = false, bool searchInNewValues = false)
    {
        var response = await _httpClient.GetAsync(string.IsNullOrWhiteSpace(searchString)
            ? Routes.AuditEndpoints.DownloadFile
            : Routes.AuditEndpoints.DownloadFileFiltered(searchString, searchInOldValues, searchInNewValues));
        return await response.ToResult<string>();
    }
}