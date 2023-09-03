using GenocsBlazor.Application.Specifications.Base;
using GenocsBlazor.Infrastructure.Models.Identity;

namespace GenocsBlazor.Infrastructure.Specifications;

public class UserFilterSpecification : GenocsSpecification<BlazorPortalUser>
{
    public UserFilterSpecification(string searchString)
    {
        if (!string.IsNullOrEmpty(searchString))
        {
            Criteria = p => p.FirstName.Contains(searchString) || p.LastName.Contains(searchString) || p.Email.Contains(searchString) || p.PhoneNumber.Contains(searchString) || p.UserName.Contains(searchString);
        }
        else
        {
            Criteria = p => true;
        }
    }
}