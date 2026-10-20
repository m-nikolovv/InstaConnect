using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Posts.Application.Features.PostComments.Commands.Add;
using InstaConnect.Posts.Application.Features.PostComments.Commands.Update;
using InstaConnect.Posts.Application.Features.PostComments.Models;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetById;
using InstaConnect.Posts.Presentation.Tests.Features.PostCommentImages.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;

public static class PostCommentMapper
{
	extension(PostComment postComment)
	{
		internal PostCommentIdCommandResponse ToIdCommandResponse(
)
		{
			return new(postComment.Id.Id.Id, postComment.Id.CommentId);
		}

		internal PostCommentQueryResponse ToFullQueryResponse<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableApiRequest
		{
			return new(postComment.Id.Id.Id,
					   postComment.Id.CommentId,
					   postComment.UserId.Id,
					   postComment.Content,
					   postComment.Summary.Value,
					   postComment.User?.ToFullQueryResponse(),
					   postComment.Post?.ToFullQueryResponse(request),
					   postComment.PostCommentImages.ToFullQueryResponse(),
					   postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)),
					   postComment.CreatedAtUtc,
					   postComment.UpdatedAtUtc);
		}

		internal PostCommentQueryResponse ToQueryResponseWithoutUser<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableApiRequest
		{
			return new(postComment.Id.Id.Id,
					   postComment.Id.CommentId,
					   postComment.UserId.Id,
					   postComment.Content,
					   postComment.Summary.Value,
					   null,
					   postComment.Post?.ToFullQueryResponse(request),
					   postComment.PostCommentImages.ToFullQueryResponse(),
					   postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)),
					   postComment.CreatedAtUtc,
					   postComment.UpdatedAtUtc);
		}

		internal PostCommentQueryResponse ToQueryResponseWithoutPost<TRequest>(
			TRequest request)
			where TRequest : ICurrentUserableApiRequest
		{
			return new(postComment.Id.Id.Id,
					   postComment.Id.CommentId,
					   postComment.UserId.Id,
					   postComment.Content,
					   postComment.Summary.Value,
					   postComment.User?.ToFullQueryResponse(),
					   null,
					   postComment.PostCommentImages.ToFullQueryResponse(),
					   postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)),
					   postComment.CreatedAtUtc,
					   postComment.UpdatedAtUtc);
		}

		public AddPostCommentCommandResponse ToResponse(
			AddPostCommentApiRequest request)
		{
			return new(postComment.ToIdCommandResponse());
		}

		public UpdatePostCommentCommandResponse ToResponse(
			UpdatePostCommentApiRequest request)
		{
			return new(postComment.ToIdCommandResponse());
		}

		public GetPostCommentByIdQueryResponse ToResponse(
			GetPostCommentByIdApiRequest request)
		{
			return new(postComment.ToFullQueryResponse(request));
		}
	}

	extension(ICollection<PostComment> postComments)
	{
		internal PostCommentCollectionQueryResponse ToQueryResponseWithoutUser<TRequest>(
		TRequest request,
		Post post,
		Func<TRequest, PostComment, bool> filter,
		Func<TRequest, PostComment, PostCommentQueryResponse> transform)
		where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			var paginator = new Paginator();
			var totalCount = postComments.Count(postComment => filter(request, postComment));

			return new(post.ToFullQueryResponse(request),
					   null,
					   postComments.Filter(request, postComment => filter(request, postComment), postComment => transform(request, postComment)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		internal PostCommentCollectionQueryResponse ToQueryResponseWithoutPost<TRequest>(
			TRequest request,
			User user,
			Func<TRequest, PostComment, bool> filter,
			Func<TRequest, PostComment, PostCommentQueryResponse> transform)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			var paginator = new Paginator();
			var totalCount = postComments.Count(postComment => filter(request, postComment));

			return new(null,
					   user.ToFullQueryResponse(),
					   postComments.Filter(request, postComment => filter(request, postComment), postComment => transform(request, postComment)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		public GetAllPostCommentsQueryResponse ToResponse(
			GetAllPostCommentsApiRequest request,
			Post post)
		{
			return new(postComments.ToQueryResponseWithoutUser(
														  request,
														  post,
														  (request, postComment) => postComment.MatchesFilter(request),
														  (request, postComment) => postComment.ToQueryResponseWithoutPost(request)));
		}

		public GetAllPostCommentsForUserQueryResponse ToResponse(
			GetAllPostCommentsForUserApiRequest request,
			User user)
		{
			return new(postComments.ToQueryResponseWithoutPost(
														  request,
														  user,
														  (request, postComment) => postComment.MatchesFilter(request),
														  (request, postComment) => postComment.ToQueryResponseWithoutUser(request)));
		}
	}
}
