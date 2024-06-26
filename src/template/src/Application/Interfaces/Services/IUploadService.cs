using Genocs.BlazorClean.Template.Application.Requests;

namespace Genocs.BlazorClean.Template.Application.Interfaces.Services;

public interface IUploadService
{
    string UploadAsync(UploadRequest request);
}