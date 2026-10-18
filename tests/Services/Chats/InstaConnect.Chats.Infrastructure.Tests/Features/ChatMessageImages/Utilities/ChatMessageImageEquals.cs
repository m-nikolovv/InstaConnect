using InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.Entities;
using InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.Responses;
using InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.ValueObjects;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessageImages.Utilities;

public static class ChatMessageImageEquals
{
	extension(ChatMessageImage p)
	{
		public bool Matches(
			ChatMessageImageId id,
			ChatMessageImage chatMessageImage)
		{
			return p.Matches(chatMessageImage);
		}
	}

	extension(ICollection<ChatMessageImage> p)
	{
		public bool Matches(
			ICollection<ChatMessageImageId> ids,
			ICollection<ChatMessageImage> chatMessageImages)
		{
			return p.Matches(chatMessageImages);
		}
	}

	extension(ChatMessageImageResponse? response)
	{
		public bool MatchesFull(ChatMessageImage? chatMessageImage)
		{
			return response != null &&
				   chatMessageImage != null &&
				   chatMessageImage.Id.Matches(response.Id) &&
				   chatMessageImage.Url.Matches(response.Url) &&
				   chatMessageImage.CreatedAtUtc == response.CreatedAtUtc;
		}

		public bool MatchesFullInverted(ChatMessageImage? chatMessageImage)
		{
			return response != null &&
				   chatMessageImage != null &&
				   chatMessageImage.Id.Matches(new(new(new(response.Id.Id.Id.ParticipantTwoId, response.Id.Id.Id.ParticipantOneId), response.Id.Id.MessageId), response.Id.ImageId)) &&
				   chatMessageImage.Url.Matches(response.Url) &&
				   chatMessageImage.CreatedAtUtc == response.CreatedAtUtc;
		}
	}

	extension(ICollection<ChatMessageImageResponse> response)
	{
		public bool MatchesFull(ICollection<ChatMessageImage> chatMessageImages)
		{
			return response.MatchesCollection(
				chatMessageImages,
				r => r.Id,
				p => p.Id,
				(r, p) => r.MatchesFull(p));
		}

		public bool MatchesFullInverted(ICollection<ChatMessageImage> chatMessageImages)
		{
			return response.MatchesCollection(
				chatMessageImages,
				r => new(new(new(r.Id.Id.Id.ParticipantTwoId, r.Id.Id.Id.ParticipantOneId), r.Id.Id.MessageId), r.Id.ImageId),
				p => p.Id,
				(r, p) => r.MatchesFullInverted(p));
		}
	}
}
