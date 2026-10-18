using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Domain.Features.Requests.Abstractions;
using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Events.Features.PostImages;
using InstaConnect.Posts.Events.Features.Posts;

namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;

public static class PostEquals
{
	extension(PostId response)
	{
		public bool Matches(
		AddPostCommand command,
		Post post)
		{
			return response.Matches(post.Id);
		}

		public bool Matches(
		UpdatePostCommand command,
		Post post)
		{
			return response.Matches(post.Id);
		}
	}

	extension(Post p)
	{
		public bool Matches(AddPostCommand command)
		{
			return p.Id.Id.IsNotNullOrEmptyOrWhiteSpace() &&
				   p.UserId.Matches(command.UserId) &&
				   p.Title == command.Title &&
				   p.Content == command.Content &&
				   p.CreatedAtUtc != default &&
				   p.UpdatedAtUtc != default;
		}

		public bool Matches(UpdatePostCommand command)
		{
			return p.Id.Matches(command.Id) &&
				   p.UserId.Matches(command.UserId) &&
				   p.Title == command.Title &&
				   p.Content == command.Content &&
				   p.CreatedAtUtc != default &&
				   p.UpdatedAtUtc != default;
		}

		public bool Matches(DeletePostCommand command)
		{
			return p.Id.Matches(command.Id) &&
				   p.UserId.Matches(command.UserId) &&
				   p.Title.IsNotNullOrEmptyOrWhiteSpace() &&
				   p.Content.IsNotNullOrEmptyOrWhiteSpace() &&
				   p.CreatedAtUtc != default &&
				   p.UpdatedAtUtc != default;
		}

		public bool MatchesFilter(PostsFilterQuery query)
		{
			return p.User.MatchesFilter(query) &&
				   p.Title.StartsWithOrdinalIgnoreCase(query.Title);
		}

		public bool MatchesFilter(PostsForUserFilterQuery query)
		{
			return p.UserId.Matches(query.UserId) &&
				   p.Title.StartsWithOrdinalIgnoreCase(query.Title);
		}
	}

	extension(User? u)
	{
		public bool MatchesFilter(PostsFilterQuery query)
		{
			return u != null &&
				   u.Name.Value.StartsWithOrdinalIgnoreCase(query.UserName.Value);
		}
	}

	extension(Url p)
	{
		public bool Matches(AddPostCommand command)
		{
			return command.Images.SingleOrDefault(image => p.Value.EqualsOrdinalIgnoreCase(image.GetUrl())) != null;
		}
	}

	extension(ICollection<Url> p)
	{
		public bool Matches(AddPostCommand command)
		{
			return p.AllAndNotEmpty(u => u.Matches(command));
		}

	}

	extension(PostImage p)
	{
		public bool Matches(AddPostCommand command)
		{
			return p.Id.Id.Id.IsNotNullOrEmptyOrWhiteSpace() &&
				   p.Id.ImageId.IsNotNullOrEmptyOrWhiteSpace() &&
				   p.Url.Matches(command) &&
				   p.CreatedAtUtc != default;
		}
	}

	extension(ICollection<PostImage> p)
	{
		public bool Matches(AddPostCommand command)
		{
			return p.AllAndNotEmpty(pi => pi.Matches(command));
		}
	}

	extension(PostAddedEventRequest p)
	{
		public bool Matches(AddPostCommand command, Post post)
		{
			return p.Post.Matches(command, post);
		}
	}

	extension(PostUpdatedEventRequest p)
	{
		public bool Matches(UpdatePostCommand command, Post post)
		{
			return p.Post.Matches(command, post);
		}
	}

	extension(PostDeletedEventRequest p)
	{
		public bool Matches(DeletePostCommand command, Post post)
		{
			return p.Post.Matches(command, post);
		}
	}

	extension(PostEventRequest request)
	{
		public bool Matches(AddPostCommand command, Post? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(entity.Id.Id) &&
				   request.UserId.EqualsOrdinalIgnoreCase(command.UserId.Id) &&
				   request.User.Matches(command, entity.User) &&
				   request.PostImages.Matches(command, entity.PostImages) &&
				   request.Title == command.Title &&
				   request.Content == command.Content &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(UpdatePostCommand command, Post? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.Id) &&
				   request.UserId.EqualsOrdinalIgnoreCase(command.UserId.Id) &&
				   request.User.Matches(command, entity.User) &&
				   request.PostImages.Matches(command, entity.PostImages) &&
				   request.Title == command.Title &&
				   request.Content == command.Content &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(DeletePostCommand command, Post? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(command.Id.Id) &&
				   request.UserId.EqualsOrdinalIgnoreCase(command.UserId.Id) &&
				   request.User.Matches(command, entity.User) &&
				   request.PostImages.Matches(command, entity.PostImages) &&
				   request.Title == entity.Title &&
				   request.Content == entity.Content &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
	}

	extension(PostImageEventRequest r)
	{
		public bool Matches(AddPostCommand command, PostImage? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(entity.Id.Id.Id) &&
				   r.ImageId.EqualsOrdinalIgnoreCase(entity.Id.ImageId) &&
				   command.Images.SingleOrDefault(image => r.Url.EqualsOrdinalIgnoreCase(image.GetUrl())) != null &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(UpdatePostCommand command, PostImage? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(command.Id.Id) &&
				   r.ImageId.EqualsOrdinalIgnoreCase(entity.Id.ImageId) &&
				   r.Url.EqualsOrdinalIgnoreCase(entity.Url.Value) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}

		public bool Matches(DeletePostCommand command, PostImage? entity)
		{
			return entity != null &&
				   r.Id.EqualsOrdinalIgnoreCase(command.Id.Id) &&
				   r.ImageId.EqualsOrdinalIgnoreCase(entity.Id.ImageId) &&
				   r.Url.EqualsOrdinalIgnoreCase(entity.Url.Value) &&
				   r.CreatedAtUtc == entity.CreatedAtUtc;
		}
	}

	extension(ICollection<PostImageEventRequest> r)
	{
		public bool Matches(AddPostCommand command, ICollection<PostImage> entities)
		{
			return command.Images.IsEmpty() ||
				   r.MatchesCollection(
				       entities,
				       response => new(new(response.Id), response.ImageId),
				       postImage => postImage.Id,
				       (r, postImage) => r.Matches(command, postImage));
		}

		public bool Matches(UpdatePostCommand command, ICollection<PostImage> entities)
		{
			return r.MatchesCollection(
				entities,
				response => new(new(response.Id), response.ImageId),
				postImage => postImage.Id,
				(r, postImage) => r.Matches(command, postImage));
		}

		public bool Matches(DeletePostCommand command, ICollection<PostImage> entities)
		{
			return r.MatchesCollection(
				entities,
				response => new(new(response.Id), response.ImageId),
				postImage => postImage.Id,
				(r, postImage) => r.Matches(command, postImage));
		}
	}

	extension(UserEventRequest request)
	{
		public bool Matches(AddPostCommand command, User? entity)
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

		public bool Matches(UpdatePostCommand command, User? entity)
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

		public bool Matches(DeletePostCommand command, User? entity)
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
	}

	extension(PostResponse? response)
	{
		public bool MatchesFull<TQuery>(TQuery request, Post? post)
		where TQuery : ICurrentUserableQuery
		{
			return response != null &&
				   post != null &&
				   post.Id.Matches(response.Id) &&
				   post.UserId.Matches(response.UserId) &&
				   post.Title == response.Title &&
				   post.Content == response.Content &&
				   response.PostImages.MatchesFull(post.PostImages) &&
				   response.IsLikedByCurrentUser == post.PostLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUser.Id)) &&
				   post.CreatedAtUtc == response.CreatedAtUtc &&
				   post.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.User.MatchesFull(post.User);
		}

		public bool MatchesWithoutUser<TQuery>(TQuery request, Post? post)
			where TQuery : ICurrentUserableQuery
		{
			return response != null &&
				   post != null &&
				   post.Id.Matches(response.Id) &&
				   post.UserId.Matches(response.UserId) &&
				   post.Title == response.Title &&
				   post.Content == response.Content &&
				   response.PostImages.MatchesFull(post.PostImages) &&
				   response.IsLikedByCurrentUser == post.PostLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUser.Id)) &&
				   post.CreatedAtUtc == response.CreatedAtUtc &&
				   post.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.User == null;
		}

		public bool Matches(GetPostByIdQuery query, Post post)
		{
			return response.MatchesFull(query, post);
		}
	}

	extension(PostAnalyzeResponse response)
	{
		public bool Matches(AnalyzePostByIdQuery query, Post post)
		{
			return response != null &&
				   post != null &&
				   post.Id.Matches(response.Id) &&
				   post.UserId.Matches(response.UserId) &&
				   post.Title == response.Title &&
				   post.Content == response.Content &&
				   response.PostImages.MatchesFull(post.PostImages) &&
				   response.IsLikedByCurrentUser == post.PostLikes.Any(pl => pl.Id.UserId.Matches(query.CurrentUser.Id)) &&
				   response.Summary == post.GetAnalysisSummary() &&
				   post.CreatedAtUtc == response.CreatedAtUtc &&
				   post.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.User.MatchesFull(post.User);
		}
	}

	extension(PostCollectionResponse response)
	{
		public bool MatchesFull<TQuery>(
		TQuery request,
		Func<PostResponse, Post, bool> matches,
		Func<Post, bool> matchesFilter,
		User user,
		ICollection<Post> posts)
		where TQuery : ICurrentUserableQuery, IPaginatableQuery<PostsPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, posts.Count(matchesFilter)) &&
				   response.User.MatchesFull(user) &&
				   response.Posts.MatchesCollection(request.Pagination,
													posts,
													response => response.Id,
													post => post.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesFull<TQuery>(
			TQuery request,
			Func<PostResponse, Post, bool> matches,
			Func<Post, bool> matchesFilter,
			User user,
			ICollection<Post> posts,
			ISortEnumTermTransformer<Post> termTransformer)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<PostsPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, posts.Count(matchesFilter)) &&
				   response.User.MatchesFull(user) &&
				   response.Posts.MatchesSortedCollection(request.Pagination,
														  posts,
														  matches,
														  termTransformer,
														  matchesFilter);
		}

		public bool MatchesWithoutUser<TQuery>(
			TQuery request,
			Func<PostResponse, Post, bool> matches,
			Func<Post, bool> matchesFilter,
			ICollection<Post> posts)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<PostsPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, posts.Count(matchesFilter)) &&
				   response.User == null &&
				   response.Posts.MatchesCollection(request.Pagination,
													posts,
													response => response.Id,
													post => post.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesWithoutUser<TQuery>(
			TQuery request,
			Func<PostResponse, Post, bool> matches,
			Func<Post, bool> matchesFilter,
			ICollection<Post> posts,
			ISortEnumTermTransformer<Post> termTransformer)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<PostsPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, posts.Count(matchesFilter)) &&
				   response.User == null &&
				   response.Posts.MatchesSortedCollection(request.Pagination,
														  posts,
														  matches,
														  termTransformer,
														  matchesFilter);
		}

		public bool Matches(
		GetAllPostsQuery query,
		ICollection<Post> posts)
		{
			return response.MatchesWithoutUser(
					   query,
					   (response, post) => response.MatchesFull(query, post),
					   post => post.MatchesFilter(query.Filter),
					   posts);
		}

		public bool Matches(
			GetAllPostsQuery query,
			ICollection<Post> posts,
			ISortEnumTermTransformer<Post> termTransformer)
		{
			return response.MatchesWithoutUser(
					   query,
					   (response, post) => response.MatchesFull(query, post),
					   post => post.MatchesFilter(query.Filter),
					   posts,
					   termTransformer);
		}

		public bool Matches(
		GetAllPostsForUserQuery query,
		User user,
		ICollection<Post> posts)
		{
			return response.MatchesFull(
					   query,
					   (response, post) => response.MatchesWithoutUser(query, post),
					   post => post.MatchesFilter(query.Filter),
					   user,
					   posts);
		}

		public bool Matches(
			GetAllPostsForUserQuery query,
			User user,
			ICollection<Post> posts,
			ISortEnumTermTransformer<Post> termTransformer)
		{
			return response.MatchesFull(
					   query,
					   (response, post) => response.MatchesWithoutUser(query, post),
					   post => post.MatchesFilter(query.Filter),
					   user,
					   posts,
					   termTransformer);
		}
	}
}
