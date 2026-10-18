using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Posts.Application.Features.Users.Abstractions;
using InstaConnect.Posts.Application.Tests.Features.PostImages.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;

public static class PostMapper
{
	extension(Post post)
	{
		internal PostResponse ToFullResponse<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableQueryRequest
		{
			return new(post.Id,
					   post.UserId,
					   post.Title,
					   post.Content,
					   post.User?.ToFullResponse(),
					   post.PostImages.ToFullResponse(),
					   post.PostLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)),
					   post.CreatedAtUtc,
					   post.UpdatedAtUtc);
		}

		internal PostResponse ToResponseWithoutUser<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableQueryRequest
		{
			return new(post.Id,
					   post.UserId,
					   post.Title,
					   post.Content,
					   null,
					   post.PostImages.ToFullResponse(),
					   post.PostLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)),
					   post.CreatedAtUtc,
					   post.UpdatedAtUtc);
		}

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
			return post.ToFullResponse(request);
		}

		public PostAnalyzeResponse ToResponse(
			AnalyzePostByIdQueryRequest request)
		{
			return new(post.Id,
					   post.UserId,
					   post.Title,
					   post.Content,
					   post.User?.ToFullResponse(),
					   post.PostImages.ToFullResponse(),
					   post.PostLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)),
					   post.GetAnalysisSummary(),
					   post.CreatedAtUtc,
					   post.UpdatedAtUtc);
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
				(request, post) => post.ToFullResponse(request));
		}

		public PostCollectionResponse ToResponse(
			GetAllPostsForUserQueryRequest request,
			User user)
		{
			return posts.ToFullResponse(
				request,
				user,
				(request, post) => post.MatchesFilter(request),
				(request, post) => post.ToResponseWithoutUser(request));
		}
	}
}
