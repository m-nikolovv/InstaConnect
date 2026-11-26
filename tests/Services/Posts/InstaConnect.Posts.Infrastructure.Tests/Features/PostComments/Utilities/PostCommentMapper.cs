using InstaConnect.Posts.Domain.Features.PostComments.Models.Responses;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostComments.Utilities;

public static class PostCommentMapper
{
	extension(ICollection<PostComment> postComments)
	{
		public ICollection<PostCommentResponse> ToResponse(
			PostCommentsFilterQuery filterQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			return postComments.Filter(paginationQuery, postComment => postComment.MatchesFilter(filterQuery), postComment => postComment.ToResponseWithoutPost(currentUserQuery.Id));
		}

		public ICollection<PostCommentResponse> ToResponse(
			PostCommentsForUserFilterQuery filterQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			return postComments.Filter(paginationQuery, postComment => postComment.MatchesFilter(filterQuery), postComment => postComment.ToResponseWithoutUser(currentUserQuery.Id));
		}

		public long ToTotalCountResponse(
			PostCommentsFilterQuery filterQuery)
		{
			return postComments.Count(postComment => postComment.MatchesFilter(filterQuery));
		}

		public long ToTotalCountResponse(
			PostCommentsForUserFilterQuery filterQuery)
		{
			return postComments.Count(postComment => postComment.MatchesFilter(filterQuery));
		}
	}
}
