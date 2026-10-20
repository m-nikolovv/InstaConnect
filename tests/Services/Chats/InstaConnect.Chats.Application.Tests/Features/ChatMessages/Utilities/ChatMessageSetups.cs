using InstaConnect.Chats.Application.Features.ChatMessages.Models;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageSetups
{
	extension(IServiceScope serviceScope)
	{
		internal async Task<ChatMessage?> GetByIdAsync(
		ChatMessageIdCommandResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new ChatMessageId(
							   new(
								   new(id.ParticipantOneId),
								   new(id.ParticipantTwoId)),
							   id.MessageId),
				cancellationToken);
		}

		public async Task<ChatMessage?> GetByIdAsync(
			AddChatMessageCommandResponse response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<ChatMessage?> GetByIdAsync(
			UpdateChatMessageCommandResponse response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}
	}
}
