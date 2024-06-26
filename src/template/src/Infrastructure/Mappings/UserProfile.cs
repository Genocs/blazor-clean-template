using AutoMapper;
using Genocs.BlazorClean.Template.Application.Responses.Identity;
using Genocs.BlazorClean.Template.Infrastructure.Models.Identity;

namespace Genocs.BlazorClean.Template.Infrastructure.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserResponse, BlazorPortalUser>().ReverseMap();
        CreateMap<ChatUserResponse, BlazorPortalUser>().ReverseMap()
            .ForMember(dest => dest.EmailAddress, source => source.MapFrom(source => source.Email)); //Specific Mapping
    }
}