using Genocs.BlazorClean.Template.Domain.Contracts;

namespace Genocs.BlazorClean.Template.Domain.Entities.Catalog;

public class Brand : AuditableEntity<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Tax { get; set; }
}