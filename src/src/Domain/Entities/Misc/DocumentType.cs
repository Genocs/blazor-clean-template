using GenocsBlazor.Domain.Contracts;

namespace GenocsBlazor.Domain.Entities.Misc;

public class DocumentType : AuditableEntity<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
}