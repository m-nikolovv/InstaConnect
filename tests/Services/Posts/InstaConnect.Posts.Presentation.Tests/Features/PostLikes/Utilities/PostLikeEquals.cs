using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Posts.Application.Features.PostLikes.Commands.Add;
using InstaConnect.Posts.Application.Features.PostLikes.Commands.Delete;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;
using InstaConnect.Posts.Events.Features.PostLikes;
using InstaConnect.Posts.Events.Features.Posts;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;

public static class PostLikeEquals
{
	extension(PostLikeAddedEventRequest r)
	{
		public bool Matches(AddPostLikeApiRequest request, PostLike entity)
		{
			return r.PostLike.Matches(request, entity);
		}
	}

	extension(PostLikeDeletedEventRequest r)
	{
		public bool Matches(DeletePostLikeApiRequest request, PostLike entity)
		{
			return r.PostLike.Matches(request, entity);
		}
	}

	extension(PostLikeEventRequest r)
	{
		public bool Matches(AddPostLikeApiRequest request, PostLike? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.UserId.EqualsOrdinalIgnoreCase(request.UserId) &&
				   r.User.Matches(request, entity.User) &&
				   r.Post.Matches(request, entity.Post) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(DeletePostLikeApiRequest request, PostLike? entity)
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
		public bool Matches(AddPostLikeApiRequest request, Post? entity)
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

		public bool Matches(DeletePostLikeApiRequest request, Post? entity)
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
		public bool Matches(AddPostLikeApiRequest request, User? entity)
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

		public bool Matches(DeletePostLikeApiRequest request, User? entity)
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

	extension(GetAllPostLikesQueryRequest query)
	{
		public bool Matches(GetAllPostLikesApiRequest request)
		{
			return query.MatchesFilter(request) &&
				   query.MatchesSortable<GetAllPostLikesQueryRequest, PostLikesSortTerm, GetAllPostLikesApiRequest>(request) &&
				   query.MatchesPaginatable(request) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool MatchesFilter(GetAllPostLikesApiRequest request)
		{
			return query.Id == request.Id &&
				   query.UserName == request.UserName;
		}
	}

	extension(GetAllPostLikesForUserQueryRequest query)
	{
		public bool Matches(GetAllPostLikesForUserApiRequest request)
		{
			return query.MatchesFilter(request) &&
				   query.MatchesSortable<GetAllPostLikesForUserQueryRequest, PostLikesForUserSortTerm, GetAllPostLikesForUserApiRequest>(request) &&
				   query.MatchesPaginatable(request) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool MatchesFilter(GetAllPostLikesForUserApiRequest request)
		{
			return query.UserId == request.UserId;
		}
	}

	extension(GetPostLikeByIdQueryRequest query)
	{
		public bool Matches(GetPostLikeByIdApiRequest request)
		{
			return query.Id == request.Id &&
				   query.UserId == request.UserId &&
				   query.MatchesCurrentUserable(request);
		}
	}

	extension(AddPostLikeCommandRequest command)
	{
		public bool Matches(AddPostLikeApiRequest request)
		{
			return command.Id == request.Id &&
				   command.UserId == request.UserId;
		}
	}

	extension(DeletePostLikeCommandRequest command)
	{
		public bool Matches(DeletePostLikeApiRequest request)
		{
			return command.Id == request.Id &&
				   command.UserId == request.UserId;
		}
	}

	extension(AddPostLikeApiResponse response)
	{
		public bool Matches(
		AddPostLikeApiRequest request,
		PostLike postLike)
		{
			return response.Response.Matches(postLike.Id);
		}
	}

	extension(GetPostLikeByIdApiResponse response)
	{
		public bool Matches(GetPostLikeByIdApiRequest request, PostLike postLike)
		{
			return response.Response.MatchesFull(request, postLike);
		}
	}

	extension(GetAllPostLikesApiResponse response)
	{
		public bool Matches(
		GetAllPostLikesApiRequest request,
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
			GetAllPostLikesApiRequest request,
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

	extension(GetAllPostLikesForUserApiResponse response)
	{
		public bool Matches(
		GetAllPostLikesForUserApiRequest request,
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
			GetAllPostLikesForUserApiRequest request,
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
		public bool Matches(AddPostLikeApiRequest request)
		{
			return postLike.Id.Matches(request.Id, request.UserId) &&
				   postLike.CreatedAtUtc != default;
		}

		public bool MatchesFilter(GetAllPostLikesApiRequest request)
		{
			return postLike.Id.Id.Matches(request.Id) &&
				   postLike.User.MatchesFilter(request);
		}

		public bool MatchesFilter(GetAllPostLikesForUserApiRequest request)
		{
			return postLike.Id.UserId.Matches(request.UserId);
		}
	}

	extension(User? u)
	{
		public bool MatchesFilter(GetAllPostLikesApiRequest request)
		{
			return u != null &&
				   u.Name.Value.StartsWithOrdinalIgnoreCase(request.UserName);
		}
	}

	extension(PostLikeIdApiResponse response)
	{
		public bool Matches(PostLikeId id)
		{
			return id.Matches(response.Id, response.UserId);
		}
	}

	extension(PostLikeApiResponse? response)
	{
		public bool MatchesFull<TRequest>(TRequest request, PostLike? postLike)
		where TRequest : ICurrentUserableApiRequest
		{
			return response != null &&
				   postLike != null &&
				   postLike.Id.Matches(response.Id, response.UserId) &&
				   postLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User.MatchesFull(postLike.User) &&
				   response.Post.MatchesFull(request, postLike.Post);
		}

		public bool MatchesWithoutUser<TRequest>(TRequest request, PostLike? postLike)
			where TRequest : ICurrentUserableApiRequest
		{
			return response != null &&
				   postLike != null &&
				   postLike.Id.Matches(response.Id, response.UserId) &&
				   postLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User == null &&
				   response.Post.MatchesFull(request, postLike.Post);
		}

		public bool MatchesWithoutPost<TRequest>(TRequest request, PostLike? postLike)
			where TRequest : ICurrentUserableApiRequest
		{
			return response != null &&
				   postLike != null &&
				   postLike.Id.Matches(response.Id, response.UserId) &&
				   postLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User.MatchesFull(postLike.User) &&
				   response.Post == null;
		}
	}

	extension(PostLikeCollectionApiResponse response)
	{
		public bool MatchesWithoutUser<TRequest>(
		TRequest request,
		Func<PostLikeApiResponse, PostLike, bool> matches,
		Func<PostLike, bool> matchesFilter,
		Post post,
		ICollection<PostLike> postLikes)
		where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
			Func<PostLikeApiResponse, PostLike, bool> matches,
			Func<PostLike, bool> matchesFilter,
			Post post,
			ICollection<PostLike> postLikes,
			ISortEnumTermTransformer<PostLike> termTransformer)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
			Func<PostLikeApiResponse, PostLike, bool> matches,
			Func<PostLike, bool> matchesFilter,
			User user,
			ICollection<PostLike> postLikes)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
			Func<PostLikeApiResponse, PostLike, bool> matches,
			Func<PostLike, bool> matchesFilter,
			User user,
			ICollection<PostLike> postLikes,
			ISortEnumTermTransformer<PostLike> termTransformer)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
