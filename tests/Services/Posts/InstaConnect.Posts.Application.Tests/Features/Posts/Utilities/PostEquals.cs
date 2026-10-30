using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Posts.Application.Features.Posts.Models;
using InstaConnect.Posts.Application.Tests.Features.PostImages.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Posts.Extensions;
using InstaConnect.Posts.Domain.Features.PostImages.Models.Entities;
using InstaConnect.Posts.Domain.Tests.Features.PostImages.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Events.Features.PostImages;
using InstaConnect.Posts.Events.Features.Posts;
using InstaConnect.Posts.Tests.Features.PostImages.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Extensions;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;

public static class PostEquals
{
	extension(PostAddedEventRequest r)
	{
		public bool Matches(AddPostCommandRequest request, Post entity)
		{
			return r.Post.Matches(request, entity);
		}
	}

	extension(PostUpdatedEventRequest r)
	{
		public bool Matches(UpdatePostCommandRequest request, Post entity)
		{
			return r.Post.Matches(request, entity);
		}
	}

	extension(PostDeletedEventRequest r)
	{
		public bool Matches(DeletePostCommandRequest request, Post entity)
		{
			return r.Post.Matches(request, entity);
		}
	}

	extension(PostEventRequest r)
	{
		public bool Matches(AddPostCommandRequest request, Post? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(entity.Id.Id) &&
				   r.UserId.EqualsOrdinalIgnoreCase(request.UserId) &&
				   r.User.Matches(request, entity.User) &&
				   r.PostImages.Matches(request, entity.PostImages) &&
				   r.Title == request.Title &&
				   r.Content == request.Content &&
				   r.Summary == entity.GetSummary(request) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(UpdatePostCommandRequest request, Post? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.UserId.EqualsOrdinalIgnoreCase(request.UserId) &&
				   r.User.Matches(request, entity.User) &&
				   r.PostImages.Matches(request, entity.PostImages) &&
				   r.Title == request.Title &&
				   r.Content == request.Content &&
				   r.Summary == entity.GetSummary(request) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(DeletePostCommandRequest request, Post? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.UserId.EqualsOrdinalIgnoreCase(request.UserId) &&
				   r.User.Matches(request, entity.User) &&
				   r.PostImages.Matches(request, entity.PostImages) &&
				   r.Title == entity.Title &&
				   r.Content == entity.Content &&
				   r.Summary.EqualsOrdinalIgnoreCase(entity.Summary.Value) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
	}

	extension(UserEventRequest r)
	{
		public bool Matches(AddPostCommandRequest request, User? entity)
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

		public bool Matches(UpdatePostCommandRequest request, User? entity)
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

		public bool Matches(DeletePostCommandRequest request, User? entity)
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

	extension(PostImageEventRequest r)
	{
		public bool Matches(AddPostCommandRequest request, PostImage? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(entity.Id.Id.Id) &&
				   r.ImageId.EqualsOrdinalIgnoreCase(entity.Id.ImageId) &&
				   request.Images.ContainsUrl(r.Url) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(UpdatePostCommandRequest request, PostImage? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.ImageId.EqualsOrdinalIgnoreCase(entity.Id.ImageId) &&
				   r.Url.EqualsOrdinalIgnoreCase(entity.Url.Value) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(DeletePostCommandRequest request, PostImage? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.ImageId.EqualsOrdinalIgnoreCase(entity.Id.ImageId) &&
				   r.Url.EqualsOrdinalIgnoreCase(entity.Url.Value) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}
	}

	extension(ICollection<PostImageEventRequest> r)
	{
		public bool Matches(AddPostCommandRequest request, ICollection<PostImage> entities)
		{
			return request.Images.IsEmpty() ||
				   r.MatchesCollection(
					   entities,
					   response => new(new(response.Id), response.ImageId),
					   postImage => postImage.Id,
					   (r, postImage) => r.Matches(request, postImage));
		}

		public bool Matches(UpdatePostCommandRequest request, ICollection<PostImage> entities)
		{
			return r.MatchesCollection(
				entities,
				response => new(new(response.Id), response.ImageId),
				postImage => postImage.Id,
				(r, postImage) => r.Matches(request, postImage));
		}

		public bool Matches(DeletePostCommandRequest request, ICollection<PostImage> entities)
		{
			return r.MatchesCollection(
				entities,
				response => new(new(response.Id), response.ImageId),
				postImage => postImage.Id,
				(r, postImage) => r.Matches(request, postImage));
		}
	}

	extension(GetAllPostsQuery query)
	{
		public bool Matches(GetAllPostsQueryRequest request)
		{
			return query.MatchesFilter(request) &&
				   query.MatchesSortable<GetAllPostsQuery, PostsSortTerm, PostsSortingQuery, GetAllPostsQueryRequest>(request) &&
				   query.MatchesPaginatable<GetAllPostsQuery, PostsPaginationQuery, GetAllPostsQueryRequest>(request) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool MatchesFilter(GetAllPostsQueryRequest request)
		{
			return query.Filter.UserName.Matches(request.UserName) &&
				   query.Filter.Title == request.Title;
		}
	}

	extension(GetAllPostsForUserQuery query)
	{
		public bool Matches(GetAllPostsForUserQueryRequest request)
		{
			return query.MatchesFilter(request) &&
				   query.MatchesSortable<GetAllPostsForUserQuery, PostsForUserSortTerm, PostsForUserSortingQuery, GetAllPostsForUserQueryRequest>(request) &&
				   query.MatchesPaginatable<GetAllPostsForUserQuery, PostsPaginationQuery, GetAllPostsForUserQueryRequest>(request) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool MatchesFilter(GetAllPostsForUserQueryRequest request)
		{
			return query.Filter.UserId.Matches(request.UserId) &&
				   query.Filter.Title == request.Title;
		}
	}

	extension(GetPostByIdQuery query)
	{
		public bool Matches(GetPostByIdQueryRequest request)
		{
			return query.Id.Matches(request.Id) &&
				   query.MatchesCurrentUserable(request);
		}
	}

	extension(AddPostCommand command)
	{
		public bool Matches(AddPostCommandRequest request)
		{
			return command.UserId.Matches(request.UserId) &&
				   command.Title == request.Title &&
				   command.Content == request.Content &&
				   command.Images == request.Images;
		}
	}

	extension(UpdatePostCommand command)
	{
		public bool Matches(UpdatePostCommandRequest request)
		{
			return command.Id.Matches(request.Id) &&
				   command.UserId.Matches(request.UserId) &&
				   command.Title == request.Title &&
				   command.Content == request.Content;
		}
	}

	extension(DeletePostCommand command)
	{
		public bool Matches(DeletePostCommandRequest request)
		{
			return command.Id.Matches(request.Id) &&
				   command.UserId.Matches(request.UserId);
		}
	}

	extension(AddPostCommandResponse response)
	{
		public bool Matches(AddPostCommandRequest request, Post post)
		{
			return response.Response.Matches(post.Id);
		}
	}

	extension(UpdatePostCommandResponse response)
	{
		public bool Matches(UpdatePostCommandRequest request, Post post)
		{
			return response.Response.Matches(post.Id);
		}
	}

	extension(GetPostByIdQueryResponse response)
	{
		public bool Matches(GetPostByIdQueryRequest request, Post post)
		{
			return response.Response.MatchesFull(request, post);
		}
	}

	extension(GetAllPostsQueryResponse response)
	{
		public bool Matches(
		GetAllPostsQueryRequest request,
		ICollection<Post> posts)
		{
			return response.Response.MatchesWithoutUser(
					   request,
					   (response, post) => response.MatchesFull(request, post),
					   post => post.MatchesFilter(request),
					   posts);
		}

		public bool Matches(
			GetAllPostsQueryRequest request,
			ICollection<Post> posts,
			ISortEnumTermTransformer<Post> termTransformer)
		{
			return response.Response.MatchesWithoutUser(
					   request,
					   (response, post) => response.MatchesFull(request, post),
					   post => post.MatchesFilter(request),
					   posts,
					   termTransformer);
		}
	}

	extension(GetAllPostsForUserQueryResponse response)
	{
		public bool Matches(
		GetAllPostsForUserQueryRequest request,
		User user,
		ICollection<Post> posts)
		{
			return response.Response.MatchesFull(
					   request,
					   (response, post) => response.MatchesWithoutUser(request, post),
					   post => post.MatchesFilter(request),
					   user,
					   posts);
		}

		public bool Matches(
			GetAllPostsForUserQueryRequest request,
			User user,
			ICollection<Post> posts,
			ISortEnumTermTransformer<Post> termTransformer)
		{
			return response.Response.MatchesFull(
					   request,
					   (response, post) => response.MatchesWithoutUser(request, post),
					   post => post.MatchesFilter(request),
					   user,
					   posts,
					   termTransformer);
		}
	}

	extension(Post post)
	{
		public bool Matches(AddPostCommandRequest request)
		{
			return post.Id.Id.IsNotNullOrEmptyOrWhiteSpace() &&
				   post.UserId.Matches(request.UserId) &&
				   post.Title == request.Title &&
				   post.Content == request.Content &&
				   post.Summary.Matches(post.GetSummary(request)) &&
				   post.CreatedAtUtc != default &&
				   post.UpdatedAtUtc != default;
		}

		public bool Matches(UpdatePostCommandRequest request)
		{
			return post.Id.Matches(request.Id) &&
				   post.UserId.Matches(request.UserId) &&
				   post.Title == request.Title &&
				   post.Content == request.Content &&
				   post.Summary.Matches(post.GetSummary(request)) &&
				   post.CreatedAtUtc != default &&
				   post.UpdatedAtUtc != default;
		}

		public bool MatchesFilter(GetAllPostsQueryRequest request)
		{
			return post.User.MatchesFilter(request) &&
				   post.Title.StartsWithOrdinalIgnoreCase(request.Title);
		}

		public bool MatchesFilter(GetAllPostsForUserQueryRequest request)
		{
			return post.UserId.Matches(request.UserId) &&
				   post.Title.StartsWithOrdinalIgnoreCase(request.Title);
		}
	}

	extension(User? u)
	{
		public bool MatchesFilter(GetAllPostsQueryRequest request)
		{
			return u != null &&
				   u.Name.Value.StartsWithOrdinalIgnoreCase(request.UserName);
		}
	}

	extension(PostImage postImage)
	{
		public bool Matches(AddPostCommandRequest request)
		{
			return postImage.Id.Id.Id.IsNotNullOrEmptyOrWhiteSpace() &&
				   postImage.Id.ImageId.IsNotNullOrEmptyOrWhiteSpace() &&
				   postImage.Url.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   postImage.CreatedAtUtc != default;
		}
	}

	extension(ICollection<PostImage> postImages)
	{
		public bool Matches(AddPostCommandRequest request)
		{
			return postImages.AllAndEmpty(request.Images, postImage => postImage.Matches(request));
		}
	}

	extension(PostIdCommandResponse response)
	{
		public bool Matches(PostId id)
		{
			return id.Matches(response.Id);
		}
	}

	extension(PostQueryResponse? response)
	{
		public bool MatchesFull<TRequest>(TRequest request, Post? post)
		where TRequest : ICurrentUserableQueryRequest
		{
			return response != null &&
				   post != null &&
				   post.Id.Matches(response.Id) &&
				   post.UserId.Matches(response.UserId) &&
				   post.Title == response.Title &&
				   post.Content == response.Content &&
				   post.Summary.Matches(response.Summary) &&
				   response.PostImages.MatchesFull(post.PostImages) &&
				   response.IsLikedByCurrentUser == post.PostLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)) &&
				   post.CreatedAtUtc == response.CreatedAtUtc &&
				   post.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.User.MatchesFull(post.User);
		}

		public bool MatchesWithoutUser<TRequest>(TRequest request, Post? post)
			where TRequest : ICurrentUserableQueryRequest
		{
			return response != null &&
				   post != null &&
				   post.Id.Matches(response.Id) &&
				   post.UserId.Matches(response.UserId) &&
				   post.Title == response.Title &&
				   post.Content == response.Content &&
				   post.Summary.Matches(response.Summary) &&
				   response.PostImages.MatchesFull(post.PostImages) &&
				   response.IsLikedByCurrentUser == post.PostLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)) &&
				   post.CreatedAtUtc == response.CreatedAtUtc &&
				   post.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.User == null;
		}
	}

	extension(PostCollectionQueryResponse response)
	{
		public bool MatchesFull<TRequest>(
		TRequest request,
		Func<PostQueryResponse, Post, bool> matches,
		Func<Post, bool> matchesFilter,
		User user,
		ICollection<Post> posts)
		where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, posts.Count(matchesFilter)) &&
				   response.User.MatchesFull(user) &&
				   response.Posts.MatchesCollection(request,
													posts,
													response => new(response.Id),
													post => post.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesFull<TRequest>(
			TRequest request,
			Func<PostQueryResponse, Post, bool> matches,
			Func<Post, bool> matchesFilter,
			User user,
			ICollection<Post> posts,
			ISortEnumTermTransformer<Post> termTransformer)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, posts.Count(matchesFilter)) &&
				   response.User.MatchesFull(user) &&
				   response.Posts.MatchesSortedCollection(request,
														  posts,
														  matches,
														  termTransformer,
														  matchesFilter);
		}

		public bool MatchesWithoutUser<TRequest>(
			TRequest request,
			Func<PostQueryResponse, Post, bool> matches,
			Func<Post, bool> matchesFilter,
			ICollection<Post> posts)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, posts.Count(matchesFilter)) &&
				   response.User == null &&
				   response.Posts.MatchesCollection(request,
													posts,
													response => new(response.Id),
													post => post.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesWithoutUser<TRequest>(
			TRequest request,
			Func<PostQueryResponse, Post, bool> matches,
			Func<Post, bool> matchesFilter,
			ICollection<Post> posts,
			ISortEnumTermTransformer<Post> termTransformer)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			return response.MatchesCollectionResponse(request, posts.Count(matchesFilter)) &&
				   response.User == null &&
				   response.Posts.MatchesSortedCollection(request,
														  posts,
														  matches,
														  termTransformer,
														  matchesFilter);
		}
	}
}
