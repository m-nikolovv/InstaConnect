using InstaConnect.Follows.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Tests.Features.Follows.Builders;

public class FollowBuilder
{
	private readonly string _followerId;
	private readonly User _follower;
	private readonly string _followingId;
	private readonly User _following;
	private readonly DateTimeOffset _createdAtUtc;

	public FollowBuilder(User follower, User following)
	{
		_followerId = follower.Id.Id;
		_follower = follower;
		_followingId = following.Id.Id;
		_following = following;
		_createdAtUtc = FollowDataFaker.GetCreatedAtUtc();
	}

	public FollowBuilder(Follow follow)
	{
		_followerId = follow.Id.FollowerId.Id;
		_follower = follow.Follower!;
		_followingId = follow.Id.FollowingId.Id;
		_following = follow.Following!;
		_createdAtUtc = follow.CreatedAtUtc;
	}

	public Follow Build()
	{
		var follow = new Follow(
				new(
					new(_followerId),
					new(_followingId)),
				_createdAtUtc);

		_follower.AddFollowFollowing(follow);
		_following.AddFollowFollower(follow);
		follow.AddFollower(_follower);
		follow.AddFollowing(_following);

		return follow;
	}
}
