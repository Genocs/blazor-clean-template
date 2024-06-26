using Genocs.BlazorClean.Template.Application.Interfaces.Common;

namespace Genocs.BlazorClean.Template.Application.Interfaces.Services;

public interface ICurrentUserService : IService
{
    string UserId { get; }
}