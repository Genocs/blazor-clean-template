using Genocs.BlazorClean.Template.Shared.Wrapper;
using GenocsBlazor.Application.Interfaces.Chat;
using GenocsBlazor.Application.Models.Chat;
using GenocsBlazor.Application.Responses.Identity;

namespace GenocsBlazor.Client.Infrastructure.Managers.Communication;

public interface IChatManager : IManager
{
    Task<IResult<IEnumerable<ChatUserResponse>>> GetChatUsersAsync();

    Task<IResult> SaveMessageAsync(ChatHistory<IChatUser> chatHistory);

    Task<IResult<IEnumerable<ChatHistoryResponse>>> GetChatHistoryAsync(string cId);
}