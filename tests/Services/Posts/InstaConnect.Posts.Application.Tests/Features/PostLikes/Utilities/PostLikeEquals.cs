using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Posts.Application.Features.PostLikes.Models;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;
using InstaConnect.Posts.Events.Features.PostLikes;
using InstaConnect.Posts.Events.Features.Posts;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;

public static class PostLikeEquals
{
	extension(PostLikeAddedEventRequest r)
	{
		public bool Matches(AddPostLikeCommandRequest request, PostLike entity)
		{
			return r.PostLike.Matches(request, entity);
		}
	}

	extension(PostLikeDeletedEventRequest r)
	{
		public bool Matches(DeletePostLikeCommandRequest request, PostLike entity)
		{
			return r.PostLike.Matches(request, entity);
		}
	}

	extension(PostLikeEventRequest r)
	{
		public bool Matches(AddPostLikeCommandRequest request, PostLike? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.UserId.EqualsOrdinalIgnoreCase(request.UserId) &&
				   r.User.Matches(request, entity.User) &&
				   r.Post.Matches(request, entity.Post) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(DeletePostLikeCommandRequest request, PostLike? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.UserId.EqualsOrdinalIgnoreCase(request.UserId) &&
				   r.User.Matches(request, entity.User) &&
				   r.Post.Matches(request, entity.Post) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}
	}

	extension(PostEventRequest r)
	{
		public bool Matches(AddPostLikeCommandRequest request, Post? entity)
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

		public bool Matches(DeletePostLikeCommandRequest request, Post? entity)
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
		public bool Matches(AddPostLikeCommandRequest request, User? entity)
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

		public bool Matches(DeletePostLikeCommandRequest request, User? entity)
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

	extension(GetAllPostLikesQuery query)
	{
		public bool Matches(GetAllPostLikesQueryRequest request)
		{
			return query.MatchesFilter(request) &&
				   query.MatchesSortable<GetAllPostLikesQuery, PostLikesSortTerm, PostLikesSortingQuery, GetAllPostLikesQueryRequest>(request) &&
				   query.MatchesPaginatable<GetAllPostLikesQuery, PostLikesPaginationQuery, GetAllPostLikesQueryRequest>(request) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool MatchesFilter(GetAllPostLikesQueryRequest request)
		{
			return query.Filter.Id.Matches(request.Id) &&
				   query.Filter.UserName.Matches(request.UserName);
		}
	}

	extension(GetAllPostLikesForUserQuery query)
	{
		public bool Matches(GetAllPostLikesForUserQueryRequest request)
		{
			return query.MatchesFilter(request) &&
				   query.MatchesSortable<GetAllPostLikesForUserQuery, PostLikesForUserSortTerm, PostLikesForUserSortingQuery, GetAllPostLikesForUserQueryRequest>(request) &&
				   query.MatchesPaginatable<GetAllPostLikesForUserQuery, PostLikesPaginationQuery, GetAllPostLikesForUserQueryRequest>(request) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool MatchesFilter(GetAllPostLikesForUserQueryRequest request)
		{
			return query.Filter.UserId.Matches(request.UserId);
		}
	}

	extension(GetPostLikeByIdQuery query)
	{
		public bool Matches(GetPostLikeByIdQueryRequest request)
		{
			return query.Id.Matches(request.Id, request.UserId) &&
				   query.MatchesCurrentUserable(request);
		}
	}

	extension(AddPostLikeCommand command)
	{
		public bool Matches(AddPostLikeCommandRequest request)
		{
			return command.Id.Matches(request.Id) &&
				   command.UserId.Matches(request.UserId);
		}
	}

	extension(DeletePostLikeCommand command)
	{
		public bool Matches(DeletePostLikeCommandRequest request)
		{
			return command.Id.Matches(request.Id, request.UserId);
		}
	}

	extension(AddPostLikeCommandResponse response)
	{
		public bool Matches(
		AddPostLikeCommandRequest request,
		PostLike postLike)
		{
			return response.Response.Matches(postLike.Id);
		}
	}

	extension(GetPostLikeByIdQueryResponse response)
	{
		public bool Matches(GetPostLikeByIdQueryRequest request, PostLike postLike)
		{
			return response.Response.MatchesFull(request, postLike);
		}
	}

	extension(GetAllPostLikesQueryResponse response)
	{
		public bool Matches(
		GetAllPostLikesQueryRequest request,
		Post post,
		ICollection<PostLike> postLikes)
		{
			return response.Response.MatchesWithoutUser(
					   request,
					   (response, postLike) => response.MatchesWithoutPost(request, postLike),
					   postLike => postLike.MatchesFilter(request),
					   post,
					   postLikes);
		}

		public bool Matches(
			GetAllPostLikesQueryRequest request,
			Post post,
			ICollection<PostLike> postLikes,
			ISortEnumTermTransformer<PostLike> termTransformer)
		{
			return response.Response.MatchesWithoutUser(
					   request,
					   (response, postLike) => response.MatchesWithoutPost(request, postLike),
					   postLike => postLike.MatchesFilter(request),
					   post,
					   postLikes,
					   termTransformer);
		}
	}

