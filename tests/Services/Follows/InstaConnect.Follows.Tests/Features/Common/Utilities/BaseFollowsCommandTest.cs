using InstaConnect.Follows.Tests.Features.Follows.Builders;

namespace InstaConnect.Follows.Tests.Features.Common.Utilities;

public abstract class BaseFollowsCommandTest : BaseFollowsTest
{
	protected ICollection<Follow> UserFollows { get; }
	protected FollowIdRangeBuilderFactory UserFollowIdRangeBuilderFactory { get; }
	protected FollowIdRangeBuilder UserFollowIdRangeBuilder { get; }
	protected ICollection<FollowId> UserFollowIds { get; }

	protected BaseFollowsCommandTest()
	{
		UserFollows = [.. User.FollowFollowers, .. User.FollowFollowings];
		UserFollowIdRangeBuilderFactory = new();
		UserFollowIdRangeBuilder = UserFollowIdRangeBuilderFactory.Create([.. UserFollows.Select(p => p.Id)]);
		UserFollowIds = UserFollowIdRangeBuilder.Build();
	}
}
