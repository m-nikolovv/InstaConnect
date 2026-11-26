using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessageImages.Utilities;

public static class ChatMessageImageSetups
{
	extension(IServiceScope serviceScope)
	{
		public async Task SetupAddChatMessageImageAsync(
			User participantOne,
			User participantTwo,
			Chat chat,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddChatMessageImageAsync(participantOne, participantTwo, chat, chatMessage, chatMessage.Id.Id.ParticipantOneId, cancellationToken);
		}

		public async Task SetupDeleteChatMessageImageAsync(
			User participantOne,
			User participantTwo,
			Chat chat,
			ChatMessage chatMessage,
			ChatMessageImage chatMessageImage,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteChatMessageImageAsync(participantOne, participantTwo, chat, chatMessage, chatMessageImage, chatMessageImage.Id.Id.Id.ParticipantOneId, cancellationToken);
		}
	}
}
