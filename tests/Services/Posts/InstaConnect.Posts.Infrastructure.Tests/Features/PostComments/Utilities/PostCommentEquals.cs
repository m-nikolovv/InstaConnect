using InstaConnect.Posts.Domain.Features.PostComments.Models.Responses;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentImages.Utilities;
using InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostComments.Utilities;

public static class PostCommentEquals
{
	extension(PostComment p)
	{
		public bool Matches(
			PostCommentId id,
			PostComment postComment)
		{
			return p.Matches(postComment);
		}

		public bool MatchesFilter(PostCommentsFilterQuery query)
		{
			return p.Id.Id.Matches(query.Id) &&
				   p.User.MatchesFilter(query);
		}

		public bool MatchesFilter(PostCommentsForUserFilterQuery query)
		{
			return p.UserId.Matches(query.UserId);
		}
	}

	extension(User? u)
	{
		public bool MatchesFilter(PostCommentsFilterQuery query)
		{
			return u != null &&
				   u.Name.Value.StartsWithOrdinalIgnoreCase(query.UserName.Value);
		}
	}

	extension(PostCommentResponse? response)
	{
		public bool MatchesFull(
			CurrentUserQuery currentUserQuery,
			PostComment? postComment)
		{
			return response != null &&
				   postComment != null &&
				   postComment.Id.Matches(response.Id) &&
				   postComment.UserId.Matches(response.UserId) &&
				   postComment.Content == response.Content &&
				   postComment.Summary.Matches(response.Summary) &&
				   response.PostCommentImages.MatchesFull(postComment.PostCommentImages) &&
				   response.IsLikedByCurrentUser == postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(currentUserQuery.Id)) &&
				   postComment.CreatedAtUtc == response.CreatedAtUtc &&
				   postComment.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.User.MatchesFull(postComment.User) &&
				   response.Post.MatchesFull(currentUserQuery, postComment.Post);
		}

