﻿using Toolbelt.Blazor;

namespace GenocsBlazor.Client.Infrastructure.Managers.Interceptors;

public interface IHttpInterceptorManager : IManager
{
    void RegisterEvent();

    Task InterceptBeforeHttpAsync(object sender, HttpClientInterceptorEventArgs e);

    void DisposeEvent();
}