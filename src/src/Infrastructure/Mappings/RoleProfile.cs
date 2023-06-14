using AutoMapper;
using GenocsBlazor.Infrastructure.Models.Identity;
using GenocsBlazor.Application.Responses.Identity;

namespace GenocsBlazor.Infrastructure.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleResponse, BlazorPortalRole>().ReverseMap();
        }
    }
}