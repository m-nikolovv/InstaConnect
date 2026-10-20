using InstaConnect.Common.Application.Tests.Features.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;

public static class PostLikeMockSetups
{
	extension(IApplicationSender sender)
	{
		public void SetupSendAsync(
		GetAllPostLikesApiRequest request,
		Post post,
		ICollection<PostLike> postLikes,
		CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsGetAllPostLikesQueryRequest(), postLikes.ToResponse(request, post), cancellationToken);
		}

		public void SetupSendAsync(
			GetAllPostLikesForUserApiRequest request,
			User user,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsGetAllPostLikesForUserQueryRequest(), postLikes.ToResponse(request, user), cancellationToken);
		}

		public void SetupSendAsync(
			GetPostLikeByIdApiRequest request,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsGetPostLikeByIdQueryRequest(), postLike.ToResponse(request), cancellationToken);
		}

		public void SetupSendAsync(
			AddPostLikeApiRequest request,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsAddPostLikeCommandRequest(), postLike.ToResponse(request), cancellationToken);
		}
	}
}
