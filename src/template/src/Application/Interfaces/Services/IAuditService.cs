﻿using Genocs.BlazorClean.Template.Application.Responses.Audit;
using Genocs.BlazorClean.Template.Shared.Wrapper;

namespace Genocs.BlazorClean.Template.Application.Interfaces.Services;

public interface IAuditService
{
    Task<IResult<IEnumerable<AuditResponse>>> GetCurrentUserTrailsAsync(string userId);

    Task<IResult<string>> ExportToExcelAsync(string userId, string searchString = "", bool searchInOldValues = false, bool searchInNewValues = false);
}