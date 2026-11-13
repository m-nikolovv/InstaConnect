
namespace InstaConnect.Posts.Infrastructure.Features.Users.Utilities;

public static class UserCacheUtilities
{
	public const string GetByIdKeyPrefix = "posts-users-get-by-id";
	public const string GetByNameKeyPrefix = "posts-users-get-by-name";
	public const string ExistsByIdKeyPrefix = "posts-users-exists-by-id";
	public const string GetByEmailKeyPrefix = "posts-users-get-by-email";
	public const string GetResponseByIdKeyPrefix = "posts-users-get-by-id-response";

	public static string GetByIdKey(UserId id)
	{
		const string Format = "{0}:{1}";

		return Format.FormatCurrentCulture(
			GetByIdKeyPrefix,
			id.Id);
	}

	public static string ExistsByIdKey(UserId id)
	{
		const string Format = "{0}:{1}";

		return Format.FormatCurrentCulture(
			ExistsByIdKeyPrefix,
			id.Id);
	}

	public static string GetByNameKey(Name name)
	{
		const string Format = "{0}:{1}";

		return Format.FormatCurrentCulture(
			GetByNameKeyPrefix,
			name.Value);
	}

	public static string GetByEmailKey(Email email)
	{
		const string Format = "{0}:{1}";

		return Format.FormatCurrentCulture(
			GetByEmailKeyPrefix,
			email.Value);
	}

	public static string GetResponseByIdKey(UserId id, CurrentUserQuery currentUser)
	{
		const string Format = "{0}:{1}:{2}";

		return Format.FormatCurrentCulture(
			GetResponseByIdKeyPrefix,
			id.Id,
			currentUser.Id.Id);
	}

	public static string GetTag(UserId id)
	{
		const string Format = "posts:tags:users:{0}";

		return Format.FormatCurrentCulture(id.Id).ToLowerCurrentCulture();
	}

	public static IEnumerable<string> GetTagRange(IEnumerable<UserId> ids)
	{
		return ids.Select(GetTag);
	}
}
