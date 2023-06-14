using System.Text.Json;
using GenocsBlazor.Application.Interfaces.Serialization.Options;

namespace GenocsBlazor.Application.Serialization.Options
{
    public class SystemTextJsonOptions : IJsonSerializerOptions
    {
        public JsonSerializerOptions JsonSerializerOptions { get; } = new();
    }
}