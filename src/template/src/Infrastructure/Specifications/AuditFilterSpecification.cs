using GenocsBlazor.Application.Specifications.Base;
using GenocsBlazor.Infrastructure.Models.Audit;

namespace GenocsBlazor.Infrastructure.Specifications;

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