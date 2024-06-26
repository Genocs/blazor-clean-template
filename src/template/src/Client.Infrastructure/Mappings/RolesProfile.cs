using AutoMapper;
using Genocs.BlazorClean.Template.Application.Requests.Identity;
using Genocs.BlazorClean.Template.Application.Responses.Identity;

namespace Genocs.BlazorClean.Template.Client.Infrastructure.Mappings;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<PermissionResponse, PermissionRequest>().ReverseMap();
        CreateMap<RoleClaimResponse, RoleClaimRequest>().ReverseMap();
    }
}