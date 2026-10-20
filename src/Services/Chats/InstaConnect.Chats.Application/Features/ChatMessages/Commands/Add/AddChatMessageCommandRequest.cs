using Microsoft.AspNetCore.Http;

namespace InstaConnect.Chats.Application.Features.ChatMessages.Commands.Add;

public record AddChatMessageCommandRequest(
	string ParticipantOneId,
	string ParticipantTwoId,
	string Content,
	ICollection<IFormFile> Images) : ICommandRequest<AddChatMessageCommandResponse>;
