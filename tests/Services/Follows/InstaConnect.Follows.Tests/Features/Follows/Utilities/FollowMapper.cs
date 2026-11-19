using InstaConnect.Follows.Domain.Features.Follows.Models.Responses;

namespace InstaConnect.Follows.Tests.Features.Follows.Utilities;

public static class FollowMapper
{
	extension(Follow follow)
	{
		public FollowId ToId(
)
		{
			return follow.Id;
		}

		public FollowResponse ToFullResponse(UserId currentUserId)
		{
			return follow.ToFullResponse(currentUserId.Id);
		}

		public FollowResponse ToFullResponse(string currentUserId)
		{
			return new(follow.Id,
					   follow.Follower?.ToFullResponse(),
					   follow.Following?.ToFullResponse(),
					   follow.Id.FollowerId.Matches(currentUserId),
					   follow.CreatedAtUtc);
		}

		public FollowResponse ToResponseWithoutFollower(UserId currentUserId)
		{
			return follow.ToResponseWithoutFollower(currentUserId.Id);
		}

		public FollowResponse ToResponseWithoutFollower(string currentUserId)
		{
			return new(follow.Id,
					   null,
					   follow.Following?.ToFullResponse(),
					   follow.Id.FollowerId.Matches(currentUserId),
					   follow.CreatedAtUtc);
		}

		public FollowResponse ToResponseWithoutFollowing(UserId currentUserId)
		{
			return follow.ToResponseWithoutFollowing(currentUserId.Id);
		}

		public FollowResponse ToResponseWithoutFollowing(string currentUserId)
		{
			return new(follow.Id,
					   follow.Follower?.ToFullResponse(),
					   null,
					   follow.Id.FollowerId.Matches(currentUserId),
					   follow.CreatedAtUtc);
		}
	}

	extension(ICollection<Follow> follows)
	{
		public ICollection<FollowResponse> ToFullResponse(UserId currentUserId)
		{
			return follows.ToFullResponse(currentUserId.Id);
		}

		public ICollection<FollowResponse> ToFullResponse(string currentUserId)
		{
			return [.. follows.Select(follow => follow.ToFullResponse(currentUserId))];
		}
	}
}
