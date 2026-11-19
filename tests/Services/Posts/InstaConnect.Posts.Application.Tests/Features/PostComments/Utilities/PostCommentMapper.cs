using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Responses;
using InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;

public static class PostCommentMapper
{
	extension(PostComment postComment)
	{
		public PostCommentId ToResponse(
			AddPostCommentCommandRequest request)
		{
			return postComment.ToId();
		}

		public PostCommentId ToResponse(
			UpdatePostCommentCommandRequest request)
		{
			return postComment.ToId();
		}

		public PostCommentResponse ToResponse(
			GetPostCommentByIdQueryRequest request)
		{
			return postComment.ToFullResponse(request.CurrentUserId);
		}
	}

	extension(ICollection<PostComment> postComments)
	{
		internal PostCommentCollectionResponse ToResponseWithoutUser<TRequest>(
		TRequest request,
		Post post,
		Func<TRequest, PostComment, bool> filter,
		Func<TRequest, PostComment, PostCommentResponse> transform)
		where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			var paginator = new Paginator();
			var totalCount = postComments.Count(postComment => filter(request, postComment));

			return new(post.ToFullResponse(request.CurrentUserId),
					   null,
					   postComments.Filter(request, postComment => filter(request, postComment), postComment => transform(request, postComment)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		internal PostCommentCollectionResponse ToResponseWithoutPost<TRequest>(
			TRequest request,
			User user,
			Func<TRequest, PostComment, bool> filter,
			Func<TRequest, PostComment, PostCommentResponse> transform)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			var paginator = new Paginator();
			var totalCount = postComments.Count(postComment => filter(request, postComment));

			return new(null,
					   user.ToFullResponse(),
					   postComments.Filter(request, postComment => filter(request, postComment), postComment => transform(request, postComment)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		public PostCommentCollectionResponse ToResponse(
			GetAllPostCommentsQueryRequest request,
			Post post)
		{
			return postComments.ToResponseWithoutUser(
													  request,
													  post,
													  (request, postComment) => postComment.MatchesFilter(request),
													  (request, postComment) => postComment.ToResponseWithoutPost(request.CurrentUserId));
		}

		public PostCommentCollectionResponse ToResponse(
			GetAllPostCommentsForUserQueryRequest request,
			User user)
		{
			return postComments.ToResponseWithoutPost(
													  request,
													  user,
													  (request, postComment) => postComment.MatchesFilter(request),
													  (request, postComment) => postComment.ToResponseWithoutUser(request.CurrentUserId));
		}
	}
}
