using InstaConnect.Follows.Domain.Features.Follows.Extensions;

namespace InstaConnect.Follows.Tests.Features.Users.Utilities;

public static class UserReference
{
	extension(User? user)
	{
		public User? SetFollowFollowers()
		{
			user?.FollowFollowers.AddFollowing(user).SetFollower();

			return user;
		}

		public User? SetFollowFollowings()
		{
			user?.FollowFollowings.AddFollower(user).SetFollowing();

			return user;
		}
	}
}
