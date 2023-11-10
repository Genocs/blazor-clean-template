using GenocsBlazor.Application.Features.Products.Commands.AddEdit;
using GenocsBlazor.Application.Features.Products.Queries.GetAllPaged;
using GenocsBlazor.Application.Requests.Catalog;
using GenocsBlazor.Shared.Wrapper;

namespace GenocsBlazor.Client.Infrastructure.Managers.Catalog.Product;

public interface IProductManager : IManager
{
    Task<PaginatedResult<GetAllPagedProductsResponse>> GetProductsAsync(GetAllPagedProductsRequest request);

    Task<IResult<string>> GetProductImageAsync(int id);

    Task<IResult<int>> SaveAsync(AddEditProductCommand request);

    Task<IResult<int>> DeleteAsync(int id);

    Task<IResult<string>> ExportToExcelAsync(string searchString = "");
}