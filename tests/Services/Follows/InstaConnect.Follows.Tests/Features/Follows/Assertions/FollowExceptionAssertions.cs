using InstaConnect.Common.Tests.Features.Assertions;
using InstaConnect.Follows.Domain.Features.Follows.Exceptions;

namespace InstaConnect.Follows.Tests.Features.Follows.Assertions;

public static class FollowExceptionAssertions
{
	extension(Func<Task> func)
	{
		public async Task ShouldThrowFollowNotFoundExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, string> followerIdPropertyExpression,
			Func<TRequest, string> followingIdPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<FollowNotFoundException>(
				FollowExceptionErrorMessages.GetNotFoundMessage(
				new(
					new(followerIdPropertyExpression(request)),
					new(followingIdPropertyExpression(request)))),
				cancellationToken);
		}

		public async Task ShouldThrowFollowNotFoundExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, FollowId> idPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<FollowNotFoundException>(
				FollowExceptionErrorMessages.GetNotFoundMessage(idPropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowFollowAlreadyExistsExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, string> followerIdPropertyExpression,
			Func<TRequest, string> followingIdPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<FollowAlreadyExistsException>(
				FollowExceptionErrorMessages.GetAlreadyExistsMessage(
				new(
					new(followerIdPropertyExpression(request)),
					new(followingIdPropertyExpression(request)))),
				cancellationToken);
		}

		public async Task ShouldThrowFollowAlreadyExistsExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, FollowId> idPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<FollowAlreadyExistsException>(
				FollowExceptionErrorMessages.GetAlreadyExistsMessage(idPropertyExpression(request)),
				cancellationToken);
		}
	}
}
