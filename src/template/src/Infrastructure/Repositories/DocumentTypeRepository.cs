using Genocs.BlazorClean.Template.Application.Interfaces.Repositories;
using Genocs.BlazorClean.Template.Domain.Entities.Misc;

namespace Genocs.BlazorClean.Template.Infrastructure.Repositories;

public class DocumentTypeRepository : IDocumentTypeRepository
{
    private readonly IRepositoryAsync<DocumentType, int> _repository;

    public DocumentTypeRepository(IRepositoryAsync<DocumentType, int> repository)
    {
        _repository = repository;
    }
}