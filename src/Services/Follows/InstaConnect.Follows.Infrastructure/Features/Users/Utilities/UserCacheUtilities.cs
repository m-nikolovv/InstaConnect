
namespace InstaConnect.Follows.Infrastructure.Features.Users.Utilities;

public static class UserCacheUtilities
{
	public const string GetByIdKeyPrefix = "follows-users-get-by-id";
	public const string GetByNameKeyPrefix = "follows-users-get-by-name";
	public const string ExistsByIdKeyPrefix = "follows-users-exists-by-id";
	public const string GetByEmailKeyPrefix = "follows-users-get-by-email";
	public const string GetResponseByIdKeyPrefix = "follows-users-get-by-id-response";

	public static string GetByIdKey(UserId id)
	{
		const string Format = GetByIdKeyPrefix + ":{0}";

		return Format.FormatCurrentCulture(id.Id);
	}

	public static string ExistsByIdKey(UserId id)
	{
		const string Format = ExistsByIdKeyPrefix + ":{0}";

		return Format.FormatCurrentCulture(id.Id);
	}

	public static string GetByNameKey(Name name)
	{
		const string Format = GetByNameKeyPrefix + ":{0}";

		return Format.FormatCurrentCulture(name.Value);
	}

	public static string GetByEmailKey(Email email)
	{
		const string Format = GetByEmailKeyPrefix + ":{0}";

		return Format.FormatCurrentCulture(email.Value);
	}

	public static string GetResponseByIdKey(UserId id, CurrentUserQuery currentUser)
	{
		const string Format = GetResponseByIdKeyPrefix + ":{0}:{1}";

		return Format.FormatCurrentCulture(id.Id, currentUser.Id.Id);
	}

	public static string GetTag(UserId id)
	{
		const string Format = "follows:tags:users:{0}";

		return Format.FormatCurrentCulture(id.Id).ToUpperInvariant();
	}

	public static IEnumerable<string> GetTagRange(IEnumerable<UserId> ids)
	{
		return ids.Select(GetTag);
	}

	public static IEnumerable<string> GetTagRange(UserId id)
	{
		return [GetTag(id)];
	}

	public static IEnumerable<string> GetTagRange(User entity)
	{
		return GetTagRange(entity.Id);
	}
}
