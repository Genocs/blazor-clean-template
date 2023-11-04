using GenocsBlazor.Application.Requests;

namespace GenocsBlazor.Application.Interfaces.Services
{
    public interface IUploadService
    {
        string UploadAsync(UploadRequest request);
    }
}