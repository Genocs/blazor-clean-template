using Genocs.BlazorClean.Template.Application.Features.Brands.Commands.AddEdit;
using Genocs.BlazorClean.Template.Application.Features.Brands.Commands.Import;
using Genocs.BlazorClean.Template.Application.Features.Brands.Queries.GetAll;
using Genocs.BlazorClean.Template.Client.Infrastructure.Extensions;
using Genocs.BlazorClean.Template.Shared.Wrapper;
using System.Net.Http.Json;

namespace Genocs.BlazorClean.Template.Client.Infrastructure.Managers.Catalog.Brand;

public class BrandManager : IBrandManager
{
    private readonly HttpClient _httpClient;

    public BrandManager(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IResult<string>> ExportToExcelAsync(string searchString = "")
    {
        var response = await _httpClient.GetAsync(string.IsNullOrWhiteSpace(searchString)
            ? Routes.BrandsEndpoints.Export
            : Routes.BrandsEndpoints.ExportFiltered(searchString));
        return await response.ToResult<string>();
    }

    public async Task<IResult<int>> DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"{Routes.BrandsEndpoints.Delete}/{id}");
        return await response.ToResult<int>();
    }

    public async Task<IResult<List<GetAllBrandsResponse>>> GetAllAsync()
    {
        var response = await _httpClient.GetAsync(Routes.BrandsEndpoints.GetAll);
        return await response.ToResult<List<GetAllBrandsResponse>>();
    }

    public async Task<IResult<int>> SaveAsync(AddEditBrandCommand request)
    {
        var response = await _httpClient.PostAsJsonAsync(Routes.BrandsEndpoints.Save, request);
        return await response.ToResult<int>();
    }

    public async Task<IResult<int>> ImportAsync(ImportBrandsCommand request)
    {
        var response = await _httpClient.PostAsJsonAsync(Routes.BrandsEndpoints.Import, request);
        return await response.ToResult<int>();
    }
}