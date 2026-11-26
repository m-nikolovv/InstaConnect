using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
using InstaConnect.Posts.Tests.Features.PostImages.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;

public static class PostMapper
{
	extension(Post post)
	{
		public PostId ToResponse(
			AddPostCommandRequest request)
		{
			return post.ToId();
		}

		public PostId ToResponse(
			UpdatePostCommandRequest request)
		{
			return post.ToId();
		}

		public PostResponse ToResponse(
			GetPostByIdQueryRequest request)
		{
			return post.ToFullResponse(request.CurrentUserId);
		}
	}

	extension(ICollection<Post> posts)
	{
		internal PostCollectionResponse ToFullResponse<TRequest>(
		TRequest request,
		User user,
		Func<TRequest, Post, bool> filter,
		Func<TRequest, Post, PostResponse> transform)
		where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			var paginator = new Paginator();
			var totalCount = posts.Count(post => filter(request, post));

			return new(user.ToFullResponse(),
						posts.Filter(request, post => filter(request, post), post => transform(request, post)),
						request.Page,
						request.PageSize,
						totalCount,
						paginator.HasNextPage(request.Page, request.PageSize, totalCount),
						paginator.HasPreviousPage(request.Page));
		}

		internal PostCollectionResponse ToResponseWithoutUser<TRequest>(
			TRequest request,
			Func<TRequest, Post, bool> filter,
			Func<TRequest, Post, PostResponse> transform)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
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

		public PostCollectionResponse ToResponse(
			GetAllPostsQueryRequest request)
		{
			return posts.ToResponseWithoutUser(
				request,
				(request, post) => post.MatchesFilter(request),
				(request, post) => post.ToFullResponse(request.CurrentUserId));
		}

		public PostCollectionResponse ToResponse(
			GetAllPostsForUserQueryRequest request,
			User user)
		{
			return posts.ToFullResponse(
				request,
				user,
				(request, post) => post.MatchesFilter(request),
				(request, post) => post.ToResponseWithoutUser(request.CurrentUserId));
		}
	}
}
