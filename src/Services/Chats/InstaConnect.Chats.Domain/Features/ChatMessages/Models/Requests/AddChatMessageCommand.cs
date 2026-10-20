using Microsoft.AspNetCore.Http;

namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;

public record AddChatMessageCommand(ChatId Id, string Content, ICollection<IFormFile> Images);
