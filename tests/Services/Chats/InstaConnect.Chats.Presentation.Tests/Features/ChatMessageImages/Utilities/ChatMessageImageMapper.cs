using InstaConnect.Chats.Application.Features.ChatMessageImages.Models;
using InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.Entities;

namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessageImages.Utilities;

public static class ChatMessageImageMapper
{
	extension(ChatMessageImage chatMessageImage)
	{
		internal ChatMessageImageQueryResponse ToFullQueryResponse()
		{
			return new(
				chatMessageImage.Id.Id.Id.ParticipantOneId.Id,
				chatMessageImage.Id.Id.Id.ParticipantTwoId.Id,
				chatMessageImage.Id.Id.MessageId,
				chatMessageImage.Id.ImageId,
				chatMessageImage.Url.Value,
				chatMessageImage.CreatedAtUtc);
		}
	}

	extension(ICollection<ChatMessageImage> chatMessageImages)
	{
		internal ICollection<ChatMessageImageQueryResponse> ToFullQueryResponse()
		{
			return [.. chatMessageImages.Select(chatMessageImage => chatMessageImage.ToFullQueryResponse())];
		}
	}
}
