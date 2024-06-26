using System.Text.Json;

namespace Genocs.BlazorClean.Template.Application.Interfaces.Serialization.Options;

public interface IJsonSerializerOptions
{
    /// <summary>
    /// Options for <see cref="System.Text.Json"/>.
    /// </summary>
    public JsonSerializerOptions JsonSerializerOptions { get; }
}