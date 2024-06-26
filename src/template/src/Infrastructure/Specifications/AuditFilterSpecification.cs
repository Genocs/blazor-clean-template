using Genocs.BlazorClean.Template.Application.Specifications.Base;
using Genocs.BlazorClean.Template.Infrastructure.Models.Audit;

namespace Genocs.BlazorClean.Template.Infrastructure.Specifications;

public class AuditFilterSpecification : GenocsSpecification<Audit>
{
    public AuditFilterSpecification(string userId, string searchString, bool searchInOldValues, bool searchInNewValues)
    {
        if (!string.IsNullOrEmpty(searchString))
        {
            Criteria = p => (p.TableName.Contains(searchString) || searchInOldValues && p.OldValues.Contains(searchString) || searchInNewValues && p.NewValues.Contains(searchString)) && p.UserId == userId;
        }
        else
        {
            Criteria = p => p.UserId == userId;
        }
    }
}