using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.Posts.Utilities;

public static class PostMapper
{
	extension(ICollection<Post> posts)
	{
		public ICollection<PostResponse> ToResponse(
			PostsFilterQuery filterQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			return posts.Filter(paginationQuery, post => post.MatchesFilter(filterQuery), post => post.ToFullResponse(currentUserQuery.Id));
		}

		public ICollection<PostResponse> ToResponse(
			PostsForUserFilterQuery filterQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			return posts.Filter(paginationQuery, post => post.MatchesFilter(filterQuery), post => post.ToResponseWithoutUser(currentUserQuery.Id));
		}

		public long ToTotalCountResponse(
			PostsFilterQuery filterQuery)
		{
			return posts.Count(post => post.MatchesFilter(filterQuery));
		}

		public long ToTotalCountResponse(
			PostsForUserFilterQuery filterQuery)
		{
			return posts.Count(post => post.MatchesFilter(filterQuery));
		}
	}
}
