using AutoMapper;
using Genocs.BlazorClean.Template.Application.Responses.Identity;
using Genocs.BlazorClean.Template.Infrastructure.Models.Identity;

namespace Genocs.BlazorClean.Template.Infrastructure.Mappings;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<RoleResponse, BlazorPortalRole>().ReverseMap();
    }
}