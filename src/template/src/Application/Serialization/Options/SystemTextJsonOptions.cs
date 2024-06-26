using System.Text.Json;
using Genocs.BlazorClean.Template.Application.Interfaces.Serialization.Options;

namespace Genocs.BlazorClean.Template.Application.Serialization.Options;

public class SystemTextJsonOptions : IJsonSerializerOptions
{
    public JsonSerializerOptions JsonSerializerOptions { get; } = new();
}