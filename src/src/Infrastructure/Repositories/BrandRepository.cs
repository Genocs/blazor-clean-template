using GenocsBlazor.Application.Interfaces.Repositories;
using GenocsBlazor.Domain.Entities.Catalog;

namespace GenocsBlazor.Infrastructure.Repositories;

public class BrandRepository : IBrandRepository
{
    private readonly IRepositoryAsync<Brand, int> _repository;

    public BrandRepository(IRepositoryAsync<Brand, int> repository)
    {
        _repository = repository;
    }
}