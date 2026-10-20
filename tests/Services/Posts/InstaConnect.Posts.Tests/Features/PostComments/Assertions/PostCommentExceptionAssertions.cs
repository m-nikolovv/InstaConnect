using InstaConnect.Posts.Domain.Features.PostComments.Exceptions;

namespace InstaConnect.Posts.Tests.Features.PostComments.Assertions;

public static class PostCommentExceptionAssertions
{
	extension(Func<Task> func)
	{
		public async Task ShouldThrowPostCommentNotFoundExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> commentIdPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<PostCommentNotFoundException>(
				PostCommentExceptionErrorMessages.GetNotFoundMessage(
					new(
						new(idPropertyExpression(request)),
						new(commentIdPropertyExpression(request)))),
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentNotFoundExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, PostCommentId> idPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<PostCommentNotFoundException>(
				PostCommentExceptionErrorMessages.GetNotFoundMessage(idPropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentForbiddenExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> commentIdPropertyExpression,
			Func<TRequest, string> userIdPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<PostCommentForbiddenException>(
				PostCommentExceptionErrorMessages.GetForbiddenMessage(
					new(
						new(idPropertyExpression(request)),
						new(commentIdPropertyExpression(request))),
					new(userIdPropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentForbiddenExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, PostCommentId> idPropertyExpression,
			Func<TRequest, UserId> userIdPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<PostCommentForbiddenException>(
				PostCommentExceptionErrorMessages.GetForbiddenMessage(
					idPropertyExpression(request),
					userIdPropertyExpression(request)),
				cancellationToken);
		}
	}
}
