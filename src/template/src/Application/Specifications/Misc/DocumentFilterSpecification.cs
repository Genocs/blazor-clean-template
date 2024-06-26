using Genocs.BlazorClean.Template.Application.Specifications.Base;
using Genocs.BlazorClean.Template.Domain.Entities.Misc;

namespace Genocs.BlazorClean.Template.Application.Specifications.Misc;

public class DocumentFilterSpecification : GenocsSpecification<Document>
{
    public DocumentFilterSpecification(string searchString, string userId)
    {
        if (!string.IsNullOrEmpty(searchString))
        {
            Criteria = p => (p.Title.Contains(searchString) || p.Description.Contains(searchString)) && (p.IsPublic == true || (p.IsPublic == false && p.CreatedBy == userId));
        }
        else
        {
            Criteria = p => (p.IsPublic == true || (p.IsPublic == false && p.CreatedBy == userId));
        }
    }
}