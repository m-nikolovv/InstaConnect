using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Utilities;

public static class PostLikeMockSetups
{
	extension(IPostLikeCollection collection)
	{
		public void SetupAggregateFluent(
			PostLikeId id,
			IPostLikeFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			PostLikeId id,
			CurrentUserQuery currentUserQuery,
			IPostLikeFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			PostLikesFilterQuery filterQuery,
			PostLikesSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IPostLikeFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			PostLikesFilterQuery filterQuery,
			IPostLikeFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			PostLikesForUserFilterQuery filterQuery,
			PostLikesForUserSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IPostLikeFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			PostLikesForUserFilterQuery filterQuery,
			IPostLikeFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(IPostLikeFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}
	}

	extension(IPostLikeFluent fluent)
	{
		public void SetupGetCountAsync(
			PostLikesFilterQuery filterQuery,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			fluent.SetupGetCountAsync(postLikes.ToTotalCountResponse(filterQuery), cancellationToken);
		}

		public void SetupGetCountAsync(
			PostLikesForUserFilterQuery filterQuery,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			fluent.SetupGetCountAsync(postLikes.ToTotalCountResponse(filterQuery), cancellationToken);
		}

		public void SetupAnyAsync(
			PostLikeId id,
			PostLike? postLike,
			CancellationToken cancellationToken)
		{
			fluent.SetupAnyAsync(postLike != null, cancellationToken);
		}

		public void SetupApplyIncludes(
			PostLikeId id,
			PostLikeInclude include)
		{
			fluent.SetupApplyIncludes(include);
		}

		public void SetupApplyIncludes(
			PostLikeId id,
			CurrentUserQuery currentUserQuery,
			PostLikeInclude include)
		{
			fluent.SetupApplyIncludes(include);
		}

		public void SetupApplyIncludes(
			PostLikesFilterQuery filterQuery,
			PostLikeInclude include)
		{
			fluent.SetupApplyIncludes(include);
		}

		public void SetupApplyIncludes(
			PostLikesForUserFilterQuery filterQuery,
			PostLikeInclude include)
		{
			fluent.SetupApplyIncludes(include);
		}

		public void SetupApplyIncludes(
			PostLikesFilterQuery filterQuery,
			PostLikesSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			PostLikeInclude include)
		{
			fluent.SetupApplyIncludes(include);
		}

		public void SetupApplyIncludes(
			PostLikesForUserFilterQuery filterQuery,
			PostLikesForUserSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			PostLikeInclude include)
		{
			fluent.SetupApplyIncludes(include);
		}

		public void SetupApplyIncludes(PostLikeInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupMatch(PostLikeId id)
		{
			fluent.Match(id).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			PostLikeId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupMatch(id);
		}

		public void SetupMatch(PostLikesFilterQuery filterQuery)
		{
			fluent.Match(filterQuery).ReturnsResponse(fluent);
		}

		public void SetupMatch(PostLikesForUserFilterQuery filterQuery)
		{
			fluent.Match(filterQuery).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			PostLikesFilterQuery filterQuery,
			PostLikesSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupMatch(filterQuery);
		}

		public void SetupMatch(
			PostLikesForUserFilterQuery filterQuery,
			PostLikesForUserSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupMatch(filterQuery);
		}

		public void SetupProjectToFullResponse(
			PostLikeId id,
			CurrentUserQuery currentUserQuery,
			IPostLikeResponseFluent responseFluent)
		{
			fluent.SetupProjectToFullResponse(currentUserQuery, responseFluent);
		}

		public void SetupProjectToFullResponse(
			CurrentUserQuery currentUserQuery,
			IPostLikeResponseFluent responseFluent)
		{
			fluent.ProjectToFullResponse(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupProjectToResponseWithoutPost(
			PostLikesFilterQuery filterQuery,
			PostLikesSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IPostLikeResponseFluent responseFluent)
		{
			fluent.SetupProjectToResponseWithoutPost(currentUserQuery, responseFluent);
		}

		public void SetupProjectToResponseWithoutPost(
			CurrentUserQuery currentUserQuery,
			IPostLikeResponseFluent responseFluent)
		{
			fluent.ProjectToResponseWithoutPost(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupProjectToResponseWithoutUser(
			PostLikesForUserFilterQuery filterQuery,
			PostLikesForUserSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IPostLikeResponseFluent responseFluent)
		{
			fluent.SetupProjectToResponseWithoutUser(currentUserQuery, responseFluent);
		}

		public void SetupProjectToResponseWithoutUser(
			CurrentUserQuery currentUserQuery,
			IPostLikeResponseFluent responseFluent)
		{
			fluent.ProjectToResponseWithoutUser(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupFirstOrDefaultAsync(
			PostLikeId id,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			fluent.SetupFirstOrDefaultAsync(postLike, cancellationToken);
		}
	}

	extension(IPostLikeResponseFluent fluent)
	{
		public void SetupApplySorting(
			PostLikesFilterQuery filterQuery,
			PostLikesSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupApplySorting(sortingQuery);
		}

		public void SetupApplySorting(
			PostLikesForUserFilterQuery filterQuery,
			PostLikesForUserSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupApplySorting(sortingQuery);
		}

		public void SetupApplySorting(PostLikesSortingQuery sortingQuery)
		{
			fluent.ApplySorting(sortingQuery).ReturnsResponse(fluent);
		}

		public void SetupApplySorting(PostLikesForUserSortingQuery sortingQuery)
		{
			fluent.ApplySorting(sortingQuery).ReturnsResponse(fluent);
		}

		public void SetupApplyPagination(
			PostLikesFilterQuery filterQuery,
			PostLikesSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupApplyPagination(paginationQuery);
		}

		public void SetupApplyPagination(
			PostLikesForUserFilterQuery filterQuery,
			PostLikesForUserSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupApplyPagination(paginationQuery);
		}

		public void SetupApplyPagination(PostLikesPaginationQuery paginationQuery)
		{
			fluent.ApplyPagination(paginationQuery).ReturnsResponse(fluent);
		}

		public void SetupToListAsync(
			PostLikesFilterQuery filterQuery,
			PostLikesSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			fluent.SetupToListAsync(postLikes.ToResponse(filterQuery, paginationQuery, currentUserQuery), cancellationToken);
		}

		public void SetupToListAsync(
			PostLikesForUserFilterQuery filterQuery,
			PostLikesForUserSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			fluent.SetupToListAsync(postLikes.ToResponse(filterQuery, paginationQuery, currentUserQuery), cancellationToken);
		}

		public void SetupFirstOrDefaultAsync(
			PostLikeId id,
			CurrentUserQuery currentUserQuery,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			fluent.SetupFirstOrDefaultAsync(postLike.ToFullResponse(currentUserQuery), cancellationToken);
		}
	}
}
