using System.Collections.Generic;
using System.Threading.Tasks;
using GenocsBlazor.Application.Interfaces.Common;
using GenocsBlazor.Application.Requests.Identity;
using GenocsBlazor.Application.Responses.Identity;
using GenocsBlazor.Shared.Wrapper;

namespace GenocsBlazor.Application.Interfaces.Services.Identity
{
    public interface IRoleClaimService : IService
    {
        Task<Result<List<RoleClaimResponse>>> GetAllAsync();

        Task<int> GetCountAsync();

        Task<Result<RoleClaimResponse>> GetByIdAsync(int id);

        Task<Result<List<RoleClaimResponse>>> GetAllByRoleIdAsync(string roleId);

        Task<Result<string>> SaveAsync(RoleClaimRequest request);

        Task<Result<string>> DeleteAsync(int id);
    }
}