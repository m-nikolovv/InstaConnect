using InstaConnect.Common.Domain.Features.Requests.Abstractions;
using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Responses;
using InstaConnect.Posts.Events.Features.PostCommentLikes;
using InstaConnect.Posts.Events.Features.PostComments;

namespace InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeEquals
{
	extension(PostCommentLikeId response)
	{
		public bool Matches(
		AddPostCommentLikeCommand command,
		PostCommentLike postCommentLike)
		{
			return response.Matches(postCommentLike.Id);
		}
	}

	extension(PostCommentLikeAddedEventRequest request)
	{
		public bool Matches(AddPostCommentLikeCommand command, PostCommentLike entity)
		{
			return request.PostCommentLike.Matches(command, entity);
		}
	}

	extension(PostCommentLikeDeletedEventRequest request)
	{
		public bool Matches(DeletePostCommentLikeCommand command, PostCommentLike entity)
		{
			return request.PostCommentLike.Matches(command, entity);
		}
	}

	extension(PostCommentLikeEventRequest request)
	{
		public bool Matches(AddPostCommentLikeCommand command, PostCommentLike? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.CommentId.Id.Id) &&
				   request.CommentId.EqualsOrdinalIgnoreCase(command.CommentId.CommentId) &&
				   request.UserId.EqualsOrdinalIgnoreCase(command.UserId.Id) &&
				   request.User.Matches(command, entity.User) &&
				   request.PostComment.Matches(command, entity.PostComment) &&
				   request.CreatedAtUtc == entity.CreatedAtUtc;
		}
		public bool Matches(DeletePostCommentLikeCommand command, PostCommentLike? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.CommentId.Id.Id) &&
				   request.CommentId.EqualsOrdinalIgnoreCase(command.Id.CommentId.CommentId) &&
				   request.UserId.EqualsOrdinalIgnoreCase(command.Id.UserId.Id) &&
				   request.User.Matches(command, entity.User) &&
				   request.PostComment.Matches(command, entity.PostComment) &&
				   request.CreatedAtUtc == entity.CreatedAtUtc;
		}
	}

	extension(PostCommentEventRequest request)
	{
		public bool Matches(AddPostCommentLikeCommand command, PostComment? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.CommentId.Id.Id) &&
				   request.CommentId.EqualsOrdinalIgnoreCase(command.CommentId.CommentId) &&
				   request.UserId.EqualsOrdinalIgnoreCase(command.UserId.Id) &&
				   request.Content == entity.Content &&
				   entity.Summary.Matches(request.Summary) &&
				   request.User.Matches(command, entity.User) &&
				   request.Post.Matches(command, entity.Post) &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
		public bool Matches(DeletePostCommentLikeCommand command, PostComment? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.CommentId.Id.Id) &&
				   request.CommentId.EqualsOrdinalIgnoreCase(command.Id.CommentId.CommentId) &&
				   request.UserId.EqualsOrdinalIgnoreCase(command.Id.UserId.Id) &&
				   request.Content == entity.Content &&
				   entity.Summary.Matches(request.Summary) &&
				   request.User.Matches(command, entity.User) &&
				   request.Post.Matches(command, entity.Post) &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
	}

	extension(PostEventRequest request)
	{
		public bool Matches(AddPostCommentLikeCommand command, Post? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.CommentId.Id.Id) &&
				   request.UserId.EqualsOrdinalIgnoreCase(command.UserId.Id) &&
				   request.User.Matches(command, entity.User) &&
				   request.Title == entity.Title &&
				   request.Content == entity.Content &&
				   entity.Summary.Matches(request.Summary) &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
		public bool Matches(DeletePostCommentLikeCommand command, Post? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.CommentId.Id.Id) &&
				   request.UserId.EqualsOrdinalIgnoreCase(command.Id.UserId.Id) &&
				   request.User.Matches(command, entity.User) &&
				   request.Title == entity.Title &&
				   request.Content == entity.Content &&
				   entity.Summary.Matches(request.Summary) &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
	}

	extension(UserEventRequest request)
	{
		public bool Matches(AddPostCommentLikeCommand command, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.UserId.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   request.FirstName == entity.FirstName &&
				   request.LastName == entity.LastName &&
				   request.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
		public bool Matches(DeletePostCommentLikeCommand command, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.UserId.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   request.FirstName == entity.FirstName &&
				   request.LastName == entity.LastName &&
				   request.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
	}

	extension(PostCommentLike postCommentLike)
	{
		public bool Matches(AddPostCommentLikeCommand command)
		{
			return postCommentLike.Id.Matches(command.CommentId, command.UserId) &&
				   postCommentLike.CreatedAtUtc != default;
		}

		public bool Matches(DeletePostCommentLikeCommand command)
		{
			return postCommentLike.Id.Matches(command.Id) &&
				   postCommentLike.CreatedAtUtc != default;
		}

		public bool MatchesFilter(PostCommentLikesFilterQuery query)
		{
			return postCommentLike.Id.CommentId.Matches(query.CommentId) &&
				   postCommentLike.User.MatchesFilter(query);
		}

		public bool MatchesFilter(PostCommentLikesForUserFilterQuery query)
		{
			return postCommentLike.Id.UserId.Matches(query.UserId);
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
		public bool MatchesFull<TQuery>(TQuery request, PostCommentLike? postCommentLike)
		where TQuery : ICurrentUserableQuery
		{
			return response != null &&
				   postCommentLike != null &&
				   postCommentLike.Id.Matches(response.Id) &&
				   postCommentLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User.MatchesFull(postCommentLike.User) &&
				   response.PostComment.MatchesFull(request, postCommentLike.PostComment);
		}

		public bool MatchesWithoutUser<TQuery>(TQuery request, PostCommentLike? postCommentLike)
			where TQuery : ICurrentUserableQuery
		{
			return response != null &&
				   postCommentLike != null &&
				   postCommentLike.Id.Matches(response.Id) &&
				   postCommentLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User == null &&
				   response.PostComment.MatchesFull(request, postCommentLike.PostComment);
		}

		public bool MatchesWithoutPostComment<TQuery>(TQuery request, PostCommentLike? postCommentLike)
			where TQuery : ICurrentUserableQuery
		{
			return response != null &&
				   postCommentLike != null &&
				   postCommentLike.Id.Matches(response.Id) &&
				   postCommentLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User.MatchesFull(postCommentLike.User) &&
				   response.PostComment == null;
		}

		public bool Matches(GetPostCommentLikeByIdQuery query, PostCommentLike postCommentLike)
		{
			return response.MatchesFull(query, postCommentLike);
		}
	}

	extension(PostCommentLikeCollectionResponse response)
	{
		public bool MatchesWithoutUser<TQuery>(
		TQuery request,
		Func<PostCommentLikeResponse, PostCommentLike, bool> matches,
		Func<PostCommentLike, bool> matchesFilter,
		PostComment postComment,
		ICollection<PostCommentLike> postCommentLikes)
		where TQuery : ICurrentUserableQuery, IPaginatableQuery<PostCommentLikesPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, postCommentLikes.Count(matchesFilter)) &&
				   response.User == null &&
				   response.PostComment.MatchesFull(request, postComment) &&
				   response.PostCommentLikes.MatchesCollectionAndNotEmpty(request.Pagination,
													postCommentLikes,
													response => response.Id,
													postCommentLike => postCommentLike.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesWithoutUser<TQuery>(
			TQuery request,
			Func<PostCommentLikeResponse, PostCommentLike, bool> matches,
			Func<PostCommentLike, bool> matchesFilter,
			PostComment postComment,
			ICollection<PostCommentLike> postCommentLikes,
			ISortEnumTermTransformer<PostCommentLike> termTransformer)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<PostCommentLikesPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, postCommentLikes.Count(matchesFilter)) &&
				   response.User == null &&
				   response.PostComment.MatchesFull(request, postComment) &&
				   response.PostCommentLikes.MatchesSortedCollection(request.Pagination,
														  postCommentLikes,
														  matches,
														  termTransformer,
														  matchesFilter);
		}

		public bool MatchesWithoutPostComment<TQuery>(
			TQuery request,
			Func<PostCommentLikeResponse, PostCommentLike, bool> matches,
			Func<PostCommentLike, bool> matchesFilter,
			User user,
			ICollection<PostCommentLike> postCommentLikes)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<PostCommentLikesPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, postCommentLikes.Count(matchesFilter)) &&
				   response.User.MatchesFull(user) &&
				   response.PostComment == null &&
				   response.PostCommentLikes.MatchesCollectionAndNotEmpty(request.Pagination,
													postCommentLikes,
													response => response.Id,
													postCommentLike => postCommentLike.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesWithoutPostComment<TQuery>(
			TQuery request,
			Func<PostCommentLikeResponse, PostCommentLike, bool> matches,
			Func<PostCommentLike, bool> matchesFilter,
			User user,
			ICollection<PostCommentLike> postCommentLikes,
			ISortEnumTermTransformer<PostCommentLike> termTransformer)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<PostCommentLikesPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, postCommentLikes.Count(matchesFilter)) &&
				   response.User.MatchesFull(user) &&
				   response.PostComment == null &&
				   response.PostCommentLikes.MatchesSortedCollection(request.Pagination,
														  postCommentLikes,
														  matches,
														  termTransformer,
														  matchesFilter);
		}

		public bool Matches(
		GetAllPostCommentLikesQuery query,
		PostComment postComment,
		ICollection<PostCommentLike> postCommentLikes)
		{
			return response.MatchesWithoutUser(
					   query,
					   (response, postCommentLike) => response.MatchesWithoutPostComment(query, postCommentLike),
					   postCommentLike => postCommentLike.MatchesFilter(query.Filter),
					   postComment,
					   postCommentLikes);
		}

		public bool Matches(
			GetAllPostCommentLikesQuery query,
			PostComment postComment,
			ICollection<PostCommentLike> postCommentLikes,
			ISortEnumTermTransformer<PostCommentLike> termTransformer)
		{
			return response.MatchesWithoutUser(
					   query,
					   (response, postCommentLike) => response.MatchesWithoutPostComment(query, postCommentLike),
					   postCommentLike => postCommentLike.MatchesFilter(query.Filter),
					   postComment,
					   postCommentLikes,
					   termTransformer);
		}

		public bool Matches(
		GetAllPostCommentLikesForUserQuery query,
		User user,
		ICollection<PostCommentLike> postCommentLikes)
		{
			return response.MatchesWithoutPostComment(
					   query,
					   (response, postCommentLike) => response.MatchesWithoutUser(query, postCommentLike),
					   postCommentLike => postCommentLike.MatchesFilter(query.Filter),
					   user,
					   postCommentLikes);
		}

		public bool Matches(
			GetAllPostCommentLikesForUserQuery query,
			User user,
			ICollection<PostCommentLike> postCommentLikes,
			ISortEnumTermTransformer<PostCommentLike> termTransformer)
		{
			return response.MatchesWithoutPostComment(
					   query,
					   (response, postCommentLike) => response.MatchesWithoutUser(query, postCommentLike),
					   postCommentLike => postCommentLike.MatchesFilter(query.Filter),
					   user,
					   postCommentLikes,
					   termTransformer);
		}
	}
}
