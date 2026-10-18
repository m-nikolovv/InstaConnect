using InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.Entities;
using InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.ValueObjects;
using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Abstractions;

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
}
