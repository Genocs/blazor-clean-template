using AutoMapper;
using GenocsBlazor.Application.Requests.Identity;
using GenocsBlazor.Application.Responses.Identity;

namespace GenocsBlazor.Client.Infrastructure.Mappings;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<PermissionResponse, PermissionRequest>().ReverseMap();
        CreateMap<RoleClaimResponse, RoleClaimRequest>().ReverseMap();
    }
}