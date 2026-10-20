using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Assertions;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeMockAssertions
{
	extension(IPostCommentLikeQueryService postCommentLikeService)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(GetAllPostCommentLikesQueryRequest request, CancellationToken cancellationToken)
		{
			await postCommentLikeService.ShouldHaveReceivedOneGetAllAsync(request.IsGetAllPostCommentLikesQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllForUserAsync(GetAllPostCommentLikesForUserQueryRequest request, CancellationToken cancellationToken)
		{
			await postCommentLikeService.ShouldHaveReceivedOneGetAllForUserAsync(request.IsGetAllPostCommentLikesForUserQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(GetPostCommentLikeByIdQueryRequest request, CancellationToken cancellationToken)
		{
			await postCommentLikeService.ShouldHaveReceivedOneGetByIdAsync(request.IsGetPostCommentLikeByIdQuery(), cancellationToken);
		}
	}

	extension(IPostCommentLikeCommandService postCommentLikeService)
	{
		public async Task ShouldHaveReceivedOneAddAsync(AddPostCommentLikeCommandRequest request, CancellationToken cancellationToken)
		{
			await postCommentLikeService.ShouldHaveReceivedOneAddAsync(request.IsAddPostCommentLikeCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(DeletePostCommentLikeCommandRequest request, CancellationToken cancellationToken)
		{
			await postCommentLikeService.ShouldHaveReceivedOneDeleteAsync(request.IsDeletePostCommentLikeCommand(), cancellationToken);
		}
	}
}
