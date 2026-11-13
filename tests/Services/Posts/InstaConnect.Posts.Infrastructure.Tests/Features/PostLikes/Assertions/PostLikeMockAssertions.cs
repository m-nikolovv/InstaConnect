using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Assertions;

public static class PostLikeMockAssertions
{
	extension(IPostLikeCollection collection)
	{
		public void ShouldHaveReceivedOneAggregateFluent(PostLikeId id)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(ICollection<PostLikeId> ids)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(
			PostLikeId id,
			CurrentUserQuery currentUserQuery)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(PostLikesFilterQuery filterQuery)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(PostLikesForUserFilterQuery filterQuery)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(
			PostLikesFilterQuery filterQuery,
			PostLikesSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(
			PostLikesForUserFilterQuery filterQuery,
			PostLikesForUserSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent()
		{
			collection.ShouldHaveReceivedOne().AggregateFluent();
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().AddAsync(postLike, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddRangeAsync(
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().AddRangeAsync(postLikes, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().DeleteAsync(postLike, cancellationToken);
		}
	}

	extension(IPostLikeFluent fluent)
	{
		public void ShouldHaveReceivedOneMatch(PostLikesFilterQuery filterQuery)
		{
			fluent.ShouldHaveReceivedOne().Match(filterQuery);
		}

		public void ShouldHaveReceivedOneMatch(PostLikesForUserFilterQuery filterQuery)
		{
			fluent.ShouldHaveReceivedOne().Match(filterQuery);
		}

		public void ShouldHaveReceivedOneMatch(
			PostLikesFilterQuery filterQuery,
			PostLikesSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneMatch(filterQuery);
		}

		public void ShouldHaveReceivedOneMatch(
			PostLikesForUserFilterQuery filterQuery,
			PostLikesForUserSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneMatch(filterQuery);
		}

		public void ShouldHaveReceivedOneMatch(
			PostLikeId filterQuery)
		{
			fluent.ShouldHaveReceivedOne().Match(filterQuery);
		}

		public void ShouldHaveReceivedOneMatch(
			ICollection<PostLikeId> ids)
		{
			fluent.ShouldHaveReceivedOne().Match(ids);
		}

		public void ShouldHaveReceivedOneMatch(
			PostLikeId filterQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneMatch(filterQuery);
		}

		public void ShouldHaveReceivedOneInclude(
			PostLikeId id,
			PostLikeInclude include)
		{
			fluent.ShouldHaveReceivedOneInclude(include);
		}

		public void ShouldHaveReceivedOneInclude(
			ICollection<PostLikeId> ids,
			PostLikeInclude include)
		{
			fluent.ShouldHaveReceivedOneInclude(include);
		}

		public void ShouldHaveReceivedOneInclude(
			PostLikeId id,
			CurrentUserQuery currentUserQuery,
			PostLikeInclude include)
		{
			fluent.ShouldHaveReceivedOneInclude(include);
		}

		public void ShouldHaveReceivedOneInclude(
			PostLikesFilterQuery filterQuery,
			PostLikeInclude include)
		{
			fluent.ShouldHaveReceivedOneInclude(include);
		}

		public void ShouldHaveReceivedOneInclude(
			PostLikesForUserFilterQuery filterQuery,
			PostLikeInclude include)
		{
			fluent.ShouldHaveReceivedOneInclude(include);
		}

		public void ShouldHaveReceivedOneInclude(
			PostLikesFilterQuery filterQuery,
			PostLikesSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			PostLikeInclude include)
		{
			fluent.ShouldHaveReceivedOneInclude(include);
		}

		public void ShouldHaveReceivedOneInclude(
			PostLikesForUserFilterQuery filterQuery,
			PostLikesForUserSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			PostLikeInclude include)
		{
			fluent.ShouldHaveReceivedOneInclude(include);
		}

		public void ShouldHaveReceivedOneInclude(PostLikeInclude include)
		{
			fluent.ShouldHaveReceivedOne().Include(include);
		}

		public void ShouldHaveReceivedOneProjectToFullResponse(
			PostLikeId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneProjectToFullResponse(currentUserQuery);
		}

		public void ShouldHaveReceivedOneProjectToFullResponse(CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().ProjectToFullResponse(currentUserQuery);
		}

		public void ShouldHaveReceivedOneProjectToResponseWithoutPost(
			PostLikesFilterQuery filterQuery,
			PostLikesSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneProjectToResponseWithoutPost(currentUserQuery);
		}

		public void ShouldHaveReceivedOneProjectToResponseWithoutPost(CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().ProjectToResponseWithoutPost(currentUserQuery);
		}

		public void ShouldHaveReceivedOneProjectToResponseWithoutUser(
			PostLikesForUserFilterQuery filterQuery,
			PostLikesForUserSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneProjectToResponseWithoutUser(currentUserQuery);
		}

		public void ShouldHaveReceivedOneProjectToResponseWithoutUser(CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().ProjectToResponseWithoutUser(currentUserQuery);
		}

		public async Task ShouldHaveReceivedOneAnyAsync(
			PostLikeId id,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneAnyAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetCountAsync(
			PostLikesFilterQuery filterQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneGetCountAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetCountAsync(
			PostLikesForUserFilterQuery filterQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneGetCountAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneFirstOrDefaultAsync(
			PostLikeId id,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneToListAsync(
			ICollection<PostLikeId> ids,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneToListAsync(cancellationToken);
		}
	}

	extension(IPostLikeResponseFluent fluent)
	{
		public void ShouldHaveReceivedOneSort(
			PostLikesFilterQuery filterQuery,
			PostLikesSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneSort(sortingQuery);
		}

		public void ShouldHaveReceivedOneSort(
			PostLikesForUserFilterQuery filterQuery,
			PostLikesForUserSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneSort(sortingQuery);
		}

		public void ShouldHaveReceivedOneSort(PostLikesSortingQuery sortingQuery)
		{
			fluent.ShouldHaveReceivedOne().Sort(sortingQuery);
		}

		public void ShouldHaveReceivedOneSort(PostLikesForUserSortingQuery sortingQuery)
		{
			fluent.ShouldHaveReceivedOne().Sort(sortingQuery);
		}

		public void ShouldHaveReceivedOnePaginate(
			PostLikesFilterQuery filterQuery,
			PostLikesSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOnePaginate(paginationQuery);
		}

		public void ShouldHaveReceivedOnePaginate(
			PostLikesForUserFilterQuery filterQuery,
			PostLikesForUserSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOnePaginate(paginationQuery);
		}

		public void ShouldHaveReceivedOnePaginate(PostLikesPaginationQuery paginationQuery)
		{
			fluent.ShouldHaveReceivedOne().Paginate(paginationQuery);
		}

		public async Task ShouldHaveReceivedOneFirstOrDefaultAsync(
			PostLikeId id,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneToListAsync(
			PostLikesFilterQuery filterQuery,
			PostLikesSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneToListAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneToListAsync(
			PostLikesForUserFilterQuery filterQuery,
			PostLikesForUserSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneToListAsync(cancellationToken);
		}
	}
}
