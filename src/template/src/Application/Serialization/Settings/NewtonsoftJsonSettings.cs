using Genocs.BlazorClean.Template.Application.Interfaces.Serialization.Settings;
using Newtonsoft.Json;

namespace Genocs.BlazorClean.Template.Application.Serialization.Settings;

public class NewtonsoftJsonSettings : IJsonSerializerSettings
{
    public JsonSerializerSettings JsonSerializerSettings { get; } = new();
}