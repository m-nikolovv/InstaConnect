namespace InstaConnect.Follows.Tests.Features.Follows.Utilities;

public static class FollowGenerator
{
	extension(Follow baseFollow)
	{
		public ICollection<Follow> GenerateAttached(IEnumerable<User> followers, IEnumerable<User> followings)
		{
			var follows = baseFollow.Generate(followers, followings);

			foreach (var follow in follows.Where(f => f != baseFollow))
			{
				follow.Following!.AddFollowFollower(follow);
				follow.Follower!.AddFollowFollowing(follow);
			}

			return follows;
		}

		public ICollection<Follow> Generate(IEnumerable<User> followers, IEnumerable<User> followings)
		{
			return [.. followers
			  .SelectMany(follower =>
				  followings.Select(followings =>
				  {
					  var follow = new Follow(
						  new(follower.Id, followings.Id),
						  FollowDataFaker.GetCreatedAtUtc());

					  if(baseFollow.Id == follow.Id)
					  {
						  return baseFollow;
					  }

					  follow.AddFollowing(followings);
					  follow.AddFollower(follower);

					  return follow;
				  }))];
		}
	}
}
