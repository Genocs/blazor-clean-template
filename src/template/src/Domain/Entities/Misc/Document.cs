using Genocs.BlazorClean.Template.Domain.Contracts;
using Genocs.BlazorClean.Template.Domain.Entities.ExtendedAttributes;

namespace Genocs.BlazorClean.Template.Domain.Entities.Misc;

public class Document : AuditableEntityWithExtendedAttributes<int, int, Document, DocumentExtendedAttribute>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsPublic { get; set; } = false;
    public string URL { get; set; }
    public int DocumentTypeId { get; set; }
    public virtual DocumentType DocumentType { get; set; }
}