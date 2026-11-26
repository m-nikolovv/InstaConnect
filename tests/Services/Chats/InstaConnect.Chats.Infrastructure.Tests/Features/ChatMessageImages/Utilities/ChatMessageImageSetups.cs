using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessageImages.Utilities;

public static class ChatMessageImageSetups
{
	extension(IServiceScope serviceScope)
	{
		public async Task SetupAddAsync(
			ChatMessageImage chatMessageImage,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddAsync(chatMessageImage, chatMessageImage.Id.Id.Id.ParticipantOneId, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			ChatMessageImage chatMessageImage,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteAsync(chatMessageImage, chatMessageImage.Id.Id.Id.ParticipantOneId, cancellationToken);
		}
	}
}
