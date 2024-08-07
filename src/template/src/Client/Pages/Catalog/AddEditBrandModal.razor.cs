﻿using Blazored.FluentValidation;
using Genocs.BlazorClean.Template.Application.Features.Brands.Commands.AddEdit;
using Genocs.BlazorClean.Template.Client.Extensions;
using Genocs.BlazorClean.Template.Client.Infrastructure.Managers.Catalog.Brand;
using Genocs.BlazorClean.Template.Shared.Constants.Application;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;

namespace Genocs.BlazorClean.Template.Client.Pages.Catalog;

public partial class AddEditBrandModal
{
    [Inject] private IBrandManager BrandManager { get; set; }

    [Parameter] public AddEditBrandCommand AddEditBrandModel { get; set; } = new();
    [CascadingParameter] private MudDialogInstance MudDialog { get; set; }
    [CascadingParameter] private HubConnection HubConnection { get; set; }

    private FluentValidationValidator _fluentValidationValidator;
    private bool Validated => _fluentValidationValidator.Validate(options => { options.IncludeAllRuleSets(); });

    public void Cancel()
    {
        MudDialog.Cancel();
    }

    private async Task SaveAsync()
    {
        var response = await BrandManager.SaveAsync(AddEditBrandModel);
        if (response.Succeeded)
        {
            _snackBar.Add(response.Messages[0], Severity.Success);
            MudDialog.Close();
        }
        else
        {
            foreach (var message in response.Messages)
            {
                _snackBar.Add(message, Severity.Error);
            }
        }
        await HubConnection.SendAsync(ApplicationConstants.SignalR.SendUpdateDashboard);
    }

    protected override async Task OnInitializedAsync()
    {
        await LoadDataAsync();
        HubConnection = HubConnection.TryInitialize(_navigationManager, _localStorage);
        if (HubConnection.State == HubConnectionState.Disconnected)
        {
            await HubConnection.StartAsync();
        }
    }

    private async Task LoadDataAsync()
    {
        await Task.CompletedTask;
    }
}