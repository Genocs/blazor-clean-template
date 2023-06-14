using AutoMapper;
using GenocsBlazor.Application.Requests.Identity;
using GenocsBlazor.Application.Responses.Identity;
using GenocsBlazor.Infrastructure.Models.Identity;

namespace GenocsBlazor.Infrastructure.Mappings
{
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
}