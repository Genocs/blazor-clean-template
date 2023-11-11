using GenocsBlazor.Application.Responses.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using GenocsBlazor.Application.Interfaces.Chat;
using GenocsBlazor.Application.Models.Chat;
using Genocs.BlazorClean.Template.Shared.Wrapper;

namespace GenocsBlazor.Application.Interfaces.Services
{
    public interface IChatService
    {
        Task<Result<IEnumerable<ChatUserResponse>>> GetChatUsersAsync(string userId);

        Task<IResult> SaveMessageAsync(ChatHistory<IChatUser> message);

        Task<Result<IEnumerable<ChatHistoryResponse>>> GetChatHistoryAsync(string userId, string contactId);
    }
}