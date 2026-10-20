using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.Posts.Assertions;

public static class PostMockAssertions
{
	extension(IPostCollection collection)
	{
		public void ShouldHaveReceivedOneAggregateFluent(PostId id)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(
			PostId id,
			CurrentUserQuery currentUserQuery)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(PostsFilterQuery filterQuery)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(PostsForUserFilterQuery filterQuery)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(
			PostsFilterQuery filterQuery,
			PostsSortingQuery sortingQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(
			PostsForUserFilterQuery filterQuery,
			PostsForUserSortingQuery sortingQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent()
		{
			collection.ShouldHaveReceivedOne().AggregateFluent();
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			Post post,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().UpdateAsync(post, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			Post post,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().DeleteAsync(post, cancellationToken);
		}
	}

	extension(IPostFluent fluent)
	{
		public void ShouldHaveReceivedOneMatch(PostsFilterQuery filterQuery)
		{
			fluent.ShouldHaveReceivedOne().Match(filterQuery);
		}

		public void ShouldHaveReceivedOneMatch(PostsForUserFilterQuery filterQuery)
		{
			fluent.ShouldHaveReceivedOne().Match(filterQuery);
		}

		public void ShouldHaveReceivedOneMatch(
			PostsFilterQuery filterQuery,
			PostsSortingQuery sortingQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneMatch(filterQuery);
		}

		public void ShouldHaveReceivedOneMatch(
			PostsForUserFilterQuery filterQuery,
			PostsForUserSortingQuery sortingQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneMatch(filterQuery);
		}

		public void ShouldHaveReceivedOneMatch(
			PostId filterQuery)
		{
			fluent.ShouldHaveReceivedOne().Match(filterQuery);
		}

		public void ShouldHaveReceivedOneMatch(
			PostId filterQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneMatch(filterQuery);
		}

		public void ShouldHaveReceivedOneApplyIncludes(
			PostId id,
			PostInclude include)
		{
			fluent.ShouldHaveReceivedOneApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneApplyIncludes(
			PostId id,
			CurrentUserQuery currentUserQuery,
			PostInclude include)
		{
			fluent.ShouldHaveReceivedOneApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneApplyIncludes(
			PostsFilterQuery filterQuery,
			PostInclude include)
		{
			fluent.ShouldHaveReceivedOneApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneApplyIncludes(
			PostsForUserFilterQuery filterQuery,
			PostInclude include)
		{
			fluent.ShouldHaveReceivedOneApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneApplyIncludes(
			PostsFilterQuery filterQuery,
			PostsSortingQuery sortingQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			PostInclude include)
		{
			fluent.ShouldHaveReceivedOneApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneApplyIncludes(
			PostsForUserFilterQuery filterQuery,
			PostsForUserSortingQuery sortingQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			PostInclude include)
		{
			fluent.ShouldHaveReceivedOneApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneApplyIncludes(PostInclude include)
		{
			fluent.ShouldHaveReceivedOne().ApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneProjectToFullResponse(
			PostsFilterQuery filterQuery,
			PostsSortingQuery sortingQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneProjectToFullResponse(currentUserQuery);
		}

		public void ShouldHaveReceivedOneProjectToFullResponse(
			PostId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneProjectToFullResponse(currentUserQuery);
		}

		public void ShouldHaveReceivedOneProjectToFullResponse(CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().ProjectToFullResponse(currentUserQuery);
		}

		public void ShouldHaveReceivedOneProjectToResponseWithoutUser(
			PostsForUserFilterQuery filterQuery,
			PostsForUserSortingQuery sortingQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneProjectToResponseWithoutUser(currentUserQuery);
		}

		public void ShouldHaveReceivedOneProjectToResponseWithoutUser(CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().ProjectToResponseWithoutUser(currentUserQuery);
		}

		public async Task ShouldHaveReceivedOneAnyAsync(
			PostId id,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneAnyAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetCountAsync(
			PostsFilterQuery filterQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneGetCountAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetCountAsync(
			PostsForUserFilterQuery filterQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneGetCountAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneFirstOrDefaultAsync(
			PostId id,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(cancellationToken);
		}
	}

	extension(IPostResponseFluent fluent)
	{
		public void ShouldHaveReceivedOneApplySorting(
			PostsFilterQuery filterQuery,
			PostsSortingQuery sortingQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneApplySorting(sortingQuery);
		}

		public void ShouldHaveReceivedOneApplySorting(
			PostsForUserFilterQuery filterQuery,
			PostsForUserSortingQuery sortingQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneApplySorting(sortingQuery);
		}

		public void ShouldHaveReceivedOneApplySorting(PostsSortingQuery sortingQuery)
		{
			fluent.ShouldHaveReceivedOne().ApplySorting(sortingQuery);
		}

		public void ShouldHaveReceivedOneApplySorting(PostsForUserSortingQuery sortingQuery)
		{
			fluent.ShouldHaveReceivedOne().ApplySorting(sortingQuery);
		}

		public void ShouldHaveReceivedOneApplyPagination(
			PostsFilterQuery filterQuery,
			PostsSortingQuery sortingQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneApplyPagination(paginationQuery);
		}

		public void ShouldHaveReceivedOneApplyPagination(
			PostsForUserFilterQuery filterQuery,
			PostsForUserSortingQuery sortingQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneApplyPagination(paginationQuery);
		}

		public void ShouldHaveReceivedOneApplyPagination(PostsPaginationQuery paginationQuery)
		{
			fluent.ShouldHaveReceivedOne().ApplyPagination(paginationQuery);
		}

		public async Task ShouldHaveReceivedOneFirstOrDefaultAsync(
			PostId id,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneToListAsync(
			PostsFilterQuery filterQuery,
			PostsSortingQuery sortingQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneToListAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneToListAsync(
			PostsForUserFilterQuery filterQuery,
			PostsForUserSortingQuery sortingQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneToListAsync(cancellationToken);
		}
	}
}
