﻿using AutoMapper;
using Genocs.BlazorClean.Template.Shared.Constants.Role;
using Genocs.BlazorClean.Template.Shared.Wrapper;
using GenocsBlazor.Application.Exceptions;
using GenocsBlazor.Application.Interfaces.Chat;
using GenocsBlazor.Application.Interfaces.Services;
using GenocsBlazor.Application.Interfaces.Services.Identity;
using GenocsBlazor.Application.Models.Chat;
using GenocsBlazor.Application.Responses.Identity;
using GenocsBlazor.Infrastructure.Contexts;
using GenocsBlazor.Infrastructure.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace GenocsBlazor.Infrastructure.Services;

public class ChatService : IChatService
{
    private readonly BlazorPortalContext _context;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    private readonly IStringLocalizer<ChatService> _localizer;

    public ChatService(
        BlazorPortalContext context,
        IMapper mapper,
        IUserService userService,
        IStringLocalizer<ChatService> localizer)
    {
        _context = context;
        _mapper = mapper;
        _userService = userService;
        _localizer = localizer;
    }

    public async Task<Result<IEnumerable<ChatHistoryResponse>>> GetChatHistoryAsync(string userId, string contactId)
    {
        var response = await _userService.GetAsync(userId);
        if (response.Succeeded)
        {
            var user = response.Data;
            var query = await _context.ChatHistories
                .Where(h => (h.FromUserId == userId && h.ToUserId == contactId) || (h.FromUserId == contactId && h.ToUserId == userId))
                .OrderBy(a => a.CreatedDate)
                .Include(a => a.FromUser)
                .Include(a => a.ToUser)
                .Select(x => new ChatHistoryResponse
                {
                    FromUserId = x.FromUserId,
                    FromUserFullName = $"{x.FromUser.FirstName} {x.FromUser.LastName}",
                    Message = x.Message,
                    CreatedDate = x.CreatedDate,
                    Id = x.Id,
                    ToUserId = x.ToUserId,
                    ToUserFullName = $"{x.ToUser.FirstName} {x.ToUser.LastName}",
                    ToUserImageURL = x.ToUser.ProfilePictureDataUrl,
                    FromUserImageURL = x.FromUser.ProfilePictureDataUrl
                }).ToListAsync();
            return await Result<IEnumerable<ChatHistoryResponse>>.SuccessAsync(query);
        }
        else
        {
            throw new ApiException(_localizer["User Not Found!"]);
        }
    }

    public async Task<Result<IEnumerable<ChatUserResponse>>> GetChatUsersAsync(string userId)
    {
        var userRoles = await _userService.GetRolesAsync(userId);
        var userIsAdmin = userRoles.Data?.UserRoles?.Any(x => x.Selected && x.RoleName == RoleConstants.AdministratorRole) == true;
        var allUsers = await _context.Users.Where(user => user.Id != userId && (userIsAdmin || user.IsActive && user.EmailConfirmed)).ToListAsync();
        var chatUsers = _mapper.Map<IEnumerable<ChatUserResponse>>(allUsers);
        return await Result<IEnumerable<ChatUserResponse>>.SuccessAsync(chatUsers);
    }

    public async Task<IResult> SaveMessageAsync(ChatHistory<IChatUser> message)
    {
        message.ToUser = await _context.Users.Where(user => user.Id == message.ToUserId).FirstOrDefaultAsync();
        await _context.ChatHistories.AddAsync(_mapper.Map<ChatHistory<BlazorPortalUser>>(message));
        await _context.SaveChangesAsync();
        return await Result.SuccessAsync();
    }
}