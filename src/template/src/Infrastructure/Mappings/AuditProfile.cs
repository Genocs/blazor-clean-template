using AutoMapper;
using GenocsBlazor.Application.Responses.Audit;
using GenocsBlazor.Infrastructure.Models.Audit;

namespace GenocsBlazor.Infrastructure.Mappings
{
    public class AuditProfile : Profile
    {
        public AuditProfile()
        {
            CreateMap<AuditResponse, Audit>().ReverseMap();
        }
    }
}