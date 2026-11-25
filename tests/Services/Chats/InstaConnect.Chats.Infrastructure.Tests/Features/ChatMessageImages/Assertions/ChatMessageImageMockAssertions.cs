using InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.ValueObjects;
using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessageImages.Assertions;

public static class ChatMessageImageMockAssertions
{
	extension(IChatMessageImageCollection collection)
	{
		public void ShouldHaveReceivedOneAggregateFluent(ChatMessageImageId id)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(ICollection<ChatMessageImageId> ids)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent()
		{
			collection.ShouldHaveReceivedOne().AggregateFluent();
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			ChatMessageImage chatMessageImage,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().AddAsync(chatMessageImage, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddRangeAsync(
			ICollection<ChatMessageImage> chatMessageImages,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().AddRangeAsync(chatMessageImages, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			ChatMessageImage chatMessageImage,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().DeleteAsync(chatMessageImage, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteRangeAsync(
			ICollection<ChatMessageImage> chatMessageImages,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().DeleteRangeAsync(chatMessageImages, cancellationToken);
		}
	}

	extension(IChatMessageImageFluent fluent)
	{
		public void ShouldHaveReceivedOneMatch(ChatMessageImageId id)
		{
			fluent.ShouldHaveReceivedOne().Match(id);
		}

		public void ShouldHaveReceivedOneMatch(ICollection<ChatMessageImageId> ids)
		{
			fluent.ShouldHaveReceivedOne().Match(ids);
		}

		public async Task ShouldHaveReceivedOneFirstOrDefaultAsync(
			ChatMessageImageId id,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneToListAsync(
			ICollection<ChatMessageImageId> ids,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneToListAsync(cancellationToken);
		}
	}

	extension(IChatMessageImageCacheHandler cacheHandler)
	{
		public async Task ShouldHaveReceivedOneDeleteAsync(
			ChatMessageImage chatMessageImage,
			CancellationToken cancellationToken)
		{
			await cacheHandler.ShouldHaveReceivedOne().DeleteAsync(chatMessageImage.Id, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteRangeAsync(
			ICollection<ChatMessageImage> chatMessageImages,
			CancellationToken cancellationToken)
		{
			await cacheHandler.ShouldHaveReceivedOne().DeleteRangeAsync(chatMessageImages.Select(p => p.Id), cancellationToken);
		}
	}

	extension(IChatMessageCacheHandler cacheHandler)
	{
		public async Task ShouldHaveReceivedOneDeleteResponseAsync(
			ChatMessageImage chatMessageImage,
			CancellationToken cancellationToken)
		{
			await cacheHandler.ShouldHaveReceivedOne().DeleteResponseAsync(chatMessageImage.Id.Id, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteResponseRangeAsync(
			ICollection<ChatMessageImage> chatMessageImages,
			CancellationToken cancellationToken)
		{
			await cacheHandler.ShouldHaveReceivedOne().DeleteResponseRangeAsync(chatMessageImages.Select(p => p.Id.Id), cancellationToken);
		}
	}
}
