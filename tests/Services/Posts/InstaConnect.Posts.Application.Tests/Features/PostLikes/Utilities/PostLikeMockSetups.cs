using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;

public static class PostLikeMockSetups
{
	extension(IPostLikeQueryService likeService)
	{
		public void SetupGetAllAsync(
		GetAllPostLikesQueryRequest request,
		Post post,
		ICollection<PostLike> postLikes,
		CancellationToken cancellationToken)
		{
			likeService.SetupGetAllAsync(request.IsGetAllPostLikesQuery(), postLikes.ToResponse(request, post), cancellationToken);
		}

		public void SetupGetAllForUserAsync(
			GetAllPostLikesForUserQueryRequest request,
			User user,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			likeService.SetupGetAllForUserAsync(request.IsGetAllPostLikesForUserQuery(), postLikes.ToResponse(request, user), cancellationToken);
		}

		public void SetupGetByIdAsync(
			GetPostLikeByIdQueryRequest request,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			likeService.SetupGetByIdAsync(request.IsGetPostLikeByIdQuery(), postLike.ToResponse(request), cancellationToken);
		}
	}

	extension(IPostLikeCommandService likeService)
	{
		public void SetupAddAsync(
		AddPostLikeCommandRequest request,
		PostLike postLike,
		CancellationToken cancellationToken)
		{
			likeService.SetupAddAsync(request.IsAddPostLikeCommand(), postLike.ToResponse(request), cancellationToken);
		}
	}
}
