using Genocs.BlazorClean.Template.Application.Specifications.Base;
using Genocs.BlazorClean.Template.Domain.Entities.Catalog;

namespace Genocs.BlazorClean.Template.Application.Specifications.Catalog;

public class ProductFilterSpecification : GenocsSpecification<Product>
{
    public ProductFilterSpecification(string searchString)
    {
        Includes.Add(a => a.Brand);
        if (!string.IsNullOrEmpty(searchString))
        {
            Criteria = p => p.Barcode != null && (p.Name.Contains(searchString) || p.Description.Contains(searchString) || p.Barcode.Contains(searchString) || p.Brand.Name.Contains(searchString));
        }
        else
        {
            Criteria = p => p.Barcode != null;
        }
    }
}