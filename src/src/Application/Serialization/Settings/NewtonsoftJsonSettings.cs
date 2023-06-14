
using GenocsBlazor.Application.Interfaces.Serialization.Settings;
using Newtonsoft.Json;

namespace GenocsBlazor.Application.Serialization.Settings
{
    public class NewtonsoftJsonSettings : IJsonSerializerSettings
    {
        public JsonSerializerSettings JsonSerializerSettings { get; } = new();
    }
}