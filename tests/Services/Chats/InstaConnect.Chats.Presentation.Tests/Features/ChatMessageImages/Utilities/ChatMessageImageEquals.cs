using InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.Entities;
using InstaConnect.Chats.Presentation.Features.ChatMessageImages.Models.Responses;

namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessageImages.Utilities;

public static class ChatMessageImageEquals
{
	extension(ChatMessageImageApiResponse? response)
	{
		public bool MatchesFull(ChatMessageImage? chatMessageImage)
		{
			return response != null &&
				   chatMessageImage != null &&
				   chatMessageImage.Id.Id.Matches(response.ParticipantOneId, response.ParticipantTwoId, response.MessageId) &&
				   chatMessageImage.Id.ImageId.EqualsOrdinalIgnoreCase(response.ImageId) &&
				   chatMessageImage.Url.Matches(response.Url) &&
				   chatMessageImage.CreatedAtUtc == response.CreatedAtUtc;
		}

		public bool MatchesFullInverted(ChatMessageImage? chatMessageImage)
		{
			return response != null &&
				   chatMessageImage != null &&
				   chatMessageImage.Id.Id.Matches(response.ParticipantTwoId, response.ParticipantOneId, response.MessageId) &&
				   chatMessageImage.Id.ImageId.EqualsOrdinalIgnoreCase(response.ImageId) &&
				   chatMessageImage.Url.Matches(response.Url) &&
				   chatMessageImage.CreatedAtUtc == response.CreatedAtUtc;
		}
	}

	extension(ICollection<ChatMessageImageApiResponse> response)
	{
		public bool MatchesFull(ICollection<ChatMessageImage> chatMessageImages)
		{
			return response.MatchesCollectionAndNotEmpty(
				chatMessageImages,
				r => new(new(new(new(r.ParticipantOneId), new(r.ParticipantTwoId)), r.MessageId), r.ImageId),
				p => p.Id,
				(r, p) => r.MatchesFull(p));
		}

		public bool MatchesFullInverted(ICollection<ChatMessageImage> chatMessageImages)
		{
			return response.MatchesCollectionAndNotEmpty(
				chatMessageImages,
				r => new(new(new(new(r.ParticipantTwoId), new(r.ParticipantOneId)), r.MessageId), r.ImageId),
				p => p.Id,
				(r, p) => r.MatchesFullInverted(p));
		}
	}
}
