using InstaConnect.Follows.Tests.Features.Follows.Builders;
using InstaConnect.Follows.Tests.Features.Users.Builders;

namespace InstaConnect.Follows.Tests.Features.Common.Utilities;

public abstract class BaseFollowsTest : BaseTest
{
	protected UserBuilderFactory UserBuilderFactory { get; }
	protected UserBuilder UserBuilder { get; }
	protected User User { get; }

	protected UserIdBuilderFactory UserIdBuilderFactory { get; }
	protected UserIdBuilder UserIdBuilder { get; }
	protected UserId UserId { get; }

	protected UserBuilderFactory FollowerBuilderFactory { get; }
	protected UserBuilder FollowerBuilder { get; }
	protected User Follower { get; }
	protected ICollection<User> Followers { get; }

	protected UserIdBuilderFactory FollowerIdBuilderFactory { get; }
	protected UserIdBuilder FollowerIdBuilder { get; }
	protected UserId FollowerId { get; }

	protected UserIdRangeBuilderFactory FollowerIdRangeBuilderFactory { get; }
	protected UserIdRangeBuilder FollowerIdRangeBuilder { get; }
	protected ICollection<UserId> FollowerIds { get; }

	protected UserBuilderFactory FollowingBuilderFactory { get; }
	protected UserBuilder FollowingBuilder { get; }
	protected User Following { get; }
	protected ICollection<User> Followings { get; }

	protected UserIdBuilderFactory FollowingIdBuilderFactory { get; }
	protected UserIdBuilder FollowingIdBuilder { get; }
	protected UserId FollowingId { get; }

	protected UserIdRangeBuilderFactory FollowingIdRangeBuilderFactory { get; }
	protected UserIdRangeBuilder FollowingIdRangeBuilder { get; }
	protected ICollection<UserId> FollowingIds { get; }

	protected FollowBuilderFactory FollowBuilderFactory { get; }
	protected FollowBuilder FollowBuilder { get; }
	protected Follow Follow { get; }
	protected ICollection<Follow> Follows { get; }
	protected FollowBuilder FollowFollowerBuilder { get; }
	protected Follow FollowFollower { get; }
	protected FollowBuilder FollowFollowingBuilder { get; }
	protected Follow FollowFollowing { get; }

	protected FollowIdBuilderFactory FollowIdBuilderFactory { get; }
	protected FollowIdBuilder FollowIdBuilder { get; }
	protected FollowId FollowId { get; }

	protected FollowIdRangeBuilderFactory FollowIdRangeBuilderFactory { get; }
	protected FollowIdRangeBuilder FollowIdRangeBuilder { get; }
	protected ICollection<FollowId> FollowIds { get; }

	protected BaseFollowsTest()
	{
		UserBuilderFactory = new();
		UserBuilder = UserBuilderFactory.Create();
		User = UserBuilder.Build();

		UserIdBuilderFactory = new();
		UserIdBuilder = UserIdBuilderFactory.Create(User.Id);
		UserId = UserIdBuilder.Build();

		FollowerBuilderFactory = new();
		FollowerBuilder = FollowerBuilderFactory.Create();
		Follower = FollowerBuilder.Build();
		Followers = Follower.Generate();

		FollowerIdBuilderFactory = new();
		FollowerIdBuilder = FollowerIdBuilderFactory.Create(Follower.Id);
		FollowerId = FollowerIdBuilder.Build();

		FollowerIdRangeBuilderFactory = new();
		FollowerIdRangeBuilder = FollowerIdRangeBuilderFactory.Create([.. Followers.Select(p => p.Id)]);
		FollowerIds = FollowerIdRangeBuilder.Build();

		FollowingBuilderFactory = new();
		FollowingBuilder = FollowingBuilderFactory.Create();
		Following = FollowingBuilder.Build();
		Followings = Following.Generate();

		FollowingIdBuilderFactory = new();
		FollowingIdBuilder = FollowingIdBuilderFactory.Create(Following.Id);
		FollowingId = FollowingIdBuilder.Build();

		FollowingIdRangeBuilderFactory = new();
		FollowingIdRangeBuilder = FollowingIdRangeBuilderFactory.Create([.. Followings.Select(p => p.Id)]);
		FollowingIds = FollowingIdRangeBuilder.Build();

		FollowBuilderFactory = new();
		FollowBuilder = FollowBuilderFactory.Create(Follower, Following);
		Follow = FollowBuilder.BuildAttached();
		Follows = Follow.GenerateAttached(Followers, Followings);
		FollowFollowerBuilder = FollowBuilderFactory.Create(Follower, User);
		FollowFollower = FollowFollowerBuilder.BuildAttached();
		FollowFollowingBuilder = FollowBuilderFactory.Create(User, Following);
		FollowFollowing = FollowFollowingBuilder.BuildAttached();

		FollowIdBuilderFactory = new();
		FollowIdBuilder = FollowIdBuilderFactory.Create(Follow.Id);
		FollowId = FollowIdBuilder.Build();

		FollowIdRangeBuilderFactory = new();
		FollowIdRangeBuilder = FollowIdRangeBuilderFactory.Create([.. Follows.Select(p => p.Id)]);
		FollowIds = FollowIdRangeBuilder.Build();
	}
}
