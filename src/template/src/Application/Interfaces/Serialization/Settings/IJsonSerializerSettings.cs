using Newtonsoft.Json;

namespace Genocs.BlazorClean.Template.Application.Interfaces.Serialization.Settings;

public interface IJsonSerializerSettings
{
    /// <summary>
    /// Settings for <see cref="Newtonsoft.Json"/>.
    /// </summary>
    public JsonSerializerSettings JsonSerializerSettings { get; }
}