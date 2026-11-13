using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.Posts.Utilities;

public static class PostMockSetups
{
	extension(IPostCollection collection)
	{
		public void SetupAggregateFluent(
			PostId id,
			IPostFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			ICollection<PostId> ids,
			IPostFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			PostId id,
			CurrentUserQuery currentUserQuery,
			IPostFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			PostsFilterQuery filterQuery,
			PostsSortingQuery sortingQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IPostFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			PostsFilterQuery filterQuery,
			IPostFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			PostsForUserFilterQuery filterQuery,
			PostsForUserSortingQuery sortingQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IPostFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			PostsForUserFilterQuery filterQuery,
			IPostFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(IPostFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}
	}

	extension(IPostFluent fluent)
	{
		public void SetupGetCountAsync(
			PostsFilterQuery filterQuery,
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			fluent.SetupGetCountAsync(posts.ToTotalCountResponse(filterQuery), cancellationToken);
		}

		public void SetupGetCountAsync(
			PostsForUserFilterQuery filterQuery,
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			fluent.SetupGetCountAsync(posts.ToTotalCountResponse(filterQuery), cancellationToken);
		}

		public void SetupAnyAsync(
			PostId id,
			Post? post,
			CancellationToken cancellationToken)
		{
			fluent.SetupAnyAsync(post != null, cancellationToken);
		}

		public void SetupInclude(
			PostId id,
			PostInclude include)
		{
			fluent.SetupInclude(include);
		}

		public void SetupInclude(
			ICollection<PostId> ids,
			PostInclude include)
		{
			fluent.SetupInclude(include);
		}

		public void SetupInclude(
			PostId id,
			CurrentUserQuery currentUserQuery,
			PostInclude include)
		{
			fluent.SetupInclude(include);
		}

		public void SetupInclude(
			PostsFilterQuery filterQuery,
			PostInclude include)
		{
			fluent.SetupInclude(include);
		}

		public void SetupInclude(
			PostsForUserFilterQuery filterQuery,
			PostInclude include)
		{
			fluent.SetupInclude(include);
		}

		public void SetupInclude(
			PostsFilterQuery filterQuery,
			PostsSortingQuery sortingQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			PostInclude include)
		{
			fluent.SetupInclude(include);
		}

		public void SetupInclude(
			PostsForUserFilterQuery filterQuery,
			PostsForUserSortingQuery sortingQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			PostInclude include)
		{
			fluent.SetupInclude(include);
		}

		public void SetupInclude(PostInclude include)
		{
			fluent.Include(include).ReturnsResponse(fluent);
		}

		public void SetupMatch(PostId id)
		{
			fluent.Match(id).ReturnsResponse(fluent);
		}

		public void SetupMatch(ICollection<PostId> ids)
		{
			fluent.Match(ids).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			PostId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupMatch(id);
		}

		public void SetupMatch(PostsFilterQuery filterQuery)
		{
			fluent.Match(filterQuery).ReturnsResponse(fluent);
		}

		public void SetupMatch(PostsForUserFilterQuery filterQuery)
		{
			fluent.Match(filterQuery).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			PostsFilterQuery filterQuery,
			PostsSortingQuery sortingQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupMatch(filterQuery);
		}

		public void SetupMatch(
			PostsForUserFilterQuery filterQuery,
			PostsForUserSortingQuery sortingQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupMatch(filterQuery);
		}

		public void SetupProjectToFullResponse(
			PostId id,
			CurrentUserQuery currentUserQuery,
			IPostResponseFluent responseFluent)
		{
			fluent.SetupProjectToFullResponse(currentUserQuery, responseFluent);
		}

		public void SetupProjectToFullResponse(
			PostsFilterQuery filterQuery,
			PostsSortingQuery sortingQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IPostResponseFluent responseFluent)
		{
			fluent.SetupProjectToFullResponse(currentUserQuery, responseFluent);
		}

		public void SetupProjectToFullResponse(
			CurrentUserQuery currentUserQuery,
			IPostResponseFluent responseFluent)
		{
			fluent.ProjectToFullResponse(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupProjectToResponseWithoutUser(
			PostsForUserFilterQuery filterQuery,
			PostsForUserSortingQuery sortingQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IPostResponseFluent responseFluent)
		{
			fluent.SetupProjectToResponseWithoutUser(currentUserQuery, responseFluent);
		}

		public void SetupProjectToResponseWithoutUser(
			CurrentUserQuery currentUserQuery,
			IPostResponseFluent responseFluent)
		{
			fluent.ProjectToResponseWithoutUser(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupFirstOrDefaultAsync(
			PostId id,
			Post post,
			CancellationToken cancellationToken)
		{
			fluent.SetupFirstOrDefaultAsync(post, cancellationToken);
		}

		public void SetupFirstOrDefaultAsync(
			PostId id,
			CurrentUserQuery currentUserQuery,
			Post post,
			CancellationToken cancellationToken)
		{
			fluent.SetupFirstOrDefaultAsync(post, cancellationToken);
		}

		public void SetupToListAsync(
			ICollection<PostId> ids,
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			fluent.SetupToListAsync(posts, cancellationToken);
		}
	}

	extension(IPostResponseFluent fluent)
	{
		public void SetupSort(
			PostsFilterQuery filterQuery,
			PostsSortingQuery sortingQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupSort(sortingQuery);
		}

		public void SetupSort(
			PostsForUserFilterQuery filterQuery,
			PostsForUserSortingQuery sortingQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupSort(sortingQuery);
		}

		public void SetupSort(PostsSortingQuery sortingQuery)
		{
			fluent.Sort(sortingQuery).ReturnsResponse(fluent);
		}

		public void SetupSort(PostsForUserSortingQuery sortingQuery)
		{
			fluent.Sort(sortingQuery).ReturnsResponse(fluent);
		}

		public void SetupPaginate(
			PostsFilterQuery filterQuery,
			PostsSortingQuery sortingQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupPaginate(paginationQuery);
		}

		public void SetupPaginate(
			PostsForUserFilterQuery filterQuery,
			PostsForUserSortingQuery sortingQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupPaginate(paginationQuery);
		}

		public void SetupPaginate(PostsPaginationQuery paginationQuery)
		{
			fluent.Paginate(paginationQuery).ReturnsResponse(fluent);
		}

		public void SetupToListAsync(
			PostsFilterQuery filterQuery,
			PostsSortingQuery sortingQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			fluent.SetupToListAsync(posts.ToResponse(filterQuery, paginationQuery, currentUserQuery), cancellationToken);
		}

		public void SetupToListAsync(
			PostsForUserFilterQuery filterQuery,
			PostsForUserSortingQuery sortingQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			fluent.SetupToListAsync(posts.ToResponse(filterQuery, paginationQuery, currentUserQuery), cancellationToken);
		}

		public void SetupFirstOrDefaultAsync(
			PostId id,
			CurrentUserQuery currentUserQuery,
			Post post,
			CancellationToken cancellationToken)
		{
			fluent.SetupFirstOrDefaultAsync(post.ToFullResponse(currentUserQuery), cancellationToken);
		}
	}
}
