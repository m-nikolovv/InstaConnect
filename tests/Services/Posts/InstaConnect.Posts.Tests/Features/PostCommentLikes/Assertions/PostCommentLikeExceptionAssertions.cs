using InstaConnect.Posts.Domain.Features.PostCommentLikes.Exceptions;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeExceptionAssertions
{
	extension(Func<Task> func)
	{
		public async Task ShouldThrowPostCommentLikeNotFoundExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> commentIdPropertyExpression,
			Func<TRequest, string> userIdPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<PostCommentLikeNotFoundException>(
				PostCommentLikeExceptionErrorMessages.GetNotFoundMessage(
					new(
						new(
							new(idPropertyExpression(request)),
							commentIdPropertyExpression(request)),
						new(userIdPropertyExpression(request)))),
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentLikeNotFoundExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, PostCommentLikeId> idPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<PostCommentLikeNotFoundException>(
				PostCommentLikeExceptionErrorMessages.GetNotFoundMessage(idPropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> commentIdPropertyExpression,
			Func<TRequest, string> userIdPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<PostCommentLikeAlreadyExistsException>(
				PostCommentLikeExceptionErrorMessages.GetAlreadyExistsMessage(
					new(
						new(
							new(idPropertyExpression(request)),
							commentIdPropertyExpression(request)),
						new(userIdPropertyExpression(request)))),
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, PostCommentLikeId> idPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<PostCommentLikeAlreadyExistsException>(
				PostCommentLikeExceptionErrorMessages.GetAlreadyExistsMessage(idPropertyExpression(request)),
				cancellationToken);
		}
	}
}
