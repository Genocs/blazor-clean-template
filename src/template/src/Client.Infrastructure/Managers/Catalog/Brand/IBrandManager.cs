using Genocs.BlazorClean.Template.Application.Features.Brands.Commands.AddEdit;
using Genocs.BlazorClean.Template.Application.Features.Brands.Commands.Import;
using Genocs.BlazorClean.Template.Application.Features.Brands.Queries.GetAll;
using Genocs.BlazorClean.Template.Shared.Wrapper;

namespace Genocs.BlazorClean.Template.Client.Infrastructure.Managers.Catalog.Brand;

public interface IBrandManager : IManager
{
    Task<IResult<List<GetAllBrandsResponse>>> GetAllAsync();

    Task<IResult<int>> SaveAsync(AddEditBrandCommand request);

    Task<IResult<int>> DeleteAsync(int id);

    Task<IResult<string>> ExportToExcelAsync(string searchString = "");

    Task<IResult<int>> ImportAsync(ImportBrandsCommand request);
}