using InstaConnect.Follows.Tests.Features.Common.Utilities;
using InstaConnect.Follows.Tests.Features.Follows.Builders;

namespace InstaConnect.Follows.Tests.Features.Users.Utilities;

public abstract class BaseUserTest : BaseFollowsTest
{
	protected ICollection<Follow> UserFollowFollowers { get; }
	protected FollowIdRangeBuilderFactory UserFollowFollowerIdRangeBuilderFactory { get; }
	protected FollowIdRangeBuilder UserFollowFollowerIdRangeBuilder { get; }
	protected ICollection<FollowId> UserFollowFollowerIds { get; }

	protected ICollection<Follow> UserFollowFollowings { get; }
	protected FollowIdRangeBuilderFactory UserFollowFollowingIdRangeBuilderFactory { get; }
	protected FollowIdRangeBuilder UserFollowFollowingIdRangeBuilder { get; }
	protected ICollection<FollowId> UserFollowFollowingIds { get; }

	protected BaseUserTest()
	{
		UserFollowFollowers = [.. User.FollowFollowers];
		UserFollowFollowerIdRangeBuilderFactory = new();
		UserFollowFollowerIdRangeBuilder = UserFollowFollowerIdRangeBuilderFactory.Create([.. UserFollowFollowers.Select(f => f.Id)]);
		UserFollowFollowerIds = UserFollowFollowerIdRangeBuilder.Build();

		UserFollowFollowings = [.. User.FollowFollowings];
		UserFollowFollowingIdRangeBuilderFactory = new();
		UserFollowFollowingIdRangeBuilder = UserFollowFollowingIdRangeBuilderFactory.Create([.. UserFollowFollowings.Select(f => f.Id)]);
		UserFollowFollowingIds = UserFollowFollowingIdRangeBuilder.Build();
	}
}
