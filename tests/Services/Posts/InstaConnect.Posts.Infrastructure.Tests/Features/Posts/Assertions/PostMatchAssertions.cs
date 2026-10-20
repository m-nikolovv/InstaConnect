using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
using InstaConnect.Posts.Infrastructure.Tests.Features.Posts.Assertions;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.Posts.Assertions;

public static class PostMatchAssertions
{
	extension(Post response)
	{
		public void ShouldSatisfy(PostId id, Post post)
		{
			response.ShouldSatisfy(p => p.Matches(id, post));
		}
	}

	extension(PostResponse response)
	{
		public void ShouldSatisfy(PostId id, CurrentUserQuery currentUserQuery, Post post)
		{
			response.ShouldSatisfy(p => p.Matches(id, currentUserQuery, post));
		}
	}

	extension(ICollection<PostResponse> response)
	{
		public void ShouldSatisfy(
			PostsFilterQuery filterQuery,
			PostsSortingQuery sortingQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<Post> posts)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, sortingQuery, paginationQuery, currentUserQuery, posts));
		}

		public void ShouldSatisfy(
			PostsFilterQuery filterQuery,
			PostsSortingQuery sortingQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<Post> posts,
			ISortEnumTermTransformer<Post> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, sortingQuery, paginationQuery, currentUserQuery, posts, termTransformer));
		}

		public void ShouldSatisfy(
			PostsForUserFilterQuery filterQuery,
			PostsForUserSortingQuery sortingQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			User user,
			ICollection<Post> posts)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, sortingQuery, paginationQuery, currentUserQuery, user, posts));
		}

		public void ShouldSatisfy(
			PostsForUserFilterQuery filterQuery,
			PostsForUserSortingQuery sortingQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			User user,
			ICollection<Post> posts,
			ISortEnumTermTransformer<Post> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, sortingQuery, paginationQuery, currentUserQuery, user, posts, termTransformer));
		}
	}

	extension(long response)
	{
		public void ShouldSatisfy(
			PostsFilterQuery filterQuery,
			ICollection<Post> posts)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, posts));
		}

		public void ShouldSatisfy(
			PostsForUserFilterQuery filterQuery,
			ICollection<Post> posts)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, posts));
		}
	}

	extension(bool response)
	{
		public void ShouldSatisfy(PostId id, Post? post)
		{
			response.ShouldSatisfy(p => p.Matches(id, post));
		}
	}
}
