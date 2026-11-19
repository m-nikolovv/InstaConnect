namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Utilities;

public static class ChatMessageCacheUtilities
{
	public const string GetResponseByIdKeyPrefix = "chats-chat-messages-get-by-id-response";

	public static string GetResponseByIdKey(ChatMessageId id, UserId currentUserId)
	{
		const string Format = "{0}:{1}:{2}:{3}:{4}";

		return Format.FormatCurrentCulture(
			GetResponseByIdKeyPrefix,
			id.Id.ParticipantOneId.Id,
			id.Id.ParticipantTwoId.Id,
			id.MessageId,
			currentUserId.Id);
	}

	public static string GetTag(ChatMessageId id)
	{
		const string Format = "chats:tags:chat-messages:{0}:{1}:{2}";

		return Format.FormatCurrentCulture(
			id.Id.ParticipantOneId.Id,
			id.Id.ParticipantTwoId.Id,
			id.MessageId).ToLowerCurrentCulture();
	}

	public static IEnumerable<string> GetTagRange(IEnumerable<ChatMessageId> ids)
	{
		return ids.Select(GetTag);
	}

	public static string GetResponseTag(ChatMessageId id)
	{
		const string Format = "chats:tags:chat-messages:responses:{0}:{1}:{2}";

		return Format.FormatCurrentCulture(
			id.Id.ParticipantOneId.Id,
			id.Id.ParticipantTwoId.Id,
			id.MessageId).ToLowerCurrentCulture();
	}

	public static IEnumerable<string> GetResponseTagRange(IEnumerable<ChatMessageId> ids)
	{
		return ids.Select(GetResponseTag);
	}
}
