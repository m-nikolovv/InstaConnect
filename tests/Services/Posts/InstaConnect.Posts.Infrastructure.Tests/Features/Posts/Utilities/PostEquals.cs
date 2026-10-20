using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostImages.Utilities;
using InstaConnect.Posts.Tests.Features.PostImages.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.Posts.Utilities;

public static class PostEquals
{
	extension(Post p)
	{
		public bool Matches(
			PostId id,
			Post post)
		{
			return p.Matches(post);
		}

		public bool MatchesFilter(PostsFilterQuery query)
		{
			return p.User.MatchesFilter(query) &&
				   p.Title.StartsWithOrdinalIgnoreCase(query.Title);
		}

		public bool MatchesFilter(PostsForUserFilterQuery query)
		{
			return p.UserId.Matches(query.UserId) &&
				   p.Title.StartsWithOrdinalIgnoreCase(query.Title);
		}
	}

	extension(User? u)
	{
		public bool MatchesFilter(PostsFilterQuery query)
		{
			return u != null &&
				   u.Name.Value.StartsWithOrdinalIgnoreCase(query.UserName.Value);
		}
	}

	extension(PostResponse? response)
	{
		public bool MatchesFull(
			CurrentUserQuery currentUserQuery,
			Post? post)
		{
			return response != null &&
				   post != null &&
				   post.Id.Matches(response.Id) &&
				   post.UserId.Matches(response.UserId) &&
				   post.Title == response.Title &&
				   post.Content == response.Content &&
				   post.Summary.Matches(response.Summary) &&
				   response.PostImages.MatchesFull(post.PostImages) &&
				   response.IsLikedByCurrentUser == post.PostLikes.Any(pl => pl.Id.UserId.Matches(currentUserQuery.Id)) &&
				   post.CreatedAtUtc == response.CreatedAtUtc &&
				   post.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.User.MatchesFull(post.User);
		}

		public bool MatchesWithoutUser(
			CurrentUserQuery currentUserQuery,
			Post post)
		{
			return response != null &&
				   post != null &&
				   post.Id.Matches(response.Id) &&
				   post.UserId.Matches(response.UserId) &&
				   post.Title == response.Title &&
				   post.Content == response.Content &&
				   post.Summary.Matches(response.Summary) &&
				   response.PostImages.MatchesFull(post.PostImages) &&
				   response.IsLikedByCurrentUser == post.PostLikes.Any(pl => pl.Id.UserId.Matches(currentUserQuery.Id)) &&
				   post.CreatedAtUtc == response.CreatedAtUtc &&
				   post.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.User == null;
		}

		public bool Matches(
			PostId id,
			CurrentUserQuery currentUserQuery,
			Post post)
		{
			return response.MatchesFull(currentUserQuery, post);
		}
	}

	extension(ICollection<PostResponse> response)
	{
		public bool MatchesFull(
		PostsPaginationQuery paginationQuery,
		Func<PostResponse, Post, bool> matches,
		Func<Post, bool> matchesFilter,
		User user,
		ICollection<Post> posts)
		{
			return response.MatchesCollection(paginationQuery,
													posts,
													response => response.Id,
													post => post.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesFull(
			PostsPaginationQuery paginationQuery,
			Func<PostResponse, Post, bool> matches,
			Func<Post, bool> matchesFilter,
			User user,
			ICollection<Post> posts,
			ISortEnumTermTransformer<Post> termTransformer)
		{
			return response.MatchesSortedCollection(paginationQuery,
														  posts,
														  matches,
														  termTransformer,
														  matchesFilter);
		}

		public bool MatchesWithoutUser(
			PostsPaginationQuery paginationQuery,
			Func<PostResponse, Post, bool> matches,
			Func<Post, bool> matchesFilter,
			ICollection<Post> posts)
		{
			return response.MatchesCollection(paginationQuery,
													posts,
													response => response.Id,
													post => post.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesWithoutUser(
			PostsPaginationQuery paginationQuery,
			Func<PostResponse, Post, bool> matches,
			Func<Post, bool> matchesFilter,
			ICollection<Post> posts,
			ISortEnumTermTransformer<Post> termTransformer)
		{
			return response.MatchesSortedCollection(paginationQuery,
														  posts,
														  matches,
														  termTransformer,
														  matchesFilter);
		}

		public bool Matches(
		PostsFilterQuery filterQuery,
		PostsSortingQuery sortingQuery,
		PostsPaginationQuery paginationQuery,
		CurrentUserQuery currentUserQuery,
		ICollection<Post> posts)
		{
			return response.MatchesWithoutUser(
					   paginationQuery,
					   (response, post) => response.MatchesFull(currentUserQuery, post),
					   post => post.MatchesFilter(filterQuery),
					   posts);
		}

		public bool Matches(
			PostsFilterQuery filterQuery,
			PostsSortingQuery sortingQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<Post> posts,
			ISortEnumTermTransformer<Post> termTransformer)
		{
			return response.MatchesWithoutUser(
					   paginationQuery,
					   (response, post) => response.MatchesFull(currentUserQuery, post),
					   post => post.MatchesFilter(filterQuery),
					   posts,
					   termTransformer);
		}

		public bool Matches(
		PostsForUserFilterQuery filterQuery,
		PostsForUserSortingQuery sortingQuery,
		PostsPaginationQuery paginationQuery,
		CurrentUserQuery currentUserQuery,
		User user,
		ICollection<Post> posts)
		{
			return response.MatchesFull(
					   paginationQuery,
					   (response, post) => response.MatchesWithoutUser(currentUserQuery, post),
					   post => post.MatchesFilter(filterQuery),
					   user,
					   posts);
		}

		public bool Matches(
			PostsForUserFilterQuery filterQuery,
			PostsForUserSortingQuery sortingQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			User user,
			ICollection<Post> posts,
			ISortEnumTermTransformer<Post> termTransformer)
		{
			return response.MatchesFull(
					   paginationQuery,
					   (response, post) => response.MatchesWithoutUser(currentUserQuery, post),
					   post => post.MatchesFilter(filterQuery),
					   user,
					   posts,
					   termTransformer);
		}
	}

	extension(long response)
	{
		public bool Matches(
		PostsFilterQuery filterQuery,
		ICollection<Post> posts)
		{
			return response == posts.Count(post => post.MatchesFilter(filterQuery));
		}

		public bool Matches(
			PostsForUserFilterQuery filterQuery,
			ICollection<Post> posts)
		{
			return response == posts.Count(post => post.MatchesFilter(filterQuery));
		}
	}

	extension(bool response)
	{
		public bool Matches(PostId id, Post? post)
		{
			return response == (post != null);
		}
	}
}
