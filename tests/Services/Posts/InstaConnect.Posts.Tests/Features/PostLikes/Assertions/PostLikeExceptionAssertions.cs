using InstaConnect.Posts.Domain.Features.PostLikes.Exceptions;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Assertions;

public static class PostLikeExceptionAssertions
{
	extension(Func<Task> func)
	{
		public async Task ShouldThrowPostLikeNotFoundExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> userIdPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<PostLikeNotFoundException>(
				PostLikeExceptionErrorMessages.GetNotFoundMessage(
				new(
					new(idPropertyExpression(request)),
					new(userIdPropertyExpression(request)))),
				cancellationToken);
		}

		public async Task ShouldThrowPostLikeNotFoundExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, PostLikeId> idPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<PostLikeNotFoundException>(
				PostLikeExceptionErrorMessages.GetNotFoundMessage(idPropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowPostLikeAlreadyExistsExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> userIdPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<PostLikeAlreadyExistsException>(
				PostLikeExceptionErrorMessages.GetAlreadyExistsMessage(
				new(
					new(idPropertyExpression(request)),
					new(userIdPropertyExpression(request)))),
				cancellationToken);
		}

		public async Task ShouldThrowPostLikeAlreadyExistsExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, PostLikeId> idPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<PostLikeAlreadyExistsException>(
				PostLikeExceptionErrorMessages.GetAlreadyExistsMessage(idPropertyExpression(request)),
				cancellationToken);
		}
	}
}