		public bool MatchesWithoutUser(
			CurrentUserQuery currentUserQuery,
			PostComment? postComment)
		{
			return response != null &&
				   postComment != null &&
				   postComment.Id.Matches(response.Id) &&
				   postComment.UserId.Matches(response.UserId) &&
				   postComment.Content == response.Content &&
				   postComment.Summary.Matches(response.Summary) &&
				   response.PostCommentImages.MatchesFull(postComment.PostCommentImages) &&
				   response.IsLikedByCurrentUser == postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(currentUserQuery.Id)) &&
				   postComment.CreatedAtUtc == response.CreatedAtUtc &&
				   postComment.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.User == null &&
				   response.Post.MatchesFull(currentUserQuery, postComment.Post);
		}

		public bool MatchesWithoutPost(
			CurrentUserQuery currentUserQuery,
			PostComment? postComment)
		{
			return response != null &&
				   postComment != null &&
				   postComment.Id.Matches(response.Id) &&
				   postComment.UserId.Matches(response.UserId) &&
				   postComment.Content == response.Content &&
				   postComment.Summary.Matches(response.Summary) &&
				   response.PostCommentImages.MatchesFull(postComment.PostCommentImages) &&
				   response.IsLikedByCurrentUser == postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(currentUserQuery.Id)) &&
				   postComment.CreatedAtUtc == response.CreatedAtUtc &&
				   postComment.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.User.MatchesFull(postComment.User) &&
				   response.Post == null;
		}

		public bool Matches(
			PostCommentId id,
			CurrentUserQuery currentUserQuery,
			PostComment postComment)
		{
			return response.MatchesFull(currentUserQuery, postComment);
		}
	}

	extension(ICollection<PostCommentResponse> response)
	{
		public bool MatchesWithoutUser(
			PostCommentsPaginationQuery paginationQuery,
			Func<PostCommentResponse, PostComment, bool> matches,
			Func<PostComment, bool> matchesFilter,
			Post post,
			ICollection<PostComment> postComments)
		{
			return response.MatchesCollection(paginationQuery,
											  postComments,
											  response => response.Id,
											  postComment => postComment.Id,
											  matches,
											  matchesFilter);
		}

		public bool MatchesWithoutUser(
			PostCommentsPaginationQuery paginationQuery,
			Func<PostCommentResponse, PostComment, bool> matches,
			Func<PostComment, bool> matchesFilter,
			Post post,
			ICollection<PostComment> postComments,
			ISortEnumTermTransformer<PostComment> termTransformer)
		{
			return response.MatchesSortedCollection(paginationQuery,
													postComments,
													matches,
													termTransformer,
													matchesFilter);
		}

		public bool MatchesWithoutPost(
			PostCommentsPaginationQuery paginationQuery,
			Func<PostCommentResponse, PostComment, bool> matches,
			Func<PostComment, bool> matchesFilter,
			User user,
			ICollection<PostComment> postComments)
		{
			return response.MatchesCollection(paginationQuery,
											  postComments,
											  response => response.Id,
											  postComment => postComment.Id,
											  matches,
											  matchesFilter);
		}

		public bool MatchesWithoutPost(
			PostCommentsPaginationQuery paginationQuery,
			Func<PostCommentResponse, PostComment, bool> matches,
			Func<PostComment, bool> matchesFilter,
			User user,
			ICollection<PostComment> postComments,
			ISortEnumTermTransformer<PostComment> termTransformer)
		{
			return response.MatchesSortedCollection(paginationQuery,
													postComments,
													matches,
													termTransformer,
													matchesFilter);
		}

		public bool Matches(
			PostCommentsFilterQuery filterQuery,
			PostCommentsSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			Post post,
			ICollection<PostComment> postComments)
		{
			return response.MatchesWithoutUser(
					   paginationQuery,
					   (response, postComment) => response.MatchesWithoutPost(currentUserQuery, postComment),
					   postComment => postComment.MatchesFilter(filterQuery),
					   post,
					   postComments);
		}

		public bool Matches(
			PostCommentsFilterQuery filterQuery,
			PostCommentsSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			Post post,
			ICollection<PostComment> postComments,
			ISortEnumTermTransformer<PostComment> termTransformer)
		{
			return response.MatchesWithoutUser(
					   paginationQuery,
					   (response, postComment) => response.MatchesWithoutPost(currentUserQuery, postComment),
					   postComment => postComment.MatchesFilter(filterQuery),
					   post,
					   postComments,
					   termTransformer);
		}

		public bool Matches(
			PostCommentsForUserFilterQuery filterQuery,
			PostCommentsForUserSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			User user,
			ICollection<PostComment> postComments)
		{
			return response.MatchesWithoutPost(
					   paginationQuery,
					   (response, postComment) => response.MatchesWithoutUser(currentUserQuery, postComment),
					   postComment => postComment.MatchesFilter(filterQuery),
					   user,
					   postComments);
		}

		public bool Matches(
			PostCommentsForUserFilterQuery filterQuery,
			PostCommentsForUserSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			User user,
			ICollection<PostComment> postComments,
			ISortEnumTermTransformer<PostComment> termTransformer)
		{
			return response.MatchesWithoutPost(
					   paginationQuery,
					   (response, postComment) => response.MatchesWithoutUser(currentUserQuery, postComment),
					   postComment => postComment.MatchesFilter(filterQuery),
					   user,
					   postComments,
					   termTransformer);
		}
	}

	extension(long response)
	{
		public bool Matches(
			PostCommentsFilterQuery filterQuery,
			ICollection<PostComment> postComments)
		{
			return response == postComments.Count(postComment => postComment.MatchesFilter(filterQuery));
		}

		public bool Matches(
			PostCommentsForUserFilterQuery filterQuery,
			ICollection<PostComment> postComments)
		{
			return response == postComments.Count(postComment => postComment.MatchesFilter(filterQuery));
		}
	}

	extension(bool response)
	{
		public bool Matches(PostCommentId id, PostComment? postComment)
		{
			return response == (postComment != null);
		}
	}
}
