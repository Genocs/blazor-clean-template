using AutoMapper;
using GenocsBlazor.Infrastructure.Models.Identity;
using GenocsBlazor.Application.Responses.Identity;

namespace GenocsBlazor.Infrastructure.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserResponse, BlazorPortalUser>().ReverseMap();
            CreateMap<ChatUserResponse, BlazorPortalUser>().ReverseMap()
                .ForMember(dest => dest.EmailAddress, source => source.MapFrom(source => source.Email)); //Specific Mapping
        }
    }
}