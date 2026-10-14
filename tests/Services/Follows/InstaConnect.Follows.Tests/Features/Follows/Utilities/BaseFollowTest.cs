using InstaConnect.Follows.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Tests.Features.Users.Utilities;

namespace InstaConnect.Follows.Tests.Features.Follows.Utilities;

public abstract class BaseFollowTest : BaseTest
{
	protected UserBuilderFactory FollowerBuilderFactory { get; }
	protected UserBuilder FollowerBuilder { get; }
	protected User Follower { get; }
	protected ICollection<User> Followers { get; }

	protected UserBuilderFactory FollowingBuilderFactory { get; }
	protected UserBuilder FollowingBuilder { get; }
	protected User Following { get; }
	protected ICollection<User> Followings { get; }

	protected FollowBuilderFactory FollowBuilderFactory { get; }
	protected FollowBuilder FollowBuilder { get; }
	protected Follow Follow { get; }
	protected ICollection<Follow> Follows { get; }

	protected BaseFollowTest()
	{
		FollowerBuilderFactory = new();
		FollowerBuilder = FollowerBuilderFactory.Create();
		Follower = FollowerBuilder.Build();
		Followers = Follower.Generate();

		FollowingBuilderFactory = new();
		FollowingBuilder = FollowingBuilderFactory.Create();
		Following = FollowingBuilder.Build();
		Followings = Following.Generate();

		FollowBuilderFactory = new();
		FollowBuilder = FollowBuilderFactory.Create(Follower, Following);
		Follow = FollowBuilder.Build();
		Follows = Follow.Generate(Followers, Followings);
	}
}
