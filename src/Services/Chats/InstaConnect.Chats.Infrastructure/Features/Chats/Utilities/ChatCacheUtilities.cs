namespace InstaConnect.Chats.Infrastructure.Features.Chats.Utilities;

public static class ChatCacheUtilities
{
	public const string GetByIdKeyPrefix = "chats-chats-get-by-id";
	public const string ExistsByIdKeyPrefix = "chats-chats-exists-by-id";
	public const string GetResponseByIdKeyPrefix = "chats-chats-get-by-id-response";

	public static string GetByIdKey(ChatId id)
	{
		const string Format = "{0}:{1}:{2}";

		return Format.FormatCurrentCulture(
			GetByIdKeyPrefix,
			id.ParticipantOneId.Id,
			id.ParticipantTwoId.Id);
	}

	public static string ExistsByIdKey(ChatId id)
	{
		const string Format = "{0}:{1}:{2}";

		return Format.FormatCurrentCulture(
			ExistsByIdKeyPrefix,
			id.ParticipantOneId.Id,
			id.ParticipantTwoId.Id);
	}

	public static string GetResponseByIdKey(ChatId id, CurrentUserQuery currentUser)
	{
		const string Format = "{0}:{1}:{2}:{3}";

		return Format.FormatCurrentCulture(
			GetResponseByIdKeyPrefix,
			id.ParticipantOneId.Id,
			id.ParticipantTwoId.Id,
			currentUser.Id.Id);
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
}
