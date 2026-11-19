using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Assertions;

public static class PostCommentMockAssertions
{
	extension(IPostCommentQueryService postCommentService)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(GetAllPostCommentsQueryRequest request, CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOneGetAllAsync(request.IsGetAllPostCommentsQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllAsync(
			GetAllPostCommentsQuery query,
			CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOne().GetAllAsync(query, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllForUserAsync(GetAllPostCommentsForUserQueryRequest request, CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOneGetAllForUserAsync(request.IsGetAllPostCommentsForUserQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllForUserAsync(
			GetAllPostCommentsForUserQuery query,
			CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOne().GetAllForUserAsync(query, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(GetPostCommentByIdQueryRequest request, CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOneGetByIdAsync(request.IsGetPostCommentByIdQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetPostCommentByIdQuery query,
			CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOne().GetByIdAsync(query, cancellationToken);
		}
	}

	extension(IPostCommentCommandService postCommentService)
	{
		public async Task ShouldHaveReceivedOneAddAsync(AddPostCommentCommandRequest request, CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOneAddAsync(request.IsAddPostCommentCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			AddPostCommentCommand command,
			CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOne().AddAsync(command, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(UpdatePostCommentCommandRequest request, CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOneUpdateAsync(request.IsUpdatePostCommentCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			UpdatePostCommentCommand command,
			CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOne().UpdateAsync(command, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(DeletePostCommentCommandRequest request, CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOneDeleteAsync(request.IsDeletePostCommentCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeletePostCommentCommand command,
			CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOne().DeleteAsync(command, cancellationToken);
		}
	}
}
