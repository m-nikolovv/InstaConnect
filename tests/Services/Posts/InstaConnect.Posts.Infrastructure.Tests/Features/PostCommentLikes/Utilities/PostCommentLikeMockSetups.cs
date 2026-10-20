using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeMockSetups
{
	extension(IPostCommentLikeCollection collection)
	{
		public void SetupAggregateFluent(
			PostCommentLikeId id,
			IPostCommentLikeFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			PostCommentLikeId id,
			CurrentUserQuery currentUserQuery,
			IPostCommentLikeFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			PostCommentLikesFilterQuery filterQuery,
			PostCommentLikesSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IPostCommentLikeFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			PostCommentLikesFilterQuery filterQuery,
			IPostCommentLikeFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			PostCommentLikesForUserFilterQuery filterQuery,
			PostCommentLikesForUserSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IPostCommentLikeFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			PostCommentLikesForUserFilterQuery filterQuery,
			IPostCommentLikeFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(IPostCommentLikeFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}
	}

	extension(IPostCommentLikeFluent fluent)
	{
		public void SetupGetCountAsync(
			PostCommentLikesFilterQuery filterQuery,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			fluent.SetupGetCountAsync(postCommentLikes.ToTotalCountResponse(filterQuery), cancellationToken);
		}

		public void SetupGetCountAsync(
			PostCommentLikesForUserFilterQuery filterQuery,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			fluent.SetupGetCountAsync(postCommentLikes.ToTotalCountResponse(filterQuery), cancellationToken);
		}

		public void SetupAnyAsync(
			PostCommentLikeId id,
			PostCommentLike? postCommentLike,
			CancellationToken cancellationToken)
		{
			fluent.SetupAnyAsync(postCommentLike != null, cancellationToken);
		}

		public void SetupApplyIncludes(
			PostCommentLikeId id,
			PostCommentLikeInclude include)
		{
			fluent.SetupApplyIncludes(include);
		}

		public void SetupApplyIncludes(
			PostCommentLikeId id,
			CurrentUserQuery currentUserQuery,
			PostCommentLikeInclude include)
		{
			fluent.SetupApplyIncludes(include);
		}

		public void SetupApplyIncludes(
			PostCommentLikesFilterQuery filterQuery,
			PostCommentLikeInclude include)
		{
			fluent.SetupApplyIncludes(include);
		}

		public void SetupApplyIncludes(
			PostCommentLikesForUserFilterQuery filterQuery,
			PostCommentLikeInclude include)
		{
			fluent.SetupApplyIncludes(include);
		}

		public void SetupApplyIncludes(
			PostCommentLikesFilterQuery filterQuery,
			PostCommentLikesSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			PostCommentLikeInclude include)
		{
			fluent.SetupApplyIncludes(include);
		}

		public void SetupApplyIncludes(
			PostCommentLikesForUserFilterQuery filterQuery,
			PostCommentLikesForUserSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			PostCommentLikeInclude include)
		{
			fluent.SetupApplyIncludes(include);
		}

		public void SetupApplyIncludes(PostCommentLikeInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupMatch(PostCommentLikeId id)
		{
			fluent.Match(id).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			PostCommentLikeId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupMatch(id);
		}

		public void SetupMatch(PostCommentLikesFilterQuery filterQuery)
		{
			fluent.Match(filterQuery).ReturnsResponse(fluent);
		}

		public void SetupMatch(PostCommentLikesForUserFilterQuery filterQuery)
		{
			fluent.Match(filterQuery).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			PostCommentLikesFilterQuery filterQuery,
			PostCommentLikesSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupMatch(filterQuery);
		}

		public void SetupMatch(
			PostCommentLikesForUserFilterQuery filterQuery,
			PostCommentLikesForUserSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupMatch(filterQuery);
		}

		public void SetupProjectToFullResponse(
			PostCommentLikeId id,
			CurrentUserQuery currentUserQuery,
			IPostCommentLikeResponseFluent responseFluent)
		{
			fluent.SetupProjectToFullResponse(currentUserQuery, responseFluent);
		}

		public void SetupProjectToFullResponse(
			CurrentUserQuery currentUserQuery,
			IPostCommentLikeResponseFluent responseFluent)
		{
			fluent.ProjectToFullResponse(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupProjectToResponseWithoutPostComment(
			PostCommentLikesFilterQuery filterQuery,
			PostCommentLikesSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IPostCommentLikeResponseFluent responseFluent)
		{
			fluent.SetupProjectToResponseWithoutPostComment(currentUserQuery, responseFluent);
		}

		public void SetupProjectToResponseWithoutPostComment(
			CurrentUserQuery currentUserQuery,
			IPostCommentLikeResponseFluent responseFluent)
		{
			fluent.ProjectToResponseWithoutPostComment(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupProjectToResponseWithoutUser(
			PostCommentLikesForUserFilterQuery filterQuery,
			PostCommentLikesForUserSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IPostCommentLikeResponseFluent responseFluent)
		{
			fluent.SetupProjectToResponseWithoutUser(currentUserQuery, responseFluent);
		}

		public void SetupProjectToResponseWithoutUser(
			CurrentUserQuery currentUserQuery,
			IPostCommentLikeResponseFluent responseFluent)
		{
			fluent.ProjectToResponseWithoutUser(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupFirstOrDefaultAsync(
			PostCommentLikeId id,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			fluent.SetupFirstOrDefaultAsync(postCommentLike, cancellationToken);
		}
	}

	extension(IPostCommentLikeResponseFluent fluent)
	{
		public void SetupApplySorting(
			PostCommentLikesFilterQuery filterQuery,
			PostCommentLikesSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupApplySorting(sortingQuery);
		}

		public void SetupApplySorting(
			PostCommentLikesForUserFilterQuery filterQuery,
			PostCommentLikesForUserSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupApplySorting(sortingQuery);
		}

		public void SetupApplySorting(PostCommentLikesSortingQuery sortingQuery)
		{
			fluent.ApplySorting(sortingQuery).ReturnsResponse(fluent);
		}

		public void SetupApplySorting(PostCommentLikesForUserSortingQuery sortingQuery)
		{
			fluent.ApplySorting(sortingQuery).ReturnsResponse(fluent);
		}

		public void SetupApplyPagination(
			PostCommentLikesFilterQuery filterQuery,
			PostCommentLikesSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupApplyPagination(paginationQuery);
		}

		public void SetupApplyPagination(
			PostCommentLikesForUserFilterQuery filterQuery,
			PostCommentLikesForUserSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupApplyPagination(paginationQuery);
		}

		public void SetupApplyPagination(PostCommentLikesPaginationQuery paginationQuery)
		{
			fluent.ApplyPagination(paginationQuery).ReturnsResponse(fluent);
		}

		public void SetupToListAsync(
			PostCommentLikesFilterQuery filterQuery,
			PostCommentLikesSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			fluent.SetupToListAsync(postCommentLikes.ToResponse(filterQuery, paginationQuery, currentUserQuery), cancellationToken);
		}

		public void SetupToListAsync(
			PostCommentLikesForUserFilterQuery filterQuery,
			PostCommentLikesForUserSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			fluent.SetupToListAsync(postCommentLikes.ToResponse(filterQuery, paginationQuery, currentUserQuery), cancellationToken);
		}

		public void SetupFirstOrDefaultAsync(
			PostCommentLikeId id,
			CurrentUserQuery currentUserQuery,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			fluent.SetupFirstOrDefaultAsync(postCommentLike.ToFullResponse(currentUserQuery), cancellationToken);
		}
	}
}
