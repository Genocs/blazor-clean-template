using GenocsBlazor.Application.Interfaces.Common;

namespace GenocsBlazor.Application.Interfaces.Services
{
    public interface ICurrentUserService : IService
    {
        string UserId { get; }
    }
}