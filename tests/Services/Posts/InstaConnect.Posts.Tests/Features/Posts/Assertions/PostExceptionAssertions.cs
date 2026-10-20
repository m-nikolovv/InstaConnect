using InstaConnect.Posts.Domain.Features.Posts.Exceptions;

namespace InstaConnect.Posts.Tests.Features.Posts.Assertions;

public static class PostExceptionAssertions
{
	extension(Func<Task> func)
	{
		public async Task ShouldThrowPostNotFoundExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<PostNotFoundException>(
				PostExceptionErrorMessages.GetNotFoundMessage(new(idPropertyExpression(request))),
				cancellationToken);
		}
		public async Task ShouldThrowPostNotFoundExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, PostId> idPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<PostNotFoundException>(
				PostExceptionErrorMessages.GetNotFoundMessage(idPropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowPostForbiddenExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> userIdPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<PostForbiddenException>(
				PostExceptionErrorMessages.GetForbiddenMessage(new(idPropertyExpression(request)), new(userIdPropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowPostForbiddenExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, PostId> idPropertyExpression,
			Func<TRequest, UserId> userIdPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<PostForbiddenException>(
				PostExceptionErrorMessages.GetForbiddenMessage(idPropertyExpression(request), userIdPropertyExpression(request)),
				cancellationToken);
		}
	}
}
