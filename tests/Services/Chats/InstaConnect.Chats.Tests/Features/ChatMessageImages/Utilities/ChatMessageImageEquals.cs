using InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.ValueObjects;
using InstaConnect.Chats.Domain.Features.ChatMessages.Models.ValueObjects;
using InstaConnect.Common.Domain.Features.Common.Extensions;

namespace InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;

public static class ChatMessageImageEquals
{
	extension(ChatMessageImage entity)
	{
		public bool Matches(ChatMessageImage chatMessageImage)
		{
			return entity.Id.Matches(chatMessageImage.Id) &&
				   entity.Url.Matches(chatMessageImage.Url) &&
				   entity.CreatedAtUtc == chatMessageImage.CreatedAtUtc;
		}
	}

	extension(ICollection<ChatMessageImage> entities)
	{
		public bool Matches(ICollection<ChatMessageImage> chatMessageImages)
		{
			return entities.MatchesCollection(
				chatMessageImages,
				e => e.Id,
				e => e.Id,
				(entity, chatMessageImage) => entity.Matches(chatMessageImage));
		}
	}

	extension(ChatMessageImageId p)
	{
		public bool Matches(ChatMessageImageId id)
		{
			return p.Matches(id.Id, id.ImageId);
		}

		public bool Matches(ChatMessageId id, string imageId)
		{
			return p.Id.Matches(id) &&
				   p.ImageId.EqualsOrdinalIgnoreCase(imageId);
		}
	}
}
