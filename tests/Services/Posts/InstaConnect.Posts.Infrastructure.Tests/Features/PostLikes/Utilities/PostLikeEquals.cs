using InstaConnect.Posts.Domain.Features.PostLikes.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;
using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Utilities;

public static class PostLikeEquals
{
	extension(PostLike p)
	{
		public bool Matches(
			PostLikeId id,
			PostLike postLike)
		{
			return p.Matches(postLike);
		}

		public bool MatchesFilter(PostLikesFilterQuery query)
		{
			return p.Id.Id.Matches(query.Id) &&
				   p.User.MatchesFilter(query);
		}

		public bool MatchesFilter(PostLikesForUserFilterQuery query)
		{
			return p.Id.UserId.Matches(query.UserId);
		}
	}

	extension(User? u)
	{
		public bool MatchesFilter(PostLikesFilterQuery query)
		{
			return u != null &&
				   u.Name.Value.StartsWithOrdinalIgnoreCase(query.UserName.Value);
		}
	}

	extension(PostLikeResponse? response)
	{
		public bool MatchesFull(
			CurrentUserQuery currentUserQuery,
			PostLike? postLike)
		{
			return response != null &&
				   postLike != null &&
				   postLike.Id.Matches(response.Id) &&
				   postLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User.MatchesFull(postLike.User) &&
				   response.Post.MatchesFull(currentUserQuery, postLike.Post);
		}

		public bool MatchesWithoutUser(
			CurrentUserQuery currentUserQuery,
			PostLike? postLike)
		{
			return response != null &&
				   postLike != null &&
				   postLike.Id.Matches(response.Id) &&
				   postLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User == null &&
				   response.Post.MatchesFull(currentUserQuery, postLike.Post);
		}

		public bool MatchesWithoutPost(PostLike? postLike)
		{
			return response != null &&
				   postLike != null &&
				   postLike.Id.Matches(response.Id) &&
				   postLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User.MatchesFull(postLike.User) &&
				   response.Post == null;
		}

		public bool Matches(
			PostLikeId id,
			CurrentUserQuery currentUserQuery,
			PostLike postLike)
		{
			return response.MatchesFull(currentUserQuery, postLike);
		}
	}

	extension(ICollection<PostLikeResponse> response)
	{
		public bool MatchesWithoutUser(
			PostLikesPaginationQuery paginationQuery,
			Func<PostLikeResponse, PostLike, bool> matches,
			Func<PostLike, bool> matchesFilter,
			Post post,
			ICollection<PostLike> postLikes)
		{
			return response.MatchesCollection(paginationQuery,
											  postLikes,
											  response => response.Id,
											  postLike => postLike.Id,
											  matches,
											  matchesFilter);
		}

		public bool MatchesWithoutUser(
			PostLikesPaginationQuery paginationQuery,
			Func<PostLikeResponse, PostLike, bool> matches,
			Func<PostLike, bool> matchesFilter,
			Post post,
			ICollection<PostLike> postLikes,
			ISortEnumTermTransformer<PostLike> termTransformer)
		{
			return response.MatchesSortedCollection(paginationQuery,
													postLikes,
													matches,
													termTransformer,
													matchesFilter);
		}

		public bool MatchesWithoutPost(
			PostLikesPaginationQuery paginationQuery,
			Func<PostLikeResponse, PostLike, bool> matches,
			Func<PostLike, bool> matchesFilter,
			User user,
			ICollection<PostLike> postLikes)
		{
			return response.MatchesCollection(paginationQuery,
											  postLikes,
											  response => response.Id,
											  postLike => postLike.Id,
											  matches,
											  matchesFilter);
		}

		public bool MatchesWithoutPost(
			PostLikesPaginationQuery paginationQuery,
			Func<PostLikeResponse, PostLike, bool> matches,
			Func<PostLike, bool> matchesFilter,
			User user,
			ICollection<PostLike> postLikes,
			ISortEnumTermTransformer<PostLike> termTransformer)
		{
			return response.MatchesSortedCollection(paginationQuery,
													postLikes,
													matches,
													termTransformer,
													matchesFilter);
		}

		public bool Matches(
			PostLikesFilterQuery filterQuery,
			PostLikesSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			Post post,
			ICollection<PostLike> postLikes)
		{
			return response.MatchesWithoutUser(
					   paginationQuery,
					   (response, postLike) => response.MatchesWithoutPost(postLike),
					   postLike => postLike.MatchesFilter(filterQuery),
					   post,
					   postLikes);
		}

		public bool Matches(
			PostLikesFilterQuery filterQuery,
			PostLikesSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			Post post,
			ICollection<PostLike> postLikes,
			ISortEnumTermTransformer<PostLike> termTransformer)
		{
			return response.MatchesWithoutUser(
					   paginationQuery,
					   (response, postLike) => response.MatchesWithoutPost(postLike),
					   postLike => postLike.MatchesFilter(filterQuery),
					   post,
					   postLikes,
					   termTransformer);
		}

		public bool Matches(
			PostLikesForUserFilterQuery filterQuery,
			PostLikesForUserSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			User user,
			ICollection<PostLike> postLikes)
		{
			return response.MatchesWithoutPost(
					   paginationQuery,
					   (response, postLike) => response.MatchesWithoutUser(currentUserQuery, postLike),
					   postLike => postLike.MatchesFilter(filterQuery),
					   user,
					   postLikes);
		}

		public bool Matches(
			PostLikesForUserFilterQuery filterQuery,
			PostLikesForUserSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			User user,
			ICollection<PostLike> postLikes,
			ISortEnumTermTransformer<PostLike> termTransformer)
		{
			return response.MatchesWithoutPost(
					   paginationQuery,
					   (response, postLike) => response.MatchesWithoutUser(currentUserQuery, postLike),
					   postLike => postLike.MatchesFilter(filterQuery),
					   user,
					   postLikes,
					   termTransformer);
		}
	}

	extension(long response)
	{
		public bool Matches(
			PostLikesFilterQuery filterQuery,
			ICollection<PostLike> postLikes)
		{
			return response == postLikes.Count(postLike => postLike.MatchesFilter(filterQuery));
		}

		public bool Matches(
			PostLikesForUserFilterQuery filterQuery,
			ICollection<PostLike> postLikes)
		{
			return response == postLikes.Count(postLike => postLike.MatchesFilter(filterQuery));
		}
	}

	extension(bool response)
	{
		public bool Matches(PostLikeId id, PostLike? postLike)
		{
			return response == (postLike != null);
		}
	}
}