	extension(GetAllPostLikesForUserQueryResponse response)
	{
		public bool Matches(
		GetAllPostLikesForUserQueryRequest request,
		User user,
		ICollection<PostLike> postLikes)
		{
			return response.Response.MatchesWithoutPost(
					   request,
					   (response, postLike) => response.MatchesWithoutUser(request, postLike),
					   postLike => postLike.MatchesFilter(request),
					   user,
					   postLikes);
		}

		public bool Matches(
			GetAllPostLikesForUserQueryRequest request,
			User user,
			ICollection<PostLike> postLikes,
			ISortEnumTermTransformer<PostLike> termTransformer)
		{
			return response.Response.MatchesWithoutPost(
					   request,
					   (response, postLike) => response.MatchesWithoutUser(request, postLike),
					   postLike => postLike.MatchesFilter(request),
					   user,
					   postLikes,
					   termTransformer);
		}
	}

	extension(PostLike postLike)
	{
		public bool Matches(AddPostLikeCommandRequest request)
		{
			return postLike.Id.Matches(request.Id, request.UserId) &&
				   postLike.CreatedAtUtc != default;
		}

		public bool MatchesFilter(GetAllPostLikesQueryRequest request)
		{
			return postLike.Id.Id.Matches(request.Id) &&
				   postLike.User.MatchesFilter(request);
		}

		public bool MatchesFilter(GetAllPostLikesForUserQueryRequest request)
		{
			return postLike.Id.UserId.Matches(request.UserId);
		}
	}

	extension(User? u)
	{
		public bool MatchesFilter(GetAllPostLikesQueryRequest request)
		{
			return u != null &&
				   u.Name.Value.StartsWithOrdinalIgnoreCase(request.UserName);
		}
	}

	extension(PostLikeIdCommandResponse response)
	{
		public bool Matches(PostLikeId id)
		{
			return id.Matches(response.Id, response.UserId);
		}
	}

	extension(PostLikeQueryResponse? response)
	{
		public bool MatchesFull<TRequest>(TRequest request, PostLike? postLike)
		where TRequest : ICurrentUserableQueryRequest
		{
			return response != null &&
				   postLike != null &&
				   postLike.Id.Matches(response.Id, response.UserId) &&
				   postLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User.MatchesFull(postLike.User) &&
				   response.Post.MatchesFull(request, postLike.Post);
		}

		public bool MatchesWithoutUser<TRequest>(TRequest request, PostLike? postLike)
			where TRequest : ICurrentUserableQueryRequest
		{
			return response != null &&
				   postLike != null &&
				   postLike.Id.Matches(response.Id, response.UserId) &&
				   postLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User == null &&
				   response.Post.MatchesFull(request, postLike.Post);
		}

		public bool MatchesWithoutPost<TRequest>(TRequest request, PostLike? postLike)
			where TRequest : ICurrentUserableQueryRequest
		{
			return response != null &&
				   postLike != null &&
				   postLike.Id.Matches(response.Id, response.UserId) &&
				   postLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User.MatchesFull(postLike.User) &&
				   response.Post == null;
		}
	}

	extension(PostLikeCollectionQueryResponse response)
	{
		public bool MatchesWithoutUser<TRequest>(
		TRequest request,
		Func<PostLikeQueryResponse, PostLike, bool> matches,
		Func<PostLike, bool> matchesFilter,
		Post post,
		ICollection<PostLike> postLikes)
		where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, postLikes.Count(matchesFilter)) &&
				   response.User == null &&
				   response.Post.MatchesFull(request, post) &&
				   response.PostLikes.MatchesCollectionAndNotEmpty(request,
														postLikes,
														response => new(new(response.Id), new(response.UserId)),
														postLike => postLike.Id,
														matches,
														matchesFilter);
		}

		public bool MatchesWithoutUser<TRequest>(
			TRequest request,
			Func<PostLikeQueryResponse, PostLike, bool> matches,
			Func<PostLike, bool> matchesFilter,
			Post post,
			ICollection<PostLike> postLikes,
			ISortEnumTermTransformer<PostLike> termTransformer)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, postLikes.Count(matchesFilter)) &&
				   response.User == null &&
				   response.Post.MatchesFull(request, post) &&
				   response.PostLikes.MatchesSortedCollection(request,
															  postLikes,
															  matches,
															  termTransformer,
															  matchesFilter);
		}

		public bool MatchesWithoutPost<TRequest>(
			TRequest request,
			Func<PostLikeQueryResponse, PostLike, bool> matches,
			Func<PostLike, bool> matchesFilter,
			User user,
			ICollection<PostLike> postLikes)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, postLikes.Count(matchesFilter)) &&
				   response.User.MatchesFull(user) &&
				   response.Post == null &&
				   response.PostLikes.MatchesCollectionAndNotEmpty(request,
														postLikes,
														response => new(new(response.Id), new(response.UserId)),
														postLike => postLike.Id,
														matches,
														matchesFilter);
		}

		public bool MatchesWithoutPost<TRequest>(
			TRequest request,
			Func<PostLikeQueryResponse, PostLike, bool> matches,
			Func<PostLike, bool> matchesFilter,
			User user,
			ICollection<PostLike> postLikes,
			ISortEnumTermTransformer<PostLike> termTransformer)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, postLikes.Count(matchesFilter)) &&
				   response.User.MatchesFull(user) &&
				   response.Post == null &&
				   response.PostLikes.MatchesSortedCollection(request,
															  postLikes,
															  matches,
															  termTransformer,
															  matchesFilter);
		}
	}
}
