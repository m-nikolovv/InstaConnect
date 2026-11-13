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
			ICollection<PostLikeId> ids,
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

		public void SetupInclude(
			PostLikeId id,
			PostLikeInclude include)
		{
			fluent.SetupInclude(include);
		}

		public void SetupInclude(
			ICollection<PostLikeId> ids,
			PostLikeInclude include)
		{
			fluent.SetupInclude(include);
		}

		public void SetupInclude(
			PostLikeId id,
			CurrentUserQuery currentUserQuery,
			PostLikeInclude include)
		{
			fluent.SetupInclude(include);
		}

		public void SetupInclude(
			PostLikesFilterQuery filterQuery,
			PostLikeInclude include)
		{
			fluent.SetupInclude(include);
		}

		public void SetupInclude(
			PostLikesForUserFilterQuery filterQuery,
			PostLikeInclude include)
		{
			fluent.SetupInclude(include);
		}

		public void SetupInclude(
			PostLikesFilterQuery filterQuery,
			PostLikesSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			PostLikeInclude include)
		{
			fluent.SetupInclude(include);
		}

		public void SetupInclude(
			PostLikesForUserFilterQuery filterQuery,
			PostLikesForUserSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			PostLikeInclude include)
		{
			fluent.SetupInclude(include);
		}

		public void SetupInclude(PostLikeInclude include)
		{
			fluent.Include(include).ReturnsResponse(fluent);
		}

		public void SetupMatch(PostLikeId id)
		{
			fluent.Match(id).ReturnsResponse(fluent);
		}

		public void SetupMatch(ICollection<PostLikeId> ids)
		{
			fluent.Match(ids).ReturnsResponse(fluent);
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

		public void SetupToListAsync(
			ICollection<PostLikeId> ids,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			fluent.SetupToListAsync(postLikes, cancellationToken);
		}
	}

	extension(IPostLikeResponseFluent fluent)
	{
		public void SetupSort(
			PostLikesFilterQuery filterQuery,
			PostLikesSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupSort(sortingQuery);
		}

		public void SetupSort(
			PostLikesForUserFilterQuery filterQuery,
			PostLikesForUserSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupSort(sortingQuery);
		}

		public void SetupSort(PostLikesSortingQuery sortingQuery)
		{
			fluent.Sort(sortingQuery).ReturnsResponse(fluent);
		}

		public void SetupSort(PostLikesForUserSortingQuery sortingQuery)
		{
			fluent.Sort(sortingQuery).ReturnsResponse(fluent);
		}

		public void SetupPaginate(
			PostLikesFilterQuery filterQuery,
			PostLikesSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupPaginate(paginationQuery);
		}

		public void SetupPaginate(
			PostLikesForUserFilterQuery filterQuery,
			PostLikesForUserSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupPaginate(paginationQuery);
		}

		public void SetupPaginate(PostLikesPaginationQuery paginationQuery)
		{
			fluent.Paginate(paginationQuery).ReturnsResponse(fluent);
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
