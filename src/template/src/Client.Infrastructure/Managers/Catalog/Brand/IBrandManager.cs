using Genocs.BlazorClean.Template.Shared.Wrapper;
using GenocsBlazor.Application.Features.Brands.Commands.AddEdit;
using GenocsBlazor.Application.Features.Brands.Commands.Import;
using GenocsBlazor.Application.Features.Brands.Queries.GetAll;

namespace GenocsBlazor.Client.Infrastructure.Managers.Catalog.Brand;

public interface IBrandManager : IManager
{
    Task<IResult<List<GetAllBrandsResponse>>> GetAllAsync();

    Task<IResult<int>> SaveAsync(AddEditBrandCommand request);

    Task<IResult<int>> DeleteAsync(int id);

    Task<IResult<string>> ExportToExcelAsync(string searchString = "");

    Task<IResult<int>> ImportAsync(ImportBrandsCommand request);
}