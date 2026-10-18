using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Assertions;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Assertions;

public static class PostMockAssertions
{
	extension(IPostQueryService postService)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(
		GetAllPostsQueryRequest request,
		CancellationToken cancellationToken)
		{
			await postService.ShouldHaveReceivedOneGetAllAsync(request.IsGetAllPostsQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllForUserAsync(
			GetAllPostsForUserQueryRequest request,
			CancellationToken cancellationToken)
		{
			await postService.ShouldHaveReceivedOneGetAllForUserAsync(request.IsGetAllPostsForUserQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetPostByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await postService.ShouldHaveReceivedOneGetByIdAsync(request.IsGetPostByIdQuery(), cancellationToken);
		}
	}

	extension(IPostCommandService postService)
	{
		public async Task ShouldHaveReceivedOneAddAsync(
		AddPostCommandRequest request,
		CancellationToken cancellationToken)
		{
			await postService.ShouldHaveReceivedOneAddAsync(request.IsAddPostCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			UpdatePostCommandRequest request,
			CancellationToken cancellationToken)
		{
			await postService.ShouldHaveReceivedOneUpdateAsync(request.IsUpdatePostCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeletePostCommandRequest request,
			CancellationToken cancellationToken)
		{
			await postService.ShouldHaveReceivedOneDeleteAsync(request.IsDeletePostCommand(), cancellationToken);
		}
	}
}
