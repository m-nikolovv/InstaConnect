namespace InstaConnect.Chats.Infrastructure.Features.Chats.Utilities;

public static class ChatCacheUtilities
{
	public const string GetResponseByIdKeyPrefix = "chats-chats-get-by-id-response";

	public static string GetResponseByIdKey(ChatId id, UserId currentUserId)
	{
		const string Format = "{0}:{1}:{2}:{3}";

		return Format.FormatCurrentCulture(
			GetResponseByIdKeyPrefix,
			id.ParticipantOneId.Id,
			id.ParticipantTwoId.Id,
			currentUserId.Id);
	}

	public static string GetTag(ChatId id)
	{
		const string Format = "chats:tags:chats:{0}:{1}";

		return Format.FormatCurrentCulture(
			id.ParticipantOneId.Id,
			id.ParticipantTwoId.Id).ToLowerCurrentCulture();
	}

	public static IEnumerable<string> GetTagRange(IEnumerable<ChatId> ids)
	{
		return ids.Select(GetTag);
	}

	public static string GetResponseTag(ChatId id)
	{
		const string Format = "chats:tags:chats:responses:{0}:{1}";

		return Format.FormatCurrentCulture(
			id.ParticipantOneId.Id,
			id.ParticipantTwoId.Id).ToLowerCurrentCulture();
	}

	public static IEnumerable<string> GetResponseTagRange(IEnumerable<ChatId> ids)
	{
		return ids.Select(GetResponseTag);
	}
}
