using AutoMapper;
using Genocs.BlazorClean.Template.Infrastructure.Models.Identity;
using Genocs.BlazorClean.Template.Application.Interfaces.Chat;
using Genocs.BlazorClean.Template.Application.Models.Chat;

namespace Genocs.BlazorClean.Template.Infrastructure.Mappings;

public class ChatHistoryProfile : Profile
{
    public ChatHistoryProfile()
    {
        CreateMap<ChatHistory<IChatUser>, ChatHistory<BlazorPortalUser>>().ReverseMap();
    }
}