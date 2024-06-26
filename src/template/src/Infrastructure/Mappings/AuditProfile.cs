using AutoMapper;
using Genocs.BlazorClean.Template.Infrastructure.Models.Audit;
using Genocs.BlazorClean.Template.Application.Responses.Audit;

namespace Genocs.BlazorClean.Template.Infrastructure.Mappings;

public class AuditProfile : Profile
{
    public AuditProfile()
    {
        CreateMap<AuditResponse, Audit>().ReverseMap();
    }
}