namespace InstaConnect.Follows.Domain.Features.Follows.Helpers;

internal class FollowFactory : IFollowFactory
{
	private readonly IDateTimeProvider _dateTimeProvider;

	public FollowFactory(IDateTimeProvider dateTimeProvider)
	{
		_dateTimeProvider = dateTimeProvider;
	}

	public Follow Create(UserId followerId, UserId followingId)
	{
		var utcNow = _dateTimeProvider.GetOffsetUtcNow();
		var follow = new Follow(
			new(followerId, followingId),
			utcNow);

		return follow;
	}
}
