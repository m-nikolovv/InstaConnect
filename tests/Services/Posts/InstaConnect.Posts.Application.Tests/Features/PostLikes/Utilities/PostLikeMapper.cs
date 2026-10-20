using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;

public static class PostLikeMapper
{
	extension(PostLike postLike)
	{
		internal PostLikeResponse ToFullResponse<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableQueryRequest
		{
			return new(postLike.Id,
					   postLike.User?.ToFullResponse(),
					   postLike.Post?.ToFullResponse(request),
					   postLike.CreatedAtUtc);
		}

		internal PostLikeResponse ToResponseWithoutUser<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableQueryRequest
		{
			return new(postLike.Id,
					   null,
					   postLike.Post?.ToFullResponse(request),
					   postLike.CreatedAtUtc);
		}

		internal PostLikeResponse ToResponseWithoutPost()
		{
			return new(postLike.Id,
					   postLike.User?.ToFullResponse(),
					   null,
					   postLike.CreatedAtUtc);
		}

		public PostLikeId ToResponse(
			AddPostLikeCommandRequest request)
		{
			return postLike.ToId();
		}

		public PostLikeResponse ToResponse(
			GetPostLikeByIdQueryRequest request)
		{
			return postLike.ToFullResponse(request);
		}
	}

	extension(ICollection<PostLike> postLikes)
	{
		internal PostLikeCollectionResponse ToResponseWithoutUser<TRequest>(
		TRequest request,
		Post post,
		Func<TRequest, PostLike, bool> filter,
		Func<TRequest, PostLike, PostLikeResponse> transform)
		where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			var paginator = new Paginator();
			var totalCount = postLikes.Count(postLike => filter(request, postLike));

			return new(post?.ToFullResponse(request),
					   null,
					   postLikes.Filter(request, postLike => filter(request, postLike), postLike => transform(request, postLike)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		internal PostLikeCollectionResponse ToResponseWithoutPost<TRequest>(
			TRequest request,
			User user,
			Func<TRequest, PostLike, bool> filter,
			Func<TRequest, PostLike, PostLikeResponse> transform)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			var paginator = new Paginator();
			var totalCount = postLikes.Count(postLike => filter(request, postLike));

			return new(null,
					   user.ToFullResponse(),
					   postLikes.Filter(request, postLike => filter(request, postLike), postLike => transform(request, postLike)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		public PostLikeCollectionResponse ToResponse(
			GetAllPostLikesQueryRequest request,
			Post post)
		{
			return postLikes.ToResponseWithoutUser(
				request,
				post,
				(request, postLike) => postLike.MatchesFilter(request),
				(request, postLike) => postLike.ToResponseWithoutPost());
		}

		public PostLikeCollectionResponse ToResponse(
			GetAllPostLikesForUserQueryRequest request,
			User user)
		{
			return postLikes.ToResponseWithoutPost(
				request,
				user,
				(request, postLike) => postLike.MatchesFilter(request),
				(request, postLike) => postLike.ToResponseWithoutUser(request));
		}
	}
}
