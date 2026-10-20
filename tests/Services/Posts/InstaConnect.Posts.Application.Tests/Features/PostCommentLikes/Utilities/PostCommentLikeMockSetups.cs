using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeMockSetups
{
	extension(IPostCommentLikeQueryService commentLikeService)
	{
		public void SetupGetAllAsync(
			GetAllPostCommentLikesQueryRequest request,
			PostComment postComment,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			commentLikeService.SetupGetAllAsync(request.IsGetAllPostCommentLikesQuery(), postCommentLikes.ToResponse(request, postComment), cancellationToken);
		}

		public void SetupGetAllForUserAsync(
			GetAllPostCommentLikesForUserQueryRequest request,
			User user,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			commentLikeService.SetupGetAllForUserAsync(request.IsGetAllPostCommentLikesForUserQuery(), postCommentLikes.ToResponse(request, user), cancellationToken);
		}

		public void SetupGetByIdAsync(
			GetPostCommentLikeByIdQueryRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			commentLikeService.SetupGetByIdAsync(request.IsGetPostCommentLikeByIdQuery(), postCommentLike.ToResponse(request), cancellationToken);
		}
	}

	extension(IPostCommentLikeCommandService commentLikeService)
	{
		public void SetupAddAsync(
			AddPostCommentLikeCommandRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			commentLikeService.SetupAddAsync(request.IsAddPostCommentLikeCommand(), postCommentLike.ToResponse(request), cancellationToken);
		}
	}
}
