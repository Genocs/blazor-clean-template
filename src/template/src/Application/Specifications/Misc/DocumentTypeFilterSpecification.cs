using Genocs.BlazorClean.Template.Application.Specifications.Base;
using Genocs.BlazorClean.Template.Domain.Entities.Misc;

namespace Genocs.BlazorClean.Template.Application.Specifications.Misc;

public class DocumentTypeFilterSpecification : GenocsSpecification<DocumentType>
{
    public DocumentTypeFilterSpecification(string searchString)
    {
        if (!string.IsNullOrEmpty(searchString))
        {
            Criteria = p => p.Name.Contains(searchString) || p.Description.Contains(searchString);
        }
        else
        {
            Criteria = p => true;
        }
    }
}