namespace InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Utilities;

public static class ChatMessageImageCacheUtilities
{
	public const string GetByIdKeyPrefix = "chats-chat-message-images-get-by-id";

	public static string GetByIdKey(ChatMessageImageId id)
	{
		const string Format = "{0}:{1}:{2}:{3}:{4}";

		return Format.FormatCurrentCulture(
			GetByIdKeyPrefix,
			id.Id.Id.ParticipantOneId.Id,
			id.Id.Id.ParticipantTwoId.Id,
			id.Id.MessageId,
			id.ImageId);
	}

	public static string GetTag(ChatMessageImageId id)
	{
		const string Format = "chats:tags:chat-message-images:{0}:{1}:{2}:{3}";

		return Format.FormatCurrentCulture(
			id.Id.Id.ParticipantOneId.Id,
			id.Id.Id.ParticipantTwoId.Id,
			id.Id.MessageId,
			id.ImageId).ToLowerCurrentCulture();
	}

	public static IEnumerable<string> GetTagRange(IEnumerable<ChatMessageImageId> ids)
	{
		return ids.Select(GetTag);
	}
}
