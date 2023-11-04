using AutoMapper;
using GenocsBlazor.Application.Interfaces.Chat;
using GenocsBlazor.Application.Models.Chat;
using GenocsBlazor.Infrastructure.Models.Identity;

namespace GenocsBlazor.Infrastructure.Mappings
{
    public class ChatHistoryProfile : Profile
    {
        public ChatHistoryProfile()
        {
            CreateMap<ChatHistory<IChatUser>, ChatHistory<BlazorPortalUser>>().ReverseMap();
        }
    }
}