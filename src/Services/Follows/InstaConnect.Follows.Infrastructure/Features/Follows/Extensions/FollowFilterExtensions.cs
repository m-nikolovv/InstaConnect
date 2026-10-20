using InstaConnect.Follows.Infrastructure.Features.Users.Extensions;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Extensions;

internal static class FollowFilterExtensions
{
	extension(FollowsFilterQuery filter)
	{
		public FilterDefinition<Follow> GetFilter()
		{
			var followerId = filter.FollowerId.GetFilterForIdEquals<Follow>(p => p.Id.FollowerId.Id);
			var followingName = filter.FollowingName.GetFilterForNameStartsWith<Follow>(p => p.Following!.Name.Value);

			return Builders<Follow>.Filter.And(followerId, followingName);
		}
	}

	extension(FollowsForFollowingFilterQuery filter)
	{
		public FilterDefinition<Follow> GetFilter()
		{
			var followingId = filter.FollowingId.GetFilterForIdEquals<Follow>(p => p.Id.FollowingId.Id);
			var followerName = filter.FollowerName.GetFilterForNameStartsWith<Follow>(p => p.Follower!.Name.Value);

			return Builders<Follow>.Filter.And(followingId, followerName);
		}
	}

	extension(FollowId filter)
	{
		public FilterDefinition<Follow> GetFilter()
		{
			return filter.GetFilterForIdEquals<Follow>(p => p.Id.FollowerId.Id, p => p.Id.FollowingId.Id);
		}

		public FilterDefinition<T> GetFilterForIdEquals<T>(
			Expression<Func<T, object>> followerIdField,
			Expression<Func<T, object>> followingIdField)
		{
			var followerId = filter.FollowerId.GetFilterForIdEquals(followerIdField);
			var followingId = filter.FollowingId.GetFilterForIdEquals(followingIdField);

			return Builders<T>.Filter.And(followerId, followingId);
		}
	}
}
