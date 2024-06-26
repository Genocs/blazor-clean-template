namespace Genocs.BlazorClean.Template.Application.Interfaces.Repositories;

public interface IProductRepository
{
    Task<bool> IsBrandUsed(int brandId);
}