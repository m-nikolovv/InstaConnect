using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Assertions;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Assertions;

public static class PostCommentMockAssertions
{
	extension(IPostCommentQueryService postCommentService)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(GetAllPostCommentsQueryRequest request, CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOneGetAllAsync(request.IsGetAllPostCommentsQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllForUserAsync(GetAllPostCommentsForUserQueryRequest request, CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOneGetAllForUserAsync(request.IsGetAllPostCommentsForUserQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(GetPostCommentByIdQueryRequest request, CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOneGetByIdAsync(request.IsGetPostCommentByIdQuery(), cancellationToken);
		}
	}

	extension(IPostCommentCommandService postCommentService)
	{
		public async Task ShouldHaveReceivedOneAddAsync(AddPostCommentCommandRequest request, CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOneAddAsync(request.IsAddPostCommentCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(UpdatePostCommentCommandRequest request, CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOneUpdateAsync(request.IsUpdatePostCommentCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(DeletePostCommentCommandRequest request, CancellationToken cancellationToken)
		{
			await postCommentService.ShouldHaveReceivedOneDeleteAsync(request.IsDeletePostCommentCommand(), cancellationToken);
		}
	}
}
