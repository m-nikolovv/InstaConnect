using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Responses;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeMapper
{
	extension(ICollection<PostCommentLike> postCommentLikes)
	{
		public ICollection<PostCommentLikeResponse> ToResponse(
			PostCommentLikesFilterQuery filterQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			return postCommentLikes.Filter(paginationQuery, postCommentLike => postCommentLike.MatchesFilter(filterQuery), postCommentLike => postCommentLike.ToResponseWithoutPostComment());
		}

		public ICollection<PostCommentLikeResponse> ToResponse(
			PostCommentLikesForUserFilterQuery filterQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			return postCommentLikes.Filter(paginationQuery, postCommentLike => postCommentLike.MatchesFilter(filterQuery), postCommentLike => postCommentLike.ToResponseWithoutUser(currentUserQuery.Id));
		}

		public long ToTotalCountResponse(
			PostCommentLikesFilterQuery filterQuery)
		{
			return postCommentLikes.Count(postCommentLike => postCommentLike.MatchesFilter(filterQuery));
		}

		public long ToTotalCountResponse(
			PostCommentLikesForUserFilterQuery filterQuery)
		{
			return postCommentLikes.Count(postCommentLike => postCommentLike.MatchesFilter(filterQuery));
		}
	}
}
