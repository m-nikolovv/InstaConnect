namespace InstaConnect.Follows.Tests.Features.Follows.Utilities;

public static class FollowEquals
{
	extension(Follow entity)
	{
		public bool Matches(Follow follow)
		{
			return entity.Id.Matches(follow.Id) &&
				   entity.CreatedAtUtc == follow.CreatedAtUtc;
		}
	}

	extension(ICollection<Follow> entities)
	{
		public bool Matches(ICollection<Follow> follows)
		{
			return entities.MatchesCollectionAndNotEmpty(
				follows,
				e => e.Id,
				e => e.Id,
				(entity, follow) => entity.Matches(follow));
		}
	}

	extension(FollowId p)
	{
		public bool Matches(FollowId id)
		{
			return p.Matches(id.FollowerId, id.FollowingId);
		}

		public bool Matches(UserId followerId, UserId followingId)
		{
			return p.Matches(followerId.Id, followingId.Id);
		}

		public bool Matches(string followerId, string followingId)
		{
			return p.FollowerId.Matches(followerId) &&
				   p.FollowingId.Matches(followingId);
		}
	}
}
