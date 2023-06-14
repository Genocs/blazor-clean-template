using GenocsBlazor.Application.Interfaces.Services;
using System;

namespace GenocsBlazor.Infrastructure.Shared.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}