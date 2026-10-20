using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Add;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Delete;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetById;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;
using InstaConnect.Posts.Events.Features.PostCommentLikes;
using InstaConnect.Posts.Events.Features.PostComments;
using InstaConnect.Posts.Events.Features.Posts;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeEquals
{
	extension(PostCommentLikeAddedEventRequest r)
	{
		public bool Matches(AddPostCommentLikeApiRequest command, PostCommentLike entity)
		{
			return r.PostCommentLike.Matches(command, entity);
		}
	}

	extension(PostCommentLikeDeletedEventRequest r)
	{
		public bool Matches(DeletePostCommentLikeApiRequest command, PostCommentLike entity)
		{
			return r.PostCommentLike.Matches(command, entity);
		}
	}

	extension(PostCommentLikeEventRequest r)
	{
		public bool Matches(AddPostCommentLikeApiRequest request, PostCommentLike? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.CommentId.EqualsOrdinalIgnoreCase(request.CommentId) &&
				   r.UserId.EqualsOrdinalIgnoreCase(request.UserId) &&
				   r.User.Matches(request, entity.User) &&
				   r.PostComment.Matches(request, entity.PostComment) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}
		public bool Matches(DeletePostCommentLikeApiRequest request, PostCommentLike? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.CommentId.EqualsOrdinalIgnoreCase(request.CommentId) &&
				   r.UserId.EqualsOrdinalIgnoreCase(request.UserId) &&
				   r.User.Matches(request, entity.User) &&
				   r.PostComment.Matches(request, entity.PostComment) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}
	}

	extension(PostCommentEventRequest r)
	{
		public bool Matches(AddPostCommentLikeApiRequest request, PostComment? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.CommentId.EqualsOrdinalIgnoreCase(request.CommentId) &&
				   r.UserId.EqualsOrdinalIgnoreCase(request.UserId) &&
				   r.Content == entity.Content &&
				   r.Summary.EqualsOrdinalIgnoreCase(entity.Summary.Value) &&
				   r.User.Matches(request, entity.User) &&
				   r.Post.Matches(request, entity.Post) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
		public bool Matches(DeletePostCommentLikeApiRequest request, PostComment? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.CommentId.EqualsOrdinalIgnoreCase(request.CommentId) &&
				   r.UserId.EqualsOrdinalIgnoreCase(request.UserId) &&
				   r.Content == entity.Content &&
				   r.Summary.EqualsOrdinalIgnoreCase(entity.Summary.Value) &&
				   r.User.Matches(request, entity.User) &&
				   r.Post.Matches(request, entity.Post) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
	}

	extension(PostEventRequest r)
	{
		public bool Matches(AddPostCommentLikeApiRequest request, Post? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.UserId.EqualsOrdinalIgnoreCase(request.UserId) &&
				   r.User.Matches(request, entity.User) &&
				   r.Title == entity.Title &&
				   r.Content == entity.Content &&
				   r.Summary.EqualsOrdinalIgnoreCase(entity.Summary.Value) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
		public bool Matches(DeletePostCommentLikeApiRequest request, Post? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.UserId.EqualsOrdinalIgnoreCase(request.UserId) &&
				   r.User.Matches(request, entity.User) &&
				   r.Title == entity.Title &&
				   r.Content == entity.Content &&
				   r.Summary.EqualsOrdinalIgnoreCase(entity.Summary.Value) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
	}

	extension(UserEventRequest r)
	{
		public bool Matches(AddPostCommentLikeApiRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.UserId) &&
				   r.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
		public bool Matches(DeletePostCommentLikeApiRequest request, User? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.UserId) &&
				   r.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   r.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   r.FirstName == entity.FirstName &&
				   r.LastName == entity.LastName &&
				   r.ProfileImageUrl == entity.ProfileImageUrl?.Value &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
	}

	extension(GetAllPostCommentLikesQueryRequest query)
	{
		public bool Matches(GetAllPostCommentLikesApiRequest request)
		{
			return query.MatchesFilter(request) &&
				   query.MatchesSortable<GetAllPostCommentLikesQueryRequest, PostCommentLikesSortTerm, GetAllPostCommentLikesApiRequest>(request) &&
				   query.MatchesPaginatable(request) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool MatchesFilter(GetAllPostCommentLikesApiRequest request)
		{
			return query.Id == request.Id &&
				   query.CommentId == request.CommentId &&
				   query.UserName == request.UserName;
		}
	}

	extension(GetAllPostCommentLikesForUserQueryRequest query)
	{
		public bool Matches(GetAllPostCommentLikesForUserApiRequest request)
		{
			return query.MatchesFilter(request) &&
				   query.MatchesSortable<GetAllPostCommentLikesForUserQueryRequest, PostCommentLikesForUserSortTerm, GetAllPostCommentLikesForUserApiRequest>(request) &&
				   query.MatchesPaginatable(request) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool MatchesFilter(GetAllPostCommentLikesForUserApiRequest request)
		{
			return query.UserId == request.UserId;
		}
	}

	extension(GetPostCommentLikeByIdQueryRequest query)
	{
		public bool Matches(GetPostCommentLikeByIdApiRequest request)
		{
			return query.Id == request.Id &&
				   query.CommentId == request.CommentId &&
				   query.UserId == request.UserId &&
				   query.MatchesCurrentUserable(request);
		}
	}

	extension(AddPostCommentLikeCommandRequest command)
	{
		public bool Matches(AddPostCommentLikeApiRequest request)
		{
			return command.Id == request.Id &&
				   command.CommentId == request.CommentId &&
				   command.UserId == request.UserId;
		}
	}

	extension(DeletePostCommentLikeCommandRequest command)
	{
		public bool Matches(DeletePostCommentLikeApiRequest request)
		{
			return command.Id == request.Id &&
				   command.CommentId == request.CommentId &&
				   command.UserId == request.UserId;
		}
	}

	extension(AddPostCommentLikeApiResponse response)
	{
		public bool Matches(
		AddPostCommentLikeApiRequest request,
		PostCommentLike postCommentLike)
		{
			return response.Response.Matches(postCommentLike.Id);
		}
	}

	extension(GetPostCommentLikeByIdApiResponse response)
	{
		public bool Matches(GetPostCommentLikeByIdApiRequest request, PostCommentLike postCommentLike)
		{
			return response.Response.MatchesFull(request, postCommentLike);
		}
	}

	extension(GetAllPostCommentLikesApiResponse response)
	{
		public bool Matches(
		GetAllPostCommentLikesApiRequest request,
		PostComment postComment,
		ICollection<PostCommentLike> postCommentLikes)
		{
			return response.Response.MatchesWithoutUser(
					   request,
					   (response, postCommentLike) => response.MatchesWithoutPostComment(request, postCommentLike),
					   postCommentLike => postCommentLike.MatchesFilter(request),
					   postComment,
					   postCommentLikes);
		}

		public bool Matches(
			GetAllPostCommentLikesApiRequest request,
			PostComment postComment,
			ICollection<PostCommentLike> postCommentLikes,
			ISortEnumTermTransformer<PostCommentLike> termTransformer)
		{
			return response.Response.MatchesWithoutUser(
					   request,
					   (response, postCommentLike) => response.MatchesWithoutPostComment(request, postCommentLike),
					   postCommentLike => postCommentLike.MatchesFilter(request),
					   postComment,
					   postCommentLikes,
					   termTransformer);
		}
	}

	extension(GetAllPostCommentLikesForUserApiResponse response)
	{
		public bool Matches(
		GetAllPostCommentLikesForUserApiRequest request,
		User user,
		ICollection<PostCommentLike> postCommentLikes)
		{
			return response.Response.MatchesWithoutPostComment(
					   request,
					   (response, postCommentLike) => response.MatchesWithoutUser(request, postCommentLike),
					   postCommentLike => postCommentLike.MatchesFilter(request),
					   user,
					   postCommentLikes);
		}

		public bool Matches(
			GetAllPostCommentLikesForUserApiRequest request,
			User user,
			ICollection<PostCommentLike> postCommentLikes,
			ISortEnumTermTransformer<PostCommentLike> termTransformer)
		{
			return response.Response.MatchesWithoutPostComment(
					   request,
					   (response, postCommentLike) => response.MatchesWithoutUser(request, postCommentLike),
					   postCommentLike => postCommentLike.MatchesFilter(request),
					   user,
					   postCommentLikes,
					   termTransformer);
		}
	}

	extension(PostCommentLike postCommentLike)
	{
		public bool Matches(AddPostCommentLikeApiRequest request)
		{
			return postCommentLike.Id.Matches(request.Id, request.CommentId, request.UserId) &&
				   postCommentLike.CreatedAtUtc != default;
		}

		public bool MatchesFilter(GetAllPostCommentLikesApiRequest request)
		{
			return postCommentLike.Id.CommentId.Matches(request.Id, request.CommentId) &&
				   postCommentLike.User.MatchesFilter(request);
		}

		public bool MatchesFilter(GetAllPostCommentLikesForUserApiRequest request)
		{
			return postCommentLike.Id.UserId.Matches(request.UserId);
		}
	}

	extension(User? u)
	{
		public bool MatchesFilter(GetAllPostCommentLikesApiRequest request)
		{
			return u != null &&
				   u.Name.Value.StartsWithOrdinalIgnoreCase(request.UserName);
		}
	}

	extension(PostCommentLikeIdApiResponse response)
	{
		public bool Matches(PostCommentLikeId id)
		{
			return id.Matches(response.Id, response.CommentId, response.UserId);
		}
	}

	extension(PostCommentLikeApiResponse? response)
	{
		public bool MatchesFull<TRequest>(TRequest request, PostCommentLike? postCommentLike)
	where TRequest : ICurrentUserableApiRequest
		{
			return response != null &&
				   postCommentLike != null &&
				   postCommentLike.Id.Matches(response.Id, response.CommentId, response.UserId) &&
				   postCommentLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User.MatchesFull(postCommentLike.User) &&
				   response.PostComment.MatchesFull(request, postCommentLike.PostComment);
		}

		public bool MatchesWithoutUser<TRequest>(TRequest request, PostCommentLike? postCommentLike)
			where TRequest : ICurrentUserableApiRequest
		{
			return response != null &&
				   postCommentLike != null &&
				   postCommentLike.Id.Matches(response.Id, response.CommentId, response.UserId) &&
				   postCommentLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User == null &&
				   response.PostComment.MatchesFull(request, postCommentLike.PostComment);
		}

		public bool MatchesWithoutPostComment<TRequest>(TRequest request, PostCommentLike? postCommentLike)
			where TRequest : ICurrentUserableApiRequest
		{
			return response != null &&
				   postCommentLike != null &&
				   postCommentLike.Id.Matches(response.Id, response.CommentId, response.UserId) &&
				   postCommentLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User.MatchesFull(postCommentLike.User) &&
				   response.PostComment == null;
		}
	}

	extension(PostCommentLikeCollectionApiResponse response)
	{
		public bool MatchesWithoutUser<TRequest>(
		TRequest request,
		Func<PostCommentLikeApiResponse, PostCommentLike, bool> matches,
		Func<PostCommentLike, bool> matchesFilter,
		PostComment postComment,
		ICollection<PostCommentLike> postCommentLikes)
		where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			return response.MatchesCollectionResponse(request, postCommentLikes.Count(matchesFilter)) &&
				   response.User == null &&
				   response.PostComment.MatchesFull(request, postComment) &&
				   response.PostCommentLikes.MatchesCollection(request,
														postCommentLikes,
														response => new(new(new(response.Id), response.CommentId), new(response.UserId)),
														postCommentLike => postCommentLike.Id,
														matches,
														matchesFilter);
		}

		public bool MatchesWithoutUser<TRequest>(
			TRequest request,
			Func<PostCommentLikeApiResponse, PostCommentLike, bool> matches,
			Func<PostCommentLike, bool> matchesFilter,
			PostComment postComment,
			ICollection<PostCommentLike> postCommentLikes,
			ISortEnumTermTransformer<PostCommentLike> termTransformer)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			return response.MatchesCollectionResponse(request, postCommentLikes.Count(matchesFilter)) &&
				   response.User == null &&
				   response.PostComment.MatchesFull(request, postComment) &&
				   response.PostCommentLikes.MatchesSortedCollection(request,
															  postCommentLikes,
															  matches,
															  termTransformer,
															  matchesFilter);
		}

		public bool MatchesWithoutPostComment<TRequest>(
			TRequest request,
			Func<PostCommentLikeApiResponse, PostCommentLike, bool> matches,
			Func<PostCommentLike, bool> matchesFilter,
			User user,
			ICollection<PostCommentLike> postCommentLikes)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			return response.MatchesCollectionResponse(request, postCommentLikes.Count(matchesFilter)) &&
				   response.User.MatchesFull(user) &&
				   response.PostComment == null &&
				   response.PostCommentLikes.MatchesCollection(request,
														postCommentLikes,
														response => new(new(new(response.Id), response.CommentId), new(response.UserId)),
														postCommentLike => postCommentLike.Id,
														matches,
														matchesFilter);
		}

		public bool MatchesWithoutPostComment<TRequest>(
			TRequest request,
			Func<PostCommentLikeApiResponse, PostCommentLike, bool> matches,
			Func<PostCommentLike, bool> matchesFilter,
			User user,
			ICollection<PostCommentLike> postCommentLikes,
			ISortEnumTermTransformer<PostCommentLike> termTransformer)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			return response.MatchesCollectionResponse(request, postCommentLikes.Count(matchesFilter)) &&
				   response.User.MatchesFull(user) &&
				   response.PostComment == null &&
				   response.PostCommentLikes.MatchesSortedCollection(request,
															  postCommentLikes,
															  matches,
															  termTransformer,
															  matchesFilter);
		}
	}
}
