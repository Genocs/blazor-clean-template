using Genocs.BlazorClean.Template.Application.Interfaces.Services;

namespace Genocs.BlazorClean.Template.Infrastructure.Shared.Services;

public class SystemDateTimeService : IDateTimeService
{
    public DateTime NowUtc => DateTime.UtcNow;
}