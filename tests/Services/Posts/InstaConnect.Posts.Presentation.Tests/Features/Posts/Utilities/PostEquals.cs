using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Presentation.Features.Requests.Abstractions;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Events.Features.PostImages;
using InstaConnect.Posts.Events.Features.Posts;
using InstaConnect.Posts.Presentation.Features.Users.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostImages.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Posts.Extensions;
using InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;

public static class PostEquals
{
	extension(PostAddedEventRequest r)
	{
		public bool Matches(AddPostApiRequest request, Post entity)
		{
			return r.Post.Matches(request, entity);
		}
	}

	extension(PostUpdatedEventRequest r)
	{
		public bool Matches(UpdatePostApiRequest request, Post entity)
		{
			return r.Post.Matches(request, entity);
		}
	}

	extension(PostDeletedEventRequest r)
	{
		public bool Matches(DeletePostApiRequest request, Post entity)
		{
			return r.Post.Matches(request, entity);
		}
	}

	extension(PostEventRequest r)
	{
		public bool Matches(AddPostApiRequest request, Post? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(entity.Id.Id) &&
				   r.UserId.EqualsOrdinalIgnoreCase(request.UserId) &&
				   r.User.Matches(request, entity.User) &&
				   r.PostImages.Matches(request, entity.PostImages) &&
				   r.Title == request.Form.Title &&
				   r.Content == request.Form.Content &&
				   r.Summary == entity.GetSummary(request) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(UpdatePostApiRequest request, Post? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.UserId.EqualsOrdinalIgnoreCase(request.UserId) &&
				   r.User.Matches(request, entity.User) &&
				   r.PostImages.Matches(request, entity.PostImages) &&
				   r.Title == request.Body.Title &&
				   r.Content == request.Body.Content &&
				   r.Summary == entity.GetSummary(request) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc &&
				   r.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(DeletePostApiRequest request, Post? entity)
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
		public bool Matches(AddPostApiRequest request, User? entity)
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

		public bool Matches(UpdatePostApiRequest request, User? entity)
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

		public bool Matches(DeletePostApiRequest request, User? entity)
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
		public bool Matches(AddPostApiRequest request, PostImage? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(entity.Id.Id.Id) &&
				   r.ImageId.EqualsOrdinalIgnoreCase(entity.Id.ImageId) &&
				   request.Form.Images.ContainsUrl(r.Url) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(UpdatePostApiRequest request, PostImage? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(request.Id) &&
				   r.ImageId.EqualsOrdinalIgnoreCase(entity.Id.ImageId) &&
				   r.Url.EqualsOrdinalIgnoreCase(entity.Url.Value) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(DeletePostApiRequest request, PostImage? entity)
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
		public bool Matches(AddPostApiRequest request, ICollection<PostImage> entities)
		{
			return request.Form.Images.IsEmpty() ||
				   r.MatchesCollection(
				       entities,
				       response => new(new(response.Id), response.ImageId),
				       postImage => postImage.Id,
				       (r, postImage) => r.Matches(request, postImage));
		}

		public bool Matches(UpdatePostApiRequest request, ICollection<PostImage> entities)
		{
			return r.MatchesCollection(
				entities,
				response => new(new(response.Id), response.ImageId),
				postImage => postImage.Id,
				(r, postImage) => r.Matches(request, postImage));
		}

		public bool Matches(DeletePostApiRequest request, ICollection<PostImage> entities)
		{
			return r.MatchesCollection(
				entities,
				response => new(new(response.Id), response.ImageId),
				postImage => postImage.Id,
				(r, postImage) => r.Matches(request, postImage));
		}
	}

	extension(GetAllPostsQueryRequest query)
	{
		public bool Matches(GetAllPostsApiRequest request)
		{
			return query.MatchesFilter(request) &&
				   query.MatchesSortable<GetAllPostsQueryRequest, PostsSortTerm, GetAllPostsApiRequest>(request) &&
				   query.MatchesPaginatable(request) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool MatchesFilter(GetAllPostsApiRequest request)
		{
			return query.UserName == request.UserName &&
				   query.Title == request.Title;
		}
	}

	extension(GetAllPostsForUserQueryRequest query)
	{
		public bool Matches(GetAllPostsForUserApiRequest request)
		{
			return query.MatchesFilter(request) &&
				   query.MatchesSortable<GetAllPostsForUserQueryRequest, PostsForUserSortTerm, GetAllPostsForUserApiRequest>(request) &&
				   query.MatchesPaginatable(request) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool MatchesFilter(GetAllPostsForUserApiRequest request)
		{
			return query.UserId == request.UserId &&
				   query.Title == request.Title;
		}
	}

	extension(GetPostByIdQueryRequest query)
	{
		public bool Matches(GetPostByIdApiRequest request)
		{
			return query.Id == request.Id &&
				   query.MatchesCurrentUserable(request);
		}
	}

	extension(AddPostCommandRequest command)
	{
		public bool Matches(AddPostApiRequest request)
		{
			return command.Title == request.Form.Title &&
				   command.Content == request.Form.Content &&
				   command.UserId == request.UserId &&
				   command.Images == request.Form.Images;
		}
	}

	extension(UpdatePostCommandRequest command)
	{
		public bool Matches(UpdatePostApiRequest request)
		{
			return command.Id == request.Id &&
				   command.Title == request.Body.Title &&
				   command.Content == request.Body.Content &&
				   command.UserId == request.UserId;
		}
	}

	extension(DeletePostCommandRequest command)
	{
		public bool Matches(DeletePostApiRequest request)
		{
			return command.Id == request.Id &&
				   command.UserId == request.UserId;
		}
	}

	extension(AddPostApiResponse response)
	{
		public bool Matches(
		AddPostApiRequest request,
		Post post)
		{
			return response.Response.Matches(post.Id);
		}
	}

	extension(UpdatePostApiResponse response)
	{
		public bool Matches(
		UpdatePostApiRequest request,
		Post post)
		{
			return response.Response.Matches(post.Id);
		}
	}

	extension(GetPostByIdApiResponse response)
	{
		public bool Matches(GetPostByIdApiRequest request, Post post)
		{
			return response.Response.MatchesFull(request, post);
		}
	}

	extension(GetAllPostsApiResponse response)
	{
		public bool Matches(
		GetAllPostsApiRequest request,
		ICollection<Post> posts)
		{
			return response.Response.MatchesWithoutUser(
					   request,
					   (response, post) => response.MatchesFull(request, post),
					   post => post.MatchesFilter(request),
					   posts);
		}

		public bool Matches(
			GetAllPostsApiRequest request,
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

	extension(GetAllPostsForUserApiResponse response)
	{
		public bool Matches(
		GetAllPostsForUserApiRequest request,
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
			GetAllPostsForUserApiRequest request,
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
		public bool Matches(AddPostApiRequest request)
		{
			return post.Id.Id.IsNotNullOrEmptyOrWhiteSpace() &&
				   post.UserId.Matches(request.UserId) &&
				   post.Title == request.Form.Title &&
				   post.Content == request.Form.Content &&
				   post.Summary.Matches(post.GetSummary(request)) &&
				   post.CreatedAtUtc != default &&
				   post.UpdatedAtUtc != default;
		}

		public bool Matches(UpdatePostApiRequest request)
		{
			return post.Id.Matches(request.Id) &&
				   post.UserId.Matches(request.UserId) &&
				   post.Title == request.Body.Title &&
				   post.Content == request.Body.Content &&
				   post.Summary.Matches(post.GetSummary(request)) &&
				   post.CreatedAtUtc != default &&
				   post.UpdatedAtUtc != default;
		}

		public bool MatchesFilter(GetAllPostsApiRequest request)
		{
			return post.User.MatchesFilter(request) &&
				   post.Title.StartsWithOrdinalIgnoreCase(request.Title);
		}

		public bool MatchesFilter(GetAllPostsForUserApiRequest request)
		{
			return post.UserId.Matches(request.UserId) &&
				   post.Title.StartsWithOrdinalIgnoreCase(request.Title);
		}
	}

	extension(PostImage postImage)
	{
		public bool Matches(AddPostApiRequest request)
		{
			return postImage.Id.Id.Id.IsNotNullOrEmptyOrWhiteSpace() &&
				   postImage.Id.ImageId.IsNotNullOrEmptyOrWhiteSpace() &&
				   postImage.Url.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   postImage.CreatedAtUtc != default;
		}
	}

	extension(ICollection<PostImage> postImages)
	{
		public bool Matches(AddPostApiRequest request)
		{
			return postImages.AllAndNotEmpty(postImage => postImage.Matches(request));
		}
	}

	extension(User? u)
	{
		public bool MatchesFilter(GetAllPostsApiRequest request)
		{
			return u != null &&
				   u.Name.Value.StartsWithOrdinalIgnoreCase(request.UserName);
		}
	}

	extension(PostIdApiResponse response)
	{
		public bool Matches(PostId id)
		{
			return id.Matches(response.Id);
		}
	}

	extension(PostApiResponse? response)
	{
		public bool MatchesFull<TRequest>(TRequest request, Post? post)
		where TRequest : ICurrentUserableApiRequest
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
			where TRequest : ICurrentUserableApiRequest
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

	extension(PostCollectionApiResponse response)
	{
		public bool MatchesFull<TRequest>(
		TRequest request,
		Func<PostApiResponse, Post, bool> matches,
		Func<Post, bool> matchesFilter,
		User user,
		ICollection<Post> posts)
		where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
			Func<PostApiResponse, Post, bool> matches,
			Func<Post, bool> matchesFilter,
			User user,
			ICollection<Post> posts,
			ISortEnumTermTransformer<Post> termTransformer)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
			Func<PostApiResponse, Post, bool> matches,
			Func<Post, bool> matchesFilter,
			ICollection<Post> posts)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
			Func<PostApiResponse, Post, bool> matches,
			Func<Post, bool> matchesFilter,
			ICollection<Post> posts,
			ISortEnumTermTransformer<Post> termTransformer)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
