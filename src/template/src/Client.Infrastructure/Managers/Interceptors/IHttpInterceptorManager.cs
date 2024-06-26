using Toolbelt.Blazor;

namespace Genocs.BlazorClean.Template.Client.Infrastructure.Managers.Interceptors;

public interface IHttpInterceptorManager : IManager
{
    void RegisterEvent();

    Task InterceptBeforeHttpAsync(object sender, HttpClientInterceptorEventArgs e);

    void DisposeEvent();
}