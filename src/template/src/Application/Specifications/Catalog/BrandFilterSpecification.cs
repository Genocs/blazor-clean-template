using Genocs.BlazorClean.Template.Application.Specifications.Base;
using Genocs.BlazorClean.Template.Domain.Entities.Catalog;

namespace Genocs.BlazorClean.Template.Application.Specifications.Catalog;

public class BrandFilterSpecification : GenocsSpecification<Brand>
{
    public BrandFilterSpecification(string searchString)
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
