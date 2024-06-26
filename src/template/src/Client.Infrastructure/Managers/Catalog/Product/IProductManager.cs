using Genocs.BlazorClean.Template.Application.Features.Products.Commands.AddEdit;
using Genocs.BlazorClean.Template.Application.Features.Products.Queries.GetAllPaged;
using Genocs.BlazorClean.Template.Application.Requests.Catalog;
using Genocs.BlazorClean.Template.Shared.Wrapper;

namespace Genocs.BlazorClean.Template.Client.Infrastructure.Managers.Catalog.Product;

public interface IProductManager : IManager
{
    Task<PaginatedResult<GetAllPagedProductsResponse>> GetProductsAsync(GetAllPagedProductsRequest request);

    Task<IResult<string>> GetProductImageAsync(int id);

    Task<IResult<int>> SaveAsync(AddEditProductCommand request);

    Task<IResult<int>> DeleteAsync(int id);

    Task<IResult<string>> ExportToExcelAsync(string searchString = "");
}