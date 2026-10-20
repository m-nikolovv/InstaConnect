using InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostComments.Utilities;

public static class PostCommentMockSetups
{
	extension(IPostCommentCollection collection)
	{
		public void SetupAggregateFluent(
			PostCommentId id,
			IPostCommentFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			PostCommentId id,
			CurrentUserQuery currentUserQuery,
			IPostCommentFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			PostCommentsFilterQuery filterQuery,
			PostCommentsSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IPostCommentFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			PostCommentsFilterQuery filterQuery,
			IPostCommentFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			PostCommentsForUserFilterQuery filterQuery,
			PostCommentsForUserSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IPostCommentFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			PostCommentsForUserFilterQuery filterQuery,
			IPostCommentFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(IPostCommentFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}
	}

	extension(IPostCommentFluent fluent)
	{
		public void SetupGetCountAsync(
			PostCommentsFilterQuery filterQuery,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			fluent.SetupGetCountAsync(postComments.ToTotalCountResponse(filterQuery), cancellationToken);
		}

		public void SetupGetCountAsync(
			PostCommentsForUserFilterQuery filterQuery,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			fluent.SetupGetCountAsync(postComments.ToTotalCountResponse(filterQuery), cancellationToken);
		}

		public void SetupAnyAsync(
			PostCommentId id,
			PostComment? postComment,
			CancellationToken cancellationToken)
		{
			fluent.SetupAnyAsync(postComment != null, cancellationToken);
		}

		public void SetupApplyIncludes(
			PostCommentId id,
			PostCommentInclude include)
		{
			fluent.SetupApplyIncludes(include);
		}

		public void SetupApplyIncludes(
			PostCommentId id,
			CurrentUserQuery currentUserQuery,
			PostCommentInclude include)
		{
			fluent.SetupApplyIncludes(include);
		}

		public void SetupApplyIncludes(
			PostCommentsFilterQuery filterQuery,
			PostCommentInclude include)
		{
			fluent.SetupApplyIncludes(include);
		}

		public void SetupApplyIncludes(
			PostCommentsForUserFilterQuery filterQuery,
			PostCommentInclude include)
		{
			fluent.SetupApplyIncludes(include);
		}

		public void SetupApplyIncludes(
			PostCommentsFilterQuery filterQuery,
			PostCommentsSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			PostCommentInclude include)
		{
			fluent.SetupApplyIncludes(include);
		}

		public void SetupApplyIncludes(
			PostCommentsForUserFilterQuery filterQuery,
			PostCommentsForUserSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			PostCommentInclude include)
		{
			fluent.SetupApplyIncludes(include);
		}

		public void SetupApplyIncludes(PostCommentInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupMatch(PostCommentId id)
		{
			fluent.Match(id).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			PostCommentId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupMatch(id);
		}

		public void SetupMatch(PostCommentsFilterQuery filterQuery)
		{
			fluent.Match(filterQuery).ReturnsResponse(fluent);
		}

		public void SetupMatch(PostCommentsForUserFilterQuery filterQuery)
		{
			fluent.Match(filterQuery).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			PostCommentsFilterQuery filterQuery,
			PostCommentsSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupMatch(filterQuery);
		}

		public void SetupMatch(
			PostCommentsForUserFilterQuery filterQuery,
			PostCommentsForUserSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupMatch(filterQuery);
		}

		public void SetupProjectToFullResponse(
			PostCommentId id,
			CurrentUserQuery currentUserQuery,
			IPostCommentResponseFluent responseFluent)
		{
			fluent.SetupProjectToFullResponse(currentUserQuery, responseFluent);
		}

		public void SetupProjectToFullResponse(
			CurrentUserQuery currentUserQuery,
			IPostCommentResponseFluent responseFluent)
		{
			fluent.ProjectToFullResponse(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupProjectToResponseWithoutPost(
			PostCommentsFilterQuery filterQuery,
			PostCommentsSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IPostCommentResponseFluent responseFluent)
		{
			fluent.SetupProjectToResponseWithoutPost(currentUserQuery, responseFluent);
		}

		public void SetupProjectToResponseWithoutPost(
			CurrentUserQuery currentUserQuery,
			IPostCommentResponseFluent responseFluent)
		{
			fluent.ProjectToResponseWithoutPost(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupProjectToResponseWithoutUser(
			PostCommentsForUserFilterQuery filterQuery,
			PostCommentsForUserSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IPostCommentResponseFluent responseFluent)
		{
			fluent.SetupProjectToResponseWithoutUser(currentUserQuery, responseFluent);
		}

		public void SetupProjectToResponseWithoutUser(
			CurrentUserQuery currentUserQuery,
			IPostCommentResponseFluent responseFluent)
		{
			fluent.ProjectToResponseWithoutUser(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupFirstOrDefaultAsync(
			PostCommentId id,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			fluent.SetupFirstOrDefaultAsync(postComment, cancellationToken);
		}
	}

	extension(IPostCommentResponseFluent fluent)
	{
		public void SetupApplySorting(
			PostCommentsFilterQuery filterQuery,
			PostCommentsSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupApplySorting(sortingQuery);
		}

		public void SetupApplySorting(
			PostCommentsForUserFilterQuery filterQuery,
			PostCommentsForUserSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupApplySorting(sortingQuery);
		}

		public void SetupApplySorting(PostCommentsSortingQuery sortingQuery)
		{
			fluent.ApplySorting(sortingQuery).ReturnsResponse(fluent);
		}

		public void SetupApplySorting(PostCommentsForUserSortingQuery sortingQuery)
		{
			fluent.ApplySorting(sortingQuery).ReturnsResponse(fluent);
		}

		public void SetupApplyPagination(
			PostCommentsFilterQuery filterQuery,
			PostCommentsSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupApplyPagination(paginationQuery);
		}

		public void SetupApplyPagination(
			PostCommentsForUserFilterQuery filterQuery,
			PostCommentsForUserSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupApplyPagination(paginationQuery);
		}

		public void SetupApplyPagination(PostCommentsPaginationQuery paginationQuery)
		{
			fluent.ApplyPagination(paginationQuery).ReturnsResponse(fluent);
		}

		public void SetupToListAsync(
			PostCommentsFilterQuery filterQuery,
			PostCommentsSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			fluent.SetupToListAsync(postComments.ToResponse(filterQuery, paginationQuery, currentUserQuery), cancellationToken);
		}

		public void SetupToListAsync(
			PostCommentsForUserFilterQuery filterQuery,
			PostCommentsForUserSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			fluent.SetupToListAsync(postComments.ToResponse(filterQuery, paginationQuery, currentUserQuery), cancellationToken);
		}

		public void SetupFirstOrDefaultAsync(
			PostCommentId id,
			CurrentUserQuery currentUserQuery,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			fluent.SetupFirstOrDefaultAsync(postComment.ToFullResponse(currentUserQuery), cancellationToken);
		}
	}
}
