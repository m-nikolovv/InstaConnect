using InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.ValueObjects;
using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessageImages.Utilities;

public static class ChatMessageImageMockSetups
{
	extension(IChatMessageImageCollection collection)
	{
		public void SetupAggregateFluent(
			ChatMessageImageId id,
			IChatMessageImageFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			ICollection<ChatMessageImageId> ids,
			IChatMessageImageFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(IChatMessageImageFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}
	}

	extension(IChatMessageImageFluent fluent)
	{
		public void SetupMatch(ChatMessageImageId id)
		{
			fluent.Match(id).ReturnsResponse(fluent);
		}

		public void SetupMatch(ICollection<ChatMessageImageId> ids)
		{
			fluent.Match(ids).ReturnsResponse(fluent);
		}

		public void SetupFirstOrDefaultAsync(
			ChatMessageImageId id,
			ChatMessageImage chatMessageImage,
			CancellationToken cancellationToken)
		{
			fluent.SetupFirstOrDefaultAsync(chatMessageImage, cancellationToken);
		}

		public void SetupToListAsync(
			ICollection<ChatMessageImageId> ids,
			ICollection<ChatMessageImage> chatMessageImages,
			CancellationToken cancellationToken)
		{
			fluent.SetupToListAsync(chatMessageImages, cancellationToken);
		}
	}
}
