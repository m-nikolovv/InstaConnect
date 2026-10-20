using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Responses;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeMapper
{
	extension(PostCommentLike postCommentLike)
	{
		internal PostCommentLikeResponse ToFullResponse(CurrentUserQuery query)
		{
			return new(postCommentLike.Id,
					   postCommentLike.User?.ToFullResponse(),
					   postCommentLike.PostComment?.ToFullResponse(query),
					   postCommentLike.CreatedAtUtc);
		}

		internal PostCommentLikeResponse ToResponseWithoutUser(CurrentUserQuery query)
		{
			return new(postCommentLike.Id,
					   null,
					   postCommentLike.PostComment?.ToFullResponse(query),
					   postCommentLike.CreatedAtUtc);
		}

		internal PostCommentLikeResponse ToResponseWithoutPostComment()
		{
			return new(postCommentLike.Id,
					   postCommentLike.User?.ToFullResponse(),
					   null,
					   postCommentLike.CreatedAtUtc);
		}
	}

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
			return postCommentLikes.Filter(paginationQuery, postCommentLike => postCommentLike.MatchesFilter(filterQuery), postCommentLike => postCommentLike.ToResponseWithoutUser(currentUserQuery));
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
