﻿using Blazored.LocalStorage;
using Genocs.BlazorClean.Template.Shared.Constants.Application;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace Genocs.BlazorClean.Template.Client.Extensions;

public static class HubExtensions
{
    public static HubConnection TryInitialize(this HubConnection hubConnection, NavigationManager navigationManager, ILocalStorageService _localStorage)
    {
        if (hubConnection == null)
        {
            hubConnection = new HubConnectionBuilder()
                              .WithUrl(navigationManager.ToAbsoluteUri(ApplicationConstants.SignalR.HubUrl), options => {
                                  options.AccessTokenProvider = async () => (await _localStorage.GetItemAsync<string>("authToken"));
                              })
                              .WithAutomaticReconnect()
                              .Build();
        }

        return hubConnection;
    }

    public static HubConnection TryInitialize(this HubConnection hubConnection, NavigationManager navigationManager)
    {
        if (hubConnection == null)
        {
            hubConnection = new HubConnectionBuilder()
                              .WithUrl(navigationManager.ToAbsoluteUri(ApplicationConstants.SignalR.HubUrl))
                              .Build();
        }

        return hubConnection;
    }
}