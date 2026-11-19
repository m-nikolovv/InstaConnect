using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;

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

		public async Task ShouldHaveReceivedOneGetAllAsync(
			GetAllPostLikesQuery query,
			CancellationToken cancellationToken)
		{
			await postLikeService.ShouldHaveReceivedOne().GetAllAsync(query, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllForUserAsync(
			GetAllPostLikesForUserQueryRequest request,
			CancellationToken cancellationToken)
		{
			await postLikeService.ShouldHaveReceivedOneGetAllForUserAsync(request.IsGetAllPostLikesForUserQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllForUserAsync(
			GetAllPostLikesForUserQuery query,
			CancellationToken cancellationToken)
		{
			await postLikeService.ShouldHaveReceivedOne().GetAllForUserAsync(query, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetPostLikeByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await postLikeService.ShouldHaveReceivedOneGetByIdAsync(request.IsGetPostLikeByIdQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetPostLikeByIdQuery query,
			CancellationToken cancellationToken)
		{
			await postLikeService.ShouldHaveReceivedOne().GetByIdAsync(query, cancellationToken);
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

		public async Task ShouldHaveReceivedOneAddAsync(
			AddPostLikeCommand command,
			CancellationToken cancellationToken)
		{
			await postLikeService.ShouldHaveReceivedOne().AddAsync(command, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeletePostLikeCommandRequest request,
			CancellationToken cancellationToken)
		{
			await postLikeService.ShouldHaveReceivedOneDeleteAsync(request.IsDeletePostLikeCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeletePostLikeCommand command,
			CancellationToken cancellationToken)
		{
			await postLikeService.ShouldHaveReceivedOne().DeleteAsync(command, cancellationToken);
		}
	}
}
