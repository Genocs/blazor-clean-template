﻿using Genocs.BlazorClean.Template.Shared.Wrapper;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Genocs.BlazorClean.Template.Client.Infrastructure.Extensions;

internal static class ResultExtensions
{
    internal static async Task<IResult<T>> ToResult<T>(this HttpResponseMessage response)
    {
        var responseAsString = await response.Content.ReadAsStringAsync();
        var responseObject = JsonSerializer.Deserialize<Result<T>>(responseAsString, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            ReferenceHandler = ReferenceHandler.Preserve
        });
        return responseObject;
    }

    internal static async Task<IResult> ToResult(this HttpResponseMessage response)
    {
        string responseAsString = await response.Content.ReadAsStringAsync();
        var responseObject = JsonSerializer.Deserialize<Result>(responseAsString, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            ReferenceHandler = ReferenceHandler.Preserve
        });
        return responseObject;
    }

    internal static async Task<PaginatedResult<T>> ToPaginatedResult<T>(this HttpResponseMessage response)
    {
        var responseAsString = await response.Content.ReadAsStringAsync();
        var responseObject = JsonSerializer.Deserialize<PaginatedResult<T>>(responseAsString, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        return responseObject;
    }
}