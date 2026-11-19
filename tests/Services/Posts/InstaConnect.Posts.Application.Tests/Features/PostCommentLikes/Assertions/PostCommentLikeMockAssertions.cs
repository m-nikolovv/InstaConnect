using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeMockAssertions
{
	extension(IPostCommentLikeQueryService postCommentLikeService)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(GetAllPostCommentLikesQueryRequest request, CancellationToken cancellationToken)
		{
			await postCommentLikeService.ShouldHaveReceivedOneGetAllAsync(request.IsGetAllPostCommentLikesQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllAsync(
			GetAllPostCommentLikesQuery query,
			CancellationToken cancellationToken)
		{
			await postCommentLikeService.ShouldHaveReceivedOne().GetAllAsync(query, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllForUserAsync(GetAllPostCommentLikesForUserQueryRequest request, CancellationToken cancellationToken)
		{
			await postCommentLikeService.ShouldHaveReceivedOneGetAllForUserAsync(request.IsGetAllPostCommentLikesForUserQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllForUserAsync(
			GetAllPostCommentLikesForUserQuery query,
			CancellationToken cancellationToken)
		{
			await postCommentLikeService.ShouldHaveReceivedOne().GetAllForUserAsync(query, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(GetPostCommentLikeByIdQueryRequest request, CancellationToken cancellationToken)
		{
			await postCommentLikeService.ShouldHaveReceivedOneGetByIdAsync(request.IsGetPostCommentLikeByIdQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetPostCommentLikeByIdQuery query,
			CancellationToken cancellationToken)
		{
			await postCommentLikeService.ShouldHaveReceivedOne().GetByIdAsync(query, cancellationToken);
		}
	}

	extension(IPostCommentLikeCommandService postCommentLikeService)
	{
		public async Task ShouldHaveReceivedOneAddAsync(AddPostCommentLikeCommandRequest request, CancellationToken cancellationToken)
		{
			await postCommentLikeService.ShouldHaveReceivedOneAddAsync(request.IsAddPostCommentLikeCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			AddPostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			await postCommentLikeService.ShouldHaveReceivedOne().AddAsync(command, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(DeletePostCommentLikeCommandRequest request, CancellationToken cancellationToken)
		{
			await postCommentLikeService.ShouldHaveReceivedOneDeleteAsync(request.IsDeletePostCommentLikeCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeletePostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			await postCommentLikeService.ShouldHaveReceivedOne().DeleteAsync(command, cancellationToken);
		}
	}
}
