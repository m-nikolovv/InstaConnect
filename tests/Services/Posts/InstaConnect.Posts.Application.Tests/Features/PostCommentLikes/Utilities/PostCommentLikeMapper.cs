using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeMapper
{
	extension(PostCommentLike postCommentLike)
	{
		internal PostCommentLikeResponse ToFullResponse<TRequest>(TRequest request)
			where TRequest : ICurrentUserableQueryRequest
		{
			return new(postCommentLike.Id,
					   postCommentLike.User?.ToFullResponse(),
					   postCommentLike.PostComment?.ToFullResponse(request),
					   postCommentLike.CreatedAtUtc);
		}

		internal PostCommentLikeResponse ToResponseWithoutUser<TRequest>(TRequest request)
			where TRequest : ICurrentUserableQueryRequest
		{
			return new(postCommentLike.Id,
					   null,
					   postCommentLike.PostComment?.ToFullResponse(request),
					   postCommentLike.CreatedAtUtc);
		}

		internal PostCommentLikeResponse ToResponseWithoutPostComment()
		{
			return new(postCommentLike.Id,
					   postCommentLike.User?.ToFullResponse(),
					   null,
					   postCommentLike.CreatedAtUtc);
		}

		public PostCommentLikeId ToResponse(AddPostCommentLikeCommandRequest request)
		{
			return postCommentLike.ToId();
		}

		public PostCommentLikeResponse ToResponse(GetPostCommentLikeByIdQueryRequest request)
		{
			return postCommentLike.ToFullResponse(request);
		}
	}

	extension(ICollection<PostCommentLike> postCommentLikes)
	{
		internal PostCommentLikeCollectionResponse ToResponseWithoutUser<TRequest>(
			TRequest request,
			PostComment postComment,
			Func<TRequest, PostCommentLike, bool> filter,
			Func<TRequest, PostCommentLike, PostCommentLikeResponse> transform)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			var paginator = new Paginator();
			var totalCount = postCommentLikes.Count(postCommentLike => filter(request, postCommentLike));

			return new(postComment.ToFullResponse(request),
					   null,
					   postCommentLikes.Filter(request, postCommentLike => filter(request, postCommentLike), postCommentLike => transform(request, postCommentLike)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		internal PostCommentLikeCollectionResponse ToResponseWithoutPostComment<TRequest>(
			TRequest request,
			User user,
			Func<TRequest, PostCommentLike, bool> filter,
			Func<TRequest, PostCommentLike, PostCommentLikeResponse> transform)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			var paginator = new Paginator();
			var totalCount = postCommentLikes.Count(postCommentLike => filter(request, postCommentLike));

			return new(null,
					   user.ToFullResponse(),
					   postCommentLikes.Filter(request, postCommentLike => filter(request, postCommentLike), postCommentLike => transform(request, postCommentLike)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		public PostCommentLikeCollectionResponse ToResponse(
			GetAllPostCommentLikesQueryRequest request,
			PostComment postComment)
		{
			return postCommentLikes.ToResponseWithoutUser(
														  request,
														  postComment,
														  (request, postCommentLike) => postCommentLike.MatchesFilter(request),
														  (request, postCommentLike) => postCommentLike.ToResponseWithoutPostComment());
		}

		public PostCommentLikeCollectionResponse ToResponse(
			GetAllPostCommentLikesForUserQueryRequest request,
			User user)
		{
			return postCommentLikes.ToResponseWithoutPostComment(
																 request,
																 user,
																 (request, postCommentLike) => postCommentLike.MatchesFilter(request),
																 (request, postCommentLike) => postCommentLike.ToResponseWithoutUser(request));
		}
	}
}
