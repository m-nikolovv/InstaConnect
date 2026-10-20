using InstaConnect.Common.Application.Tests.Features.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeMockSetups
{
	extension(IApplicationSender sender)
	{
		public void SetupSendAsync(
		GetAllPostCommentLikesApiRequest request,
		PostComment postComment,
		ICollection<PostCommentLike> postCommentLikes,
		CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsGetAllPostCommentLikesQueryRequest(), postCommentLikes.ToResponse(request, postComment), cancellationToken);
		}

		public void SetupSendAsync(
			GetAllPostCommentLikesForUserApiRequest request,
			User user,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsGetAllPostCommentLikesForUserQueryRequest(), postCommentLikes.ToResponse(request, user), cancellationToken);
		}

		public void SetupSendAsync(
			GetPostCommentLikeByIdApiRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsGetPostCommentLikeByIdQueryRequest(), postCommentLike.ToResponse(request), cancellationToken);
		}

		public void SetupSendAsync(
			AddPostCommentLikeApiRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsAddPostCommentLikeCommandRequest(), postCommentLike.ToResponse(request), cancellationToken);
		}
	}
}
