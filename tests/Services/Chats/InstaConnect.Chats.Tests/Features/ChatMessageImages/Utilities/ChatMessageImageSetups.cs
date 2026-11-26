using InstaConnect.Chats.Domain.Features.ChatMessageImages.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Abstractions;

namespace InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;

public static class ChatMessageImageSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IChatMessageImageCommandRepository GetMessageImageCommandRepository()
		{
			return serviceProvider.GetRequiredService<IChatMessageImageCommandRepository>();
		}

		public IChatMessageImageCollection GetMessageImageCollection()
		{
			return serviceProvider.GetRequiredService<IChatMessageImageCollection>();
		}

		public IChatMessageImageCacheHandler GetMessageImageCacheHandler()
		{
			return serviceProvider.GetRequiredService<IChatMessageImageCacheHandler>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IChatMessageImageCommandRepository GetMessageImageCommandRepository()
		{
			return serviceScope.ServiceProvider.GetMessageImageCommandRepository();
		}

		public IChatMessageImageCacheHandler GetMessageImageCacheHandler()
		{
			return serviceScope.ServiceProvider.GetMessageImageCacheHandler();
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
			var messageImageRepository = serviceScope.GetMessageImageCommandRepository();

			await messageImageRepository.AddAsync(chatMessageImage, cancellationToken);
		}

		public async Task AddRangeAsync(
			IEnumerable<ChatMessageImage> chatMessageImages,
			CancellationToken cancellationToken)
		{
			var messageImageRepository = serviceScope.GetMessageImageCommandRepository();

			await messageImageRepository.AddRangeAsync(chatMessageImages, cancellationToken);
		}

		public async Task DeleteAsync(
			ChatMessageImage chatMessageImage,
			CancellationToken cancellationToken)
		{
			var messageCacheHandler = serviceScope.GetMessageCacheHandler();
			var messageImageCacheHandler = serviceScope.GetMessageImageCacheHandler();
			var messageImageRepository = serviceScope.GetMessageImageCommandRepository();

			await messageImageRepository.DeleteAsync(chatMessageImage, cancellationToken);
			await messageCacheHandler.DeleteResponseAsync(chatMessageImage.Id.Id, cancellationToken);
			await messageImageCacheHandler.DeleteAsync(chatMessageImage.Id, cancellationToken);
		}

		public async Task DeleteRangeAsync(
			IEnumerable<ChatMessageImage> chatMessageImages,
			CancellationToken cancellationToken)
		{
			var messageCacheHandler = serviceScope.GetMessageCacheHandler();
			var messageImageCacheHandler = serviceScope.GetMessageImageCacheHandler();
			var messageImageRepository = serviceScope.GetMessageImageCommandRepository();

			await messageImageRepository.DeleteRangeAsync(chatMessageImages, cancellationToken);
			await messageCacheHandler.DeleteResponseRangeAsync(chatMessageImages.Select(p => p.Id.Id), cancellationToken);
			await messageImageCacheHandler.DeleteRangeAsync(chatMessageImages.Select(p => p.Id), cancellationToken);
		}

		public async Task SetupAddChatMessageImageAsync(
			User participantOne,
			User participantTwo,
			Chat chat,
			ChatMessage chatMessage,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(participantOne, cancellationToken);
			await serviceScope.AddAsync(participantTwo, cancellationToken);
			await serviceScope.AddAsync(chat, cancellationToken);
			await serviceScope.AddAsync(chatMessage, cancellationToken);
			await serviceScope.AddChatMessageCacheAsync(chatMessage, currentUserId, cancellationToken);
		}

		public async Task SetupAddChatMessageImageAsync(
			User participantOne,
			User participantTwo,
			Chat chat,
			ChatMessage chatMessage,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddChatMessageImageAsync(participantOne, participantTwo, chat, chatMessage, currentUserId.Id, cancellationToken);
		}

		public async Task SetupDeleteChatMessageImageAsync(
			User participantOne,
			User participantTwo,
			Chat chat,
			ChatMessage chatMessage,
			ChatMessageImage chatMessageImage,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(participantOne, cancellationToken);
			await serviceScope.AddAsync(participantTwo, cancellationToken);
			await serviceScope.AddAsync(chat, cancellationToken);
			await serviceScope.AddAsync(chatMessage, cancellationToken);
			await serviceScope.AddAsync(chatMessageImage, cancellationToken);
			await serviceScope.AddChatMessageCacheAsync(chatMessage, currentUserId, cancellationToken);
		}

		public async Task SetupDeleteChatMessageImageAsync(
			User participantOne,
			User participantTwo,
			Chat chat,
			ChatMessage chatMessage,
			ChatMessageImage chatMessageImage,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteChatMessageImageAsync(participantOne, participantTwo, chat, chatMessage, chatMessageImage, currentUserId.Id, cancellationToken);
		}

		public async Task SetupGetAllChatMessageImagesAsync(
			ICollection<User> participantOnes,
			ICollection<User> participantTwos,
			ICollection<Chat> chats,
			ICollection<ChatMessage> chatMessages,
			ICollection<ChatMessageImage> chatMessageImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddRangeAsync(participantOnes, cancellationToken);
			await serviceScope.AddRangeAsync(participantTwos, cancellationToken);
			await serviceScope.AddRangeAsync(chats, cancellationToken);
			await serviceScope.AddRangeAsync(chatMessages, cancellationToken);
			await serviceScope.AddRangeAsync(chatMessageImages, cancellationToken);
		}

		public async Task SetupGetChatMessageImageByIdAsync(
			User participantOne,
			User participantTwo,
			Chat chat,
			ChatMessage chatMessage,
			ChatMessageImage chatMessageImage,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(participantOne, cancellationToken);
			await serviceScope.AddAsync(participantTwo, cancellationToken);
			await serviceScope.AddAsync(chat, cancellationToken);
			await serviceScope.AddAsync(chatMessage, cancellationToken);
			await serviceScope.AddAsync(chatMessageImage, cancellationToken);
		}
	}
}
