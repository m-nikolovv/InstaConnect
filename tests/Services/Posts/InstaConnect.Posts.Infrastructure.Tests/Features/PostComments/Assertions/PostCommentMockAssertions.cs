using InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostComments.Assertions;

public static class PostCommentMockAssertions
{
	extension(IPostCommentCollection collection)
	{
		public void ShouldHaveReceivedOneAggregateFluent(PostCommentId id)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(ICollection<PostCommentId> ids)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(
			PostCommentId id,
			CurrentUserQuery currentUserQuery)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(PostCommentsFilterQuery filterQuery)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(PostCommentsForUserFilterQuery filterQuery)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(
			PostCommentsFilterQuery filterQuery,
			PostCommentsSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(
			PostCommentsForUserFilterQuery filterQuery,
			PostCommentsForUserSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent()
		{
			collection.ShouldHaveReceivedOne().AggregateFluent();
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().AddAsync(postComment, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddRangeAsync(
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().AddRangeAsync(postComments, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().UpdateAsync(postComment, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().DeleteAsync(postComment, cancellationToken);
		}
	}

	extension(IPostCommentFluent fluent)
	{
		public void ShouldHaveReceivedOneMatch(PostCommentsFilterQuery filterQuery)
		{
			fluent.ShouldHaveReceivedOne().Match(filterQuery);
		}

		public void ShouldHaveReceivedOneMatch(PostCommentsForUserFilterQuery filterQuery)
		{
			fluent.ShouldHaveReceivedOne().Match(filterQuery);
		}

		public void ShouldHaveReceivedOneMatch(
			PostCommentsFilterQuery filterQuery,
			PostCommentsSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneMatch(filterQuery);
		}

		public void ShouldHaveReceivedOneMatch(
			PostCommentsForUserFilterQuery filterQuery,
			PostCommentsForUserSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneMatch(filterQuery);
		}

		public void ShouldHaveReceivedOneMatch(
			PostCommentId filterQuery)
		{
			fluent.ShouldHaveReceivedOne().Match(filterQuery);
		}

		public void ShouldHaveReceivedOneMatch(
			ICollection<PostCommentId> ids)
		{
			fluent.ShouldHaveReceivedOne().Match(ids);
		}

		public void ShouldHaveReceivedOneMatch(
			PostCommentId filterQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneMatch(filterQuery);
		}

		public void ShouldHaveReceivedOneInclude(
			PostCommentId id,
			PostCommentInclude include)
		{
			fluent.ShouldHaveReceivedOneInclude(include);
		}

		public void ShouldHaveReceivedOneInclude(
			ICollection<PostCommentId> ids,
			PostCommentInclude include)
		{
			fluent.ShouldHaveReceivedOneInclude(include);
		}

		public void ShouldHaveReceivedOneInclude(
			PostCommentId id,
			CurrentUserQuery currentUserQuery,
			PostCommentInclude include)
		{
			fluent.ShouldHaveReceivedOneInclude(include);
		}

		public void ShouldHaveReceivedOneInclude(
			PostCommentsFilterQuery filterQuery,
			PostCommentInclude include)
		{
			fluent.ShouldHaveReceivedOneInclude(include);
		}

		public void ShouldHaveReceivedOneInclude(
			PostCommentsForUserFilterQuery filterQuery,
			PostCommentInclude include)
		{
			fluent.ShouldHaveReceivedOneInclude(include);
		}

		public void ShouldHaveReceivedOneInclude(
			PostCommentsFilterQuery filterQuery,
			PostCommentsSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			PostCommentInclude include)
		{
			fluent.ShouldHaveReceivedOneInclude(include);
		}

		public void ShouldHaveReceivedOneInclude(
			PostCommentsForUserFilterQuery filterQuery,
			PostCommentsForUserSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			PostCommentInclude include)
		{
			fluent.ShouldHaveReceivedOneInclude(include);
		}

		public void ShouldHaveReceivedOneInclude(PostCommentInclude include)
		{
			fluent.ShouldHaveReceivedOne().Include(include);
		}

		public void ShouldHaveReceivedOneProjectToFullResponse(
			PostCommentId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneProjectToFullResponse(currentUserQuery);
		}

		public void ShouldHaveReceivedOneProjectToFullResponse(CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().ProjectToFullResponse(currentUserQuery);
		}

		public void ShouldHaveReceivedOneProjectToResponseWithoutPost(
			PostCommentsFilterQuery filterQuery,
			PostCommentsSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneProjectToResponseWithoutPost(currentUserQuery);
		}

		public void ShouldHaveReceivedOneProjectToResponseWithoutPost(CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().ProjectToResponseWithoutPost(currentUserQuery);
		}

		public void ShouldHaveReceivedOneProjectToResponseWithoutUser(
			PostCommentsForUserFilterQuery filterQuery,
			PostCommentsForUserSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneProjectToResponseWithoutUser(currentUserQuery);
		}

		public void ShouldHaveReceivedOneProjectToResponseWithoutUser(CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().ProjectToResponseWithoutUser(currentUserQuery);
		}

		public async Task ShouldHaveReceivedOneAnyAsync(
			PostCommentId id,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneAnyAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetCountAsync(
			PostCommentsFilterQuery filterQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneGetCountAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetCountAsync(
			PostCommentsForUserFilterQuery filterQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneGetCountAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneFirstOrDefaultAsync(
			PostCommentId id,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneToListAsync(
			ICollection<PostCommentId> ids,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneToListAsync(cancellationToken);
		}
	}

	extension(IPostCommentResponseFluent fluent)
	{
		public void ShouldHaveReceivedOneSort(
			PostCommentsFilterQuery filterQuery,
			PostCommentsSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneSort(sortingQuery);
		}

		public void ShouldHaveReceivedOneSort(
			PostCommentsForUserFilterQuery filterQuery,
			PostCommentsForUserSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneSort(sortingQuery);
		}

		public void ShouldHaveReceivedOneSort(PostCommentsSortingQuery sortingQuery)
		{
			fluent.ShouldHaveReceivedOne().Sort(sortingQuery);
		}

		public void ShouldHaveReceivedOneSort(PostCommentsForUserSortingQuery sortingQuery)
		{
			fluent.ShouldHaveReceivedOne().Sort(sortingQuery);
		}

		public void ShouldHaveReceivedOnePaginate(
			PostCommentsFilterQuery filterQuery,
			PostCommentsSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOnePaginate(paginationQuery);
		}

		public void ShouldHaveReceivedOnePaginate(
			PostCommentsForUserFilterQuery filterQuery,
			PostCommentsForUserSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOnePaginate(paginationQuery);
		}

		public void ShouldHaveReceivedOnePaginate(PostCommentsPaginationQuery paginationQuery)
		{
			fluent.ShouldHaveReceivedOne().Paginate(paginationQuery);
		}

		public async Task ShouldHaveReceivedOneFirstOrDefaultAsync(
			PostCommentId id,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneToListAsync(
			PostCommentsFilterQuery filterQuery,
			PostCommentsSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneToListAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneToListAsync(
			PostCommentsForUserFilterQuery filterQuery,
			PostCommentsForUserSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneToListAsync(cancellationToken);
		}
	}
}
