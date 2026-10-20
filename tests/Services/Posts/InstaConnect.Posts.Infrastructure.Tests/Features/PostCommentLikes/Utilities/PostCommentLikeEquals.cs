using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeEquals
{
	extension(PostCommentLike p)
	{
		public bool Matches(
			PostCommentLikeId id,
			PostCommentLike postCommentLike)
		{
			return p.Matches(postCommentLike);
		}

		public bool MatchesFilter(PostCommentLikesFilterQuery query)
		{
			return p.Id.CommentId.Matches(query.CommentId) &&
				   p.User.MatchesFilter(query);
		}

		public bool MatchesFilter(PostCommentLikesForUserFilterQuery query)
		{
			return p.Id.UserId.Matches(query.UserId);
		}
	}

	extension(User? u)
	{
		public bool MatchesFilter(PostCommentLikesFilterQuery query)
		{
			return u != null &&
				   u.Name.Value.StartsWithOrdinalIgnoreCase(query.UserName.Value);
		}
	}

	extension(PostCommentLikeResponse? response)
	{
		public bool MatchesFull(
			CurrentUserQuery currentUserQuery,
			PostCommentLike? postCommentLike)
		{
			return response != null &&
				   postCommentLike != null &&
				   postCommentLike.Id.Matches(response.Id) &&
				   postCommentLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User.MatchesFull(postCommentLike.User) &&
				   response.PostComment.MatchesFull(currentUserQuery, postCommentLike.PostComment);
		}

		public bool MatchesWithoutUser(
			CurrentUserQuery currentUserQuery,
			PostCommentLike? postCommentLike)
		{
			return response != null &&
				   postCommentLike != null &&
				   postCommentLike.Id.Matches(response.Id) &&
				   postCommentLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User == null &&
				   response.PostComment.MatchesFull(currentUserQuery, postCommentLike.PostComment);
		}

		public bool MatchesWithoutPostComment(
			CurrentUserQuery currentUserQuery,
			PostCommentLike? postCommentLike)
		{
			return response != null &&
				   postCommentLike != null &&
				   postCommentLike.Id.Matches(response.Id) &&
				   postCommentLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User.MatchesFull(postCommentLike.User) &&
				   response.PostComment == null;
		}

		public bool Matches(
			PostCommentLikeId id,
			CurrentUserQuery currentUserQuery,
			PostCommentLike postCommentLike)
		{
			return response.MatchesFull(currentUserQuery, postCommentLike);
		}
	}

	extension(ICollection<PostCommentLikeResponse> response)
	{
		public bool MatchesWithoutUser(
			PostCommentLikesPaginationQuery paginationQuery,
			Func<PostCommentLikeResponse, PostCommentLike, bool> matches,
			Func<PostCommentLike, bool> matchesFilter,
			PostComment postComment,
			ICollection<PostCommentLike> postCommentLikes)
		{
			return response.MatchesCollection(paginationQuery,
											  postCommentLikes,
											  response => response.Id,
											  postCommentLike => postCommentLike.Id,
											  matches,
											  matchesFilter);
		}

		public bool MatchesWithoutUser(
			PostCommentLikesPaginationQuery paginationQuery,
			Func<PostCommentLikeResponse, PostCommentLike, bool> matches,
			Func<PostCommentLike, bool> matchesFilter,
			PostComment postComment,
			ICollection<PostCommentLike> postCommentLikes,
			ISortEnumTermTransformer<PostCommentLike> termTransformer)
		{
			return response.MatchesSortedCollection(paginationQuery,
													postCommentLikes,
													matches,
													termTransformer,
													matchesFilter);
		}

		public bool MatchesWithoutPostComment(
			PostCommentLikesPaginationQuery paginationQuery,
			Func<PostCommentLikeResponse, PostCommentLike, bool> matches,
			Func<PostCommentLike, bool> matchesFilter,
			User user,
			ICollection<PostCommentLike> postCommentLikes)
		{
			return response.MatchesCollection(paginationQuery,
											  postCommentLikes,
											  response => response.Id,
											  postCommentLike => postCommentLike.Id,
											  matches,
											  matchesFilter);
		}

		public bool MatchesWithoutPostComment(
			PostCommentLikesPaginationQuery paginationQuery,
			Func<PostCommentLikeResponse, PostCommentLike, bool> matches,
			Func<PostCommentLike, bool> matchesFilter,
			User user,
			ICollection<PostCommentLike> postCommentLikes,
			ISortEnumTermTransformer<PostCommentLike> termTransformer)
		{
			return response.MatchesSortedCollection(paginationQuery,
													postCommentLikes,
													matches,
													termTransformer,
													matchesFilter);
		}

		public bool Matches(
			PostCommentLikesFilterQuery filterQuery,
			PostCommentLikesSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			PostComment postComment,
			ICollection<PostCommentLike> postCommentLikes)
		{
			return response.MatchesWithoutUser(
					   paginationQuery,
					   (response, postCommentLike) => response.MatchesWithoutPostComment(currentUserQuery, postCommentLike),
					   postCommentLike => postCommentLike.MatchesFilter(filterQuery),
					   postComment,
					   postCommentLikes);
		}

		public bool Matches(
			PostCommentLikesFilterQuery filterQuery,
			PostCommentLikesSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			PostComment postComment,
			ICollection<PostCommentLike> postCommentLikes,
			ISortEnumTermTransformer<PostCommentLike> termTransformer)
		{
			return response.MatchesWithoutUser(
					   paginationQuery,
					   (response, postCommentLike) => response.MatchesWithoutPostComment(currentUserQuery, postCommentLike),
					   postCommentLike => postCommentLike.MatchesFilter(filterQuery),
					   postComment,
					   postCommentLikes,
					   termTransformer);
		}

		public bool Matches(
			PostCommentLikesForUserFilterQuery filterQuery,
			PostCommentLikesForUserSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			User user,
			ICollection<PostCommentLike> postCommentLikes)
		{
			return response.MatchesWithoutPostComment(
					   paginationQuery,
					   (response, postCommentLike) => response.MatchesWithoutUser(currentUserQuery, postCommentLike),
					   postCommentLike => postCommentLike.MatchesFilter(filterQuery),
					   user,
					   postCommentLikes);
		}

		public bool Matches(
			PostCommentLikesForUserFilterQuery filterQuery,
			PostCommentLikesForUserSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			User user,
			ICollection<PostCommentLike> postCommentLikes,
			ISortEnumTermTransformer<PostCommentLike> termTransformer)
		{
			return response.MatchesWithoutPostComment(
					   paginationQuery,
					   (response, postCommentLike) => response.MatchesWithoutUser(currentUserQuery, postCommentLike),
					   postCommentLike => postCommentLike.MatchesFilter(filterQuery),
					   user,
					   postCommentLikes,
					   termTransformer);
		}
	}

	extension(long response)
	{
		public bool Matches(
			PostCommentLikesFilterQuery filterQuery,
			ICollection<PostCommentLike> postCommentLikes)
		{
			return response == postCommentLikes.Count(postCommentLike => postCommentLike.MatchesFilter(filterQuery));
		}

		public bool Matches(
			PostCommentLikesForUserFilterQuery filterQuery,
			ICollection<PostCommentLike> postCommentLikes)
		{
			return response == postCommentLikes.Count(postCommentLike => postCommentLike.MatchesFilter(filterQuery));
		}
	}

	extension(bool response)
	{
		public bool Matches(PostCommentLikeId id, PostCommentLike? postCommentLike)
		{
			return response == (postCommentLike != null);
		}
	}
}
