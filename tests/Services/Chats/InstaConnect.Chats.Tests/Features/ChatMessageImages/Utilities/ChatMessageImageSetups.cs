using InstaConnect.Chats.Domain.Features.ChatMessageImages.Abstractions;

namespace InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;

public static class ChatMessageImageSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IChatMessageImageCommandRepository GetMessageImageCommandRepository()
		{
			return serviceProvider.GetRequiredService<IChatMessageImageCommandRepository>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IChatMessageImageCommandRepository GetMessageImageCommandRepository()
		{
			return serviceScope.ServiceProvider.GetMessageImageCommandRepository();
		}

		public async Task<ChatMessageImage?> GetByIdAsync(
			ChatMessageImageId id,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetMessageImageCommandRepository().GetByIdAsync(id, cancellationToken);
		}

		public async Task<ICollection<ChatMessageImage>> GetByIdRangeAsync(
			IEnumerable<ChatMessageImageId> ids,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetMessageImageCommandRepository().GetByIdRangeAsync(ids, cancellationToken);
		}

		public async Task AddAsync(
			ChatMessageImage chatMessageImage,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetMessageImageCommandRepository().AddAsync(chatMessageImage, cancellationToken);
		}

		public async Task AddRangeAsync(
			IEnumerable<ChatMessageImage> chatMessageImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetMessageImageCommandRepository().AddRangeAsync(chatMessageImages, cancellationToken);
		}

		public async Task DeleteAsync(
			ChatMessageImage chatMessageImage,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetMessageImageCommandRepository().DeleteAsync(chatMessageImage, cancellationToken);
		}

		public async Task DeleteRangeAsync(
			IEnumerable<ChatMessageImage> chatMessageImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetMessageImageCommandRepository().DeleteRangeAsync(chatMessageImages, cancellationToken);
		}
	}
}
