using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeMatchAssertions
{
	extension(PostCommentLike response)
	{
		public void ShouldSatisfy(PostCommentLikeId id, PostCommentLike postCommentLike)
		{
			response.ShouldSatisfy(p => p.Matches(id, postCommentLike));
		}
	}

	extension(PostCommentLikeResponse response)
	{
		public void ShouldSatisfy(PostCommentLikeId id, CurrentUserQuery currentUserQuery, PostCommentLike postCommentLike)
		{
			response.ShouldSatisfy(p => p.Matches(id, currentUserQuery, postCommentLike));
		}
	}

	extension(ICollection<PostCommentLikeResponse> response)
	{
		public void ShouldSatisfy(
			PostCommentLikesFilterQuery filterQuery,
			PostCommentLikesSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			PostComment postComment,
			ICollection<PostCommentLike> postCommentLikes)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, sortingQuery, paginationQuery, currentUserQuery, postComment, postCommentLikes));
		}

		public void ShouldSatisfy(
			PostCommentLikesFilterQuery filterQuery,
			PostCommentLikesSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			PostComment postComment,
			ICollection<PostCommentLike> postCommentLikes,
			ISortEnumTermTransformer<PostCommentLike> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, sortingQuery, paginationQuery, currentUserQuery, postComment, postCommentLikes, termTransformer));
		}

		public void ShouldSatisfy(
			PostCommentLikesForUserFilterQuery filterQuery,
			PostCommentLikesForUserSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			User user,
			ICollection<PostCommentLike> postCommentLikes)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, sortingQuery, paginationQuery, currentUserQuery, user, postCommentLikes));
		}

		public void ShouldSatisfy(
			PostCommentLikesForUserFilterQuery filterQuery,
			PostCommentLikesForUserSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			User user,
			ICollection<PostCommentLike> postCommentLikes,
			ISortEnumTermTransformer<PostCommentLike> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, sortingQuery, paginationQuery, currentUserQuery, user, postCommentLikes, termTransformer));
		}
	}

	extension(long response)
	{
		public void ShouldSatisfy(
			PostCommentLikesFilterQuery filterQuery,
			ICollection<PostCommentLike> postCommentLikes)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, postCommentLikes));
		}

		public void ShouldSatisfy(
			PostCommentLikesForUserFilterQuery filterQuery,
			ICollection<PostCommentLike> postCommentLikes)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, postCommentLikes));
		}
	}

	extension(bool response)
	{
		public void ShouldSatisfy(PostCommentLikeId id, PostCommentLike? postCommentLike)
		{
			response.ShouldSatisfy(p => p.Matches(id, postCommentLike));
		}
	}
}
