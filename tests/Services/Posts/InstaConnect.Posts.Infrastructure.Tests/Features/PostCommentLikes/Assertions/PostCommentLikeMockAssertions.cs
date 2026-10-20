using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeMockAssertions
{
	extension(IPostCommentLikeCollection collection)
	{
		public void ShouldHaveReceivedOneAggregateFluent(PostCommentLikeId id)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(
			PostCommentLikeId id,
			CurrentUserQuery currentUserQuery)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(PostCommentLikesFilterQuery filterQuery)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(PostCommentLikesForUserFilterQuery filterQuery)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(
			PostCommentLikesFilterQuery filterQuery,
			PostCommentLikesSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(
			PostCommentLikesForUserFilterQuery filterQuery,
			PostCommentLikesForUserSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent()
		{
			collection.ShouldHaveReceivedOne().AggregateFluent();
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().DeleteAsync(postCommentLike, cancellationToken);
		}
	}

	extension(IPostCommentLikeFluent fluent)
	{
		public void ShouldHaveReceivedOneMatch(PostCommentLikesFilterQuery filterQuery)
		{
			fluent.ShouldHaveReceivedOne().Match(filterQuery);
		}

		public void ShouldHaveReceivedOneMatch(PostCommentLikesForUserFilterQuery filterQuery)
		{
			fluent.ShouldHaveReceivedOne().Match(filterQuery);
		}

		public void ShouldHaveReceivedOneMatch(
			PostCommentLikesFilterQuery filterQuery,
			PostCommentLikesSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneMatch(filterQuery);
		}

		public void ShouldHaveReceivedOneMatch(
			PostCommentLikesForUserFilterQuery filterQuery,
			PostCommentLikesForUserSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneMatch(filterQuery);
		}

		public void ShouldHaveReceivedOneMatch(
			PostCommentLikeId filterQuery)
		{
			fluent.ShouldHaveReceivedOne().Match(filterQuery);
		}

		public void ShouldHaveReceivedOneMatch(
			PostCommentLikeId filterQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneMatch(filterQuery);
		}

		public void ShouldHaveReceivedOneApplyIncludes(
			PostCommentLikeId id,
			PostCommentLikeInclude include)
		{
			fluent.ShouldHaveReceivedOneApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneApplyIncludes(
			PostCommentLikeId id,
			CurrentUserQuery currentUserQuery,
			PostCommentLikeInclude include)
		{
			fluent.ShouldHaveReceivedOneApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneApplyIncludes(
			PostCommentLikesFilterQuery filterQuery,
			PostCommentLikeInclude include)
		{
			fluent.ShouldHaveReceivedOneApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneApplyIncludes(
			PostCommentLikesForUserFilterQuery filterQuery,
			PostCommentLikeInclude include)
		{
			fluent.ShouldHaveReceivedOneApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneApplyIncludes(
			PostCommentLikesFilterQuery filterQuery,
			PostCommentLikesSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			PostCommentLikeInclude include)
		{
			fluent.ShouldHaveReceivedOneApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneApplyIncludes(
			PostCommentLikesForUserFilterQuery filterQuery,
			PostCommentLikesForUserSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			PostCommentLikeInclude include)
		{
			fluent.ShouldHaveReceivedOneApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneApplyIncludes(PostCommentLikeInclude include)
		{
			fluent.ShouldHaveReceivedOne().ApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneProjectToFullResponse(
			PostCommentLikeId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneProjectToFullResponse(currentUserQuery);
		}

		public void ShouldHaveReceivedOneProjectToFullResponse(CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().ProjectToFullResponse(currentUserQuery);
		}

		public void ShouldHaveReceivedOneProjectToResponseWithoutPostComment(
			PostCommentLikesFilterQuery filterQuery,
			PostCommentLikesSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneProjectToResponseWithoutPostComment(currentUserQuery);
		}

		public void ShouldHaveReceivedOneProjectToResponseWithoutPostComment(CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().ProjectToResponseWithoutPostComment(currentUserQuery);
		}

		public void ShouldHaveReceivedOneProjectToResponseWithoutUser(
			PostCommentLikesForUserFilterQuery filterQuery,
			PostCommentLikesForUserSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneProjectToResponseWithoutUser(currentUserQuery);
		}

		public void ShouldHaveReceivedOneProjectToResponseWithoutUser(CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().ProjectToResponseWithoutUser(currentUserQuery);
		}

		public async Task ShouldHaveReceivedOneAnyAsync(
			PostCommentLikeId id,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneAnyAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetCountAsync(
			PostCommentLikesFilterQuery filterQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneGetCountAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetCountAsync(
			PostCommentLikesForUserFilterQuery filterQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneGetCountAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneFirstOrDefaultAsync(
			PostCommentLikeId id,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(cancellationToken);
		}
	}

	extension(IPostCommentLikeResponseFluent fluent)
	{
		public void ShouldHaveReceivedOneApplySorting(
			PostCommentLikesFilterQuery filterQuery,
			PostCommentLikesSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneApplySorting(sortingQuery);
		}

		public void ShouldHaveReceivedOneApplySorting(
			PostCommentLikesForUserFilterQuery filterQuery,
			PostCommentLikesForUserSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneApplySorting(sortingQuery);
		}

		public void ShouldHaveReceivedOneApplySorting(PostCommentLikesSortingQuery sortingQuery)
		{
			fluent.ShouldHaveReceivedOne().ApplySorting(sortingQuery);
		}

		public void ShouldHaveReceivedOneApplySorting(PostCommentLikesForUserSortingQuery sortingQuery)
		{
			fluent.ShouldHaveReceivedOne().ApplySorting(sortingQuery);
		}

		public void ShouldHaveReceivedOneApplyPagination(
			PostCommentLikesFilterQuery filterQuery,
			PostCommentLikesSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneApplyPagination(paginationQuery);
		}

		public void ShouldHaveReceivedOneApplyPagination(
			PostCommentLikesForUserFilterQuery filterQuery,
			PostCommentLikesForUserSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneApplyPagination(paginationQuery);
		}

		public void ShouldHaveReceivedOneApplyPagination(PostCommentLikesPaginationQuery paginationQuery)
		{
			fluent.ShouldHaveReceivedOne().ApplyPagination(paginationQuery);
		}

		public async Task ShouldHaveReceivedOneFirstOrDefaultAsync(
			PostCommentLikeId id,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneToListAsync(
			PostCommentLikesFilterQuery filterQuery,
			PostCommentLikesSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneToListAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneToListAsync(
			PostCommentLikesForUserFilterQuery filterQuery,
			PostCommentLikesForUserSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneToListAsync(cancellationToken);
		}
	}
}
