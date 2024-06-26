using Genocs.BlazorClean.Template.Application.Interfaces.Repositories;
using Genocs.BlazorClean.Template.Domain.Entities.Catalog;

namespace Genocs.BlazorClean.Template.Infrastructure.Repositories;

public class BrandRepository : IBrandRepository
{
    private readonly IRepositoryAsync<Brand, int> _repository;

    public BrandRepository(IRepositoryAsync<Brand, int> repository)
    {
        _repository = repository;
    }
}