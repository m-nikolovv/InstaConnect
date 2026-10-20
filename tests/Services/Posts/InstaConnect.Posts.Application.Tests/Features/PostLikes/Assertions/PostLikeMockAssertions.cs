using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.PostLikes.Assertions;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Assertions;

public static class PostLikeMockAssertions
{
	extension(IPostLikeQueryService postLikeService)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(
		GetAllPostLikesQueryRequest request,
		CancellationToken cancellationToken)
		{
			await postLikeService.ShouldHaveReceivedOneGetAllAsync(request.IsGetAllPostLikesQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllForUserAsync(
			GetAllPostLikesForUserQueryRequest request,
			CancellationToken cancellationToken)
		{
			await postLikeService.ShouldHaveReceivedOneGetAllForUserAsync(request.IsGetAllPostLikesForUserQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetPostLikeByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await postLikeService.ShouldHaveReceivedOneGetByIdAsync(request.IsGetPostLikeByIdQuery(), cancellationToken);
		}
	}

	extension(IPostLikeCommandService postLikeService)
	{
		public async Task ShouldHaveReceivedOneAddAsync(
		AddPostLikeCommandRequest request,
		CancellationToken cancellationToken)
		{
			await postLikeService.ShouldHaveReceivedOneAddAsync(request.IsAddPostLikeCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeletePostLikeCommandRequest request,
			CancellationToken cancellationToken)
		{
			await postLikeService.ShouldHaveReceivedOneDeleteAsync(request.IsDeletePostLikeCommand(), cancellationToken);
		}
	}
}
