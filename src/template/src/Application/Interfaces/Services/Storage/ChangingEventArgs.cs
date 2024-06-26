using System.Diagnostics.CodeAnalysis;

namespace Genocs.BlazorClean.Template.Application.Interfaces.Services.Storage;

[ExcludeFromCodeCoverage]
public class ChangingEventArgs : ChangedEventArgs
{
    public bool Cancel { get; set; }
}