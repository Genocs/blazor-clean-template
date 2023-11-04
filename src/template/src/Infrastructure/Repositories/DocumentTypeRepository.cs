using GenocsBlazor.Application.Interfaces.Repositories;
using GenocsBlazor.Domain.Entities.Misc;

namespace GenocsBlazor.Infrastructure.Repositories;

public class DocumentTypeRepository : IDocumentTypeRepository
{
    private readonly IRepositoryAsync<DocumentType, int> _repository;

    public DocumentTypeRepository(IRepositoryAsync<DocumentType, int> repository)
    {
        _repository = repository;
    }
}