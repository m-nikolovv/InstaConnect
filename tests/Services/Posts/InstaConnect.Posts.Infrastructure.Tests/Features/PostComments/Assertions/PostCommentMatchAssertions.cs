using InstaConnect.Posts.Domain.Features.PostComments.Models.Responses;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostComments.Assertions;

public static class PostCommentMatchAssertions
{
	extension(PostComment response)
	{
		public void ShouldSatisfy(PostCommentId id, PostComment postComment)
		{
			response.ShouldSatisfy(p => p.Matches(id, postComment));
		}
	}

	extension(PostCommentResponse response)
	{
		public void ShouldSatisfy(PostCommentId id, CurrentUserQuery currentUserQuery, PostComment postComment)
		{
			response.ShouldSatisfy(p => p.Matches(id, currentUserQuery, postComment));
		}
	}

	extension(ICollection<PostCommentResponse> response)
	{
		public void ShouldSatisfy(
			PostCommentsFilterQuery filterQuery,
			PostCommentsSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			Post post,
			ICollection<PostComment> postComments)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, sortingQuery, paginationQuery, currentUserQuery, post, postComments));
		}

		public void ShouldSatisfy(
			PostCommentsFilterQuery filterQuery,
			PostCommentsSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			Post post,
			ICollection<PostComment> postComments,
			ISortEnumTermTransformer<PostComment> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, sortingQuery, paginationQuery, currentUserQuery, post, postComments, termTransformer));
		}

		public void ShouldSatisfy(
			PostCommentsForUserFilterQuery filterQuery,
			PostCommentsForUserSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			User user,
			ICollection<PostComment> postComments)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, sortingQuery, paginationQuery, currentUserQuery, user, postComments));
		}

		public void ShouldSatisfy(
			PostCommentsForUserFilterQuery filterQuery,
			PostCommentsForUserSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			User user,
			ICollection<PostComment> postComments,
			ISortEnumTermTransformer<PostComment> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, sortingQuery, paginationQuery, currentUserQuery, user, postComments, termTransformer));
		}
	}

	extension(long response)
	{
		public void ShouldSatisfy(
			PostCommentsFilterQuery filterQuery,
			ICollection<PostComment> postComments)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, postComments));
		}

		public void ShouldSatisfy(
			PostCommentsForUserFilterQuery filterQuery,
			ICollection<PostComment> postComments)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, postComments));
		}
	}

	extension(bool response)
	{
		public void ShouldSatisfy(PostCommentId id, PostComment? postComment)
		{
			response.ShouldSatisfy(p => p.Matches(id, postComment));
		}
	}
}
