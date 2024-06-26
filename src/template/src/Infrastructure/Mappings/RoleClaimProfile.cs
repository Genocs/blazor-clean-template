using AutoMapper;
using Genocs.BlazorClean.Template.Application.Requests.Identity;
using Genocs.BlazorClean.Template.Application.Responses.Identity;
using Genocs.BlazorClean.Template.Infrastructure.Models.Identity;

namespace Genocs.BlazorClean.Template.Infrastructure.Mappings;

public class RoleClaimProfile : Profile
{
    public RoleClaimProfile()
    {
        CreateMap<RoleClaimResponse, BlazorPortalRoleClaim>()
            .ForMember(nameof(BlazorPortalRoleClaim.ClaimType), opt => opt.MapFrom(c => c.Type))
            .ForMember(nameof(BlazorPortalRoleClaim.ClaimValue), opt => opt.MapFrom(c => c.Value))
            .ReverseMap();

        CreateMap<RoleClaimRequest, BlazorPortalRoleClaim>()
            .ForMember(nameof(BlazorPortalRoleClaim.ClaimType), opt => opt.MapFrom(c => c.Type))
            .ForMember(nameof(BlazorPortalRoleClaim.ClaimValue), opt => opt.MapFrom(c => c.Value))
            .ReverseMap();
    }
}