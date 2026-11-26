using InstaConnect.Posts.Domain.Features.PostLikes.Models.Responses;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Utilities;

public static class PostLikeMapper
{
	extension(ICollection<PostLike> postLikes)
	{
		public ICollection<PostLikeResponse> ToResponse(
			PostLikesFilterQuery filterQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			return postLikes.Filter(paginationQuery, postLike => postLike.MatchesFilter(filterQuery), postLike => postLike.ToResponseWithoutPost());
		}

		public ICollection<PostLikeResponse> ToResponse(
			PostLikesForUserFilterQuery filterQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			return postLikes.Filter(paginationQuery, postLike => postLike.MatchesFilter(filterQuery), postLike => postLike.ToResponseWithoutUser(currentUserQuery.Id));
		}

		public long ToTotalCountResponse(
			PostLikesFilterQuery filterQuery)
		{
			return postLikes.Count(postLike => postLike.MatchesFilter(filterQuery));
		}

		public long ToTotalCountResponse(
			PostLikesForUserFilterQuery filterQuery)
		{
			return postLikes.Count(postLike => postLike.MatchesFilter(filterQuery));
		}
	}
}
