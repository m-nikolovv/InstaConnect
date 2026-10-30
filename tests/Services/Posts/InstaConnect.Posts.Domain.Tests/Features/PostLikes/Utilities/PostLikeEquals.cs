using InstaConnect.Common.Domain.Features.Requests.Abstractions;
using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Responses;
using InstaConnect.Posts.Events.Features.PostLikes;

namespace InstaConnect.Posts.Domain.Tests.Features.PostLikes.Utilities;

public static class PostLikeEquals
{
	extension(PostLikeId response)
	{
		public bool Matches(
		AddPostLikeCommand command,
		PostLike postLike)
		{
			return response.Matches(postLike.Id);
		}
	}

	extension(PostLikeAddedEventRequest request)
	{
		public bool Matches(AddPostLikeCommand command, PostLike entity)
		{
			return request.PostLike.Matches(command, entity);
		}
	}

	extension(PostLikeDeletedEventRequest request)
	{
		public bool Matches(DeletePostLikeCommand command, PostLike entity)
		{
			return request.PostLike.Matches(command, entity);
		}
	}

	extension(PostLikeEventRequest request)
	{
		public bool Matches(AddPostLikeCommand command, PostLike? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.Id) &&
				   request.UserId.EqualsOrdinalIgnoreCase(command.UserId.Id) &&
				   request.User.Matches(command, entity.User) &&
				   request.Post.Matches(command, entity.Post) &&
				   request.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(DeletePostLikeCommand command, PostLike? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.Id.Id) &&
				   request.UserId.EqualsOrdinalIgnoreCase(command.Id.UserId.Id) &&
				   request.User.Matches(command, entity.User) &&
				   request.Post.Matches(command, entity.Post) &&
				   request.CreatedAtUtc == entity.CreatedAtUtc;
		}
	}

	extension(PostEventRequest request)
	{
		public bool Matches(AddPostLikeCommand command, Post? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.Id) &&
				   request.UserId.EqualsOrdinalIgnoreCase(command.UserId.Id) &&
				   request.User.Matches(command, entity.User) &&
				   request.Title == entity.Title &&
				   request.Content == entity.Content &&
				   entity.Summary.Matches(request.Summary) &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(DeletePostLikeCommand command, Post? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.Id.Id) &&
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
		public bool Matches(AddPostLikeCommand command, User? entity)
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

		public bool Matches(DeletePostLikeCommand command, User? entity)
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

	extension(PostLike postLike)
	{
		public bool Matches(AddPostLikeCommand command)
		{
			return postLike.Id.Matches(command.Id, command.UserId) &&
				   postLike.CreatedAtUtc != default;
		}

		public bool Matches(DeletePostLikeCommand command)
		{
			return postLike.Id.Matches(command.Id) &&
				   postLike.CreatedAtUtc != default;
		}

		public bool MatchesFilter(PostLikesFilterQuery query)
		{
			return postLike.Id.Id.Matches(query.Id) &&
				   postLike.User.MatchesFilter(query);
		}

		public bool MatchesFilter(PostLikesForUserFilterQuery query)
		{
			return postLike.Id.UserId.Matches(query.UserId);
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
		public bool MatchesFull<TQuery>(TQuery request, PostLike? postLike)
		where TQuery : ICurrentUserableQuery
		{
			return response != null &&
				   postLike != null &&
				   postLike.Id.Matches(response.Id) &&
				   postLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User.MatchesFull(postLike.User) &&
				   response.Post.MatchesFull(request, postLike.Post);
		}

		public bool MatchesWithoutUser<TQuery>(TQuery request, PostLike? postLike)
			where TQuery : ICurrentUserableQuery
		{
			return response != null &&
				   postLike != null &&
				   postLike.Id.Matches(response.Id) &&
				   postLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User == null &&
				   response.Post.MatchesFull(request, postLike.Post);
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

		public bool Matches(GetPostLikeByIdQuery query, PostLike postLike)
		{
			return response.MatchesFull(query, postLike);
		}
	}

	extension(PostLikeCollectionResponse response)
	{
		public bool MatchesWithoutUser<TQuery>(
		TQuery request,
		Func<PostLikeResponse, PostLike, bool> matches,
		Func<PostLike, bool> matchesFilter,
		Post post,
		ICollection<PostLike> postLikes)
		where TQuery : ICurrentUserableQuery, IPaginatableQuery<PostLikesPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, postLikes.Count(matchesFilter)) &&
				   response.User == null &&
				   response.Post.MatchesFull(request, post) &&
				   response.PostLikes.MatchesCollectionAndNotEmpty(
													request.Pagination,
													postLikes,
													response => response.Id,
													postLike => postLike.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesWithoutUser<TQuery>(
			TQuery request,
			Func<PostLikeResponse, PostLike, bool> matches,
			Func<PostLike, bool> matchesFilter,
			Post post,
			ICollection<PostLike> postLikes,
			ISortEnumTermTransformer<PostLike> termTransformer)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<PostLikesPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, postLikes.Count(matchesFilter)) &&
				   response.User == null &&
				   response.Post.MatchesFull(request, post) &&
				   response.PostLikes.MatchesSortedCollection(
														  request.Pagination,
														  postLikes,
														  matches,
														  termTransformer,
														  matchesFilter);
		}

		public bool MatchesWithoutPost<TQuery>(
			TQuery request,
			Func<PostLikeResponse, PostLike, bool> matches,
			Func<PostLike, bool> matchesFilter,
			User user,
			ICollection<PostLike> postLikes)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<PostLikesPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, postLikes.Count(matchesFilter)) &&
				   response.User.MatchesFull(user) &&
				   response.Post == null &&
				   response.PostLikes.MatchesCollectionAndNotEmpty(
													request.Pagination,
													postLikes,
													response => response.Id,
													postLike => postLike.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesWithoutPost<TQuery>(
			TQuery request,
			Func<PostLikeResponse, PostLike, bool> matches,
			Func<PostLike, bool> matchesFilter,
			User user,
			ICollection<PostLike> postLikes,
			ISortEnumTermTransformer<PostLike> termTransformer)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<PostLikesPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, postLikes.Count(matchesFilter)) &&
				   response.User.MatchesFull(user) &&
				   response.Post == null &&
				   response.PostLikes.MatchesSortedCollection(
														  request.Pagination,
														  postLikes,
														  matches,
														  termTransformer,
														  matchesFilter);
		}

		public bool Matches(
		GetAllPostLikesQuery query,
		Post post,
		ICollection<PostLike> postLikes)
		{
			return response.MatchesWithoutUser(
					   query,
					   (response, postLike) => response.MatchesWithoutPost(postLike),
					   postLike => postLike.MatchesFilter(query.Filter),
					   post,
					   postLikes);
		}

		public bool Matches(
			GetAllPostLikesQuery query,
			Post post,
			ICollection<PostLike> postLikes,
			ISortEnumTermTransformer<PostLike> termTransformer)
		{
			return response.MatchesWithoutUser(
					   query,
					   (response, postLike) => response.MatchesWithoutPost(postLike),
					   postLike => postLike.MatchesFilter(query.Filter),
					   post,
					   postLikes,
					   termTransformer);
		}

		public bool Matches(
		GetAllPostLikesForUserQuery query,
		User user,
		ICollection<PostLike> postLikes)
		{
			return response.MatchesWithoutPost(
					   query,
					   (response, postLike) => response.MatchesWithoutUser(query, postLike),
					   postLike => postLike.MatchesFilter(query.Filter),
					   user,
					   postLikes);
		}

		public bool Matches(
			GetAllPostLikesForUserQuery query,
			User user,
			ICollection<PostLike> postLikes,
			ISortEnumTermTransformer<PostLike> termTransformer)
		{
			return response.MatchesWithoutPost(
					   query,
					   (response, postLike) => response.MatchesWithoutUser(query, postLike),
					   postLike => postLike.MatchesFilter(query.Filter),
					   user,
					   postLikes,
					   termTransformer);
		}
	}
}
