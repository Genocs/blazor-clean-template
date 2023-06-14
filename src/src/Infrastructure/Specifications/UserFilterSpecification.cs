using GenocsBlazor.Infrastructure.Models.Identity;
using GenocsBlazor.Application.Specifications.Base;

namespace GenocsBlazor.Infrastructure.Specifications
{
    public class UserFilterSpecification : HeroSpecification<BlazorPortalUser>
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
}