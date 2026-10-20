using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Application.Features.Posts.Models;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Presentation.Tests.Features.PostImages.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;

public static class PostMapper
{
	extension(Post post)
	{
		internal PostIdCommandResponse ToIdCommandResponse(
)
		{
			return new(post.Id.Id);
		}

		internal PostQueryResponse ToFullQueryResponse<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableApiRequest
		{
			return new(post.Id.Id,
					   post.UserId.Id,
					   post.Title,
					   post.Content,
					   post.Summary.Value,
					   post.User?.ToFullQueryResponse(),
					   post.PostImages.ToFullQueryResponse(),
					   post.PostLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)),
					   post.CreatedAtUtc,
					   post.UpdatedAtUtc);
		}

		internal PostQueryResponse ToQueryResponseWithoutUser<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableApiRequest
		{
			return new(post.Id.Id,
					   post.UserId.Id,
					   post.Title,
					   post.Content,
					   post.Summary.Value,
					   null,
					   post.PostImages.ToFullQueryResponse(),
					   post.PostLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)),
					   post.CreatedAtUtc,
					   post.UpdatedAtUtc);
		}

		public AddPostCommandResponse ToResponse(
			AddPostApiRequest request)
		{
			return new(post.ToIdCommandResponse());
		}

		public UpdatePostCommandResponse ToResponse(
			UpdatePostApiRequest request)
		{
			return new(post.ToIdCommandResponse());
		}

		public GetPostByIdQueryResponse ToResponse(
			GetPostByIdApiRequest request)
		{
			return new(post.ToFullQueryResponse(request));
		}
	}

	extension(ICollection<Post> posts)
	{
		internal PostCollectionQueryResponse ToFullQueryResponse<TRequest>(
		TRequest request,
		User user,
		Func<TRequest, Post, bool> filter,
		Func<TRequest, Post, PostQueryResponse> transform)
		where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			var paginator = new Paginator();
			var totalCount = posts.Count(post => filter(request, post));

			return new(user.ToFullQueryResponse(),
						posts.Filter(request, post => filter(request, post), post => transform(request, post)),
						request.Page,
						request.PageSize,
						totalCount,
						paginator.HasNextPage(request.Page, request.PageSize, totalCount),
						paginator.HasPreviousPage(request.Page));
		}

		internal PostCollectionQueryResponse ToQueryResponseWithoutUser<TRequest>(
			TRequest request,
			Func<TRequest, Post, bool> filter,
			Func<TRequest, Post, PostQueryResponse> transform)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			var paginator = new Paginator();
			var totalCount = posts.Count(post => filter(request, post));

			return new(null,
					   posts.Filter(request, post => filter(request, post), post => transform(request, post)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		public GetAllPostsQueryResponse ToResponse(
			GetAllPostsApiRequest request)
		{
			return new(posts.ToQueryResponseWithoutUser(
												   request,
												   (request, post) => post.MatchesFilter(request),
												   (request, post) => post.ToFullQueryResponse(request)));
		}

		public GetAllPostsForUserQueryResponse ToResponse(
			GetAllPostsForUserApiRequest request,
			User user)
		{
			return new(posts.ToFullQueryResponse(
											request,
											user,
											(request, post) => post.MatchesFilter(request),
											(request, post) => post.ToQueryResponseWithoutUser(request)));
		}
	}
}
