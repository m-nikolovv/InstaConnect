using InstaConnect.Posts.Domain.Features.Posts.Abstractions;

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

		public async Task ShouldHaveReceivedOneGetAllAsync(
			GetAllPostsQuery query,
			CancellationToken cancellationToken)
		{
			await postService.ShouldHaveReceivedOne().GetAllAsync(query, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllForUserAsync(
			GetAllPostsForUserQueryRequest request,
			CancellationToken cancellationToken)
		{
			await postService.ShouldHaveReceivedOneGetAllForUserAsync(request.IsGetAllPostsForUserQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllForUserAsync(
			GetAllPostsForUserQuery query,
			CancellationToken cancellationToken)
		{
			await postService.ShouldHaveReceivedOne().GetAllForUserAsync(query, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetPostByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await postService.ShouldHaveReceivedOneGetByIdAsync(request.IsGetPostByIdQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetPostByIdQuery query,
			CancellationToken cancellationToken)
		{
			await postService.ShouldHaveReceivedOne().GetByIdAsync(query, cancellationToken);
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

		public async Task ShouldHaveReceivedOneAddAsync(
			AddPostCommand command,
			CancellationToken cancellationToken)
		{
			await postService.ShouldHaveReceivedOne().AddAsync(command, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			UpdatePostCommandRequest request,
			CancellationToken cancellationToken)
		{
			await postService.ShouldHaveReceivedOneUpdateAsync(request.IsUpdatePostCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			UpdatePostCommand command,
			CancellationToken cancellationToken)
		{
			await postService.ShouldHaveReceivedOne().UpdateAsync(command, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeletePostCommandRequest request,
			CancellationToken cancellationToken)
		{
			await postService.ShouldHaveReceivedOneDeleteAsync(request.IsDeletePostCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeletePostCommand command,
			CancellationToken cancellationToken)
		{
			await postService.ShouldHaveReceivedOne().DeleteAsync(command, cancellationToken);
		}
	}
}
