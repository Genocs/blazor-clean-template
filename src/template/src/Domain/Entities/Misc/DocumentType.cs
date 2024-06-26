using Genocs.BlazorClean.Template.Domain.Contracts;

namespace Genocs.BlazorClean.Template.Domain.Entities.Misc;

public class DocumentType : AuditableEntity<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
}