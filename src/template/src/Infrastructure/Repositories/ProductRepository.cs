using Genocs.BlazorClean.Template.Application.Interfaces.Repositories;
using Genocs.BlazorClean.Template.Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;

namespace Genocs.BlazorClean.Template.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly IRepositoryAsync<Product, int> _repository;

    public ProductRepository(IRepositoryAsync<Product, int> repository)
    {
        _repository = repository;
    }

    public async Task<bool> IsBrandUsed(int brandId)
    {
        return await _repository.Entities.AnyAsync(b => b.BrandId == brandId);
    }
}