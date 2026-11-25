using InstaConnect.Follows.Domain.Features.Follows.Models.Responses;

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

	extension(FollowResponse? response)
	{
		public bool MatchesFull(UserId currentUserId, Follow? follow)
		{
			return response != null &&
				   follow != null &&
				   follow.Id.Matches(response.Id) &&
				   response.IsFollowedByCurrentUser == follow.Id.FollowerId.Matches(currentUserId) &&
				   follow.CreatedAtUtc == response.CreatedAtUtc &&
				   response.Following.MatchesFull(follow.Following) &&
				   response.Follower.MatchesFull(follow.Follower);
		}

		public bool MatchesFull(string currentUserId, Follow? follow)
		{
			return response.MatchesFull(new UserId(currentUserId), follow);
		}

		public bool MatchesWithoutFollowing(UserId currentUserId, Follow? follow)
		{
			return response != null &&
				   follow != null &&
				   follow.Id.Matches(response.Id) &&
				   response.IsFollowedByCurrentUser == follow.Id.FollowerId.Matches(currentUserId) &&
				   follow.CreatedAtUtc == response.CreatedAtUtc &&
				   response.Following == null &&
				   response.Follower.MatchesFull(follow.Follower);
		}

		public bool MatchesWithoutFollowing(string currentUserId, Follow? follow)
		{
			return response.MatchesWithoutFollowing(new UserId(currentUserId), follow);
		}

		public bool MatchesWithoutFollower(UserId currentUserId, Follow? follow)
		{
			return response != null &&
				   follow != null &&
				   follow.Id.Matches(response.Id) &&
				   response.IsFollowedByCurrentUser == follow.Id.FollowerId.Matches(currentUserId) &&
				   follow.CreatedAtUtc == response.CreatedAtUtc &&
				   response.Following.MatchesFull(follow.Following) &&
				   response.Follower == null;
		}

		public bool MatchesWithoutFollower(string currentUserId, Follow? follow)
		{
			return response.MatchesWithoutFollower(new UserId(currentUserId), follow);
		}
	}
}
