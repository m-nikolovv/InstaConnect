using InstaConnect.Identity.Domain.Features.UserClaims.Exceptions;

namespace InstaConnect.Identity.Tests.Features.UserClaims.Assertions;

public static class UserClaimExceptionAssertions
{
	extension(Func<Task> func)
	{
		public async Task ShouldThrowUserClaimNotFoundExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, ApplicationClaims> claimPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<UserClaimNotFoundException>(
				UserClaimExceptionErrorMessages.GetNotFoundMessage(
					new(
						new(idPropertyExpression(request)),
						claimPropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowUserClaimNotFoundExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, UserClaimId> idPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<UserClaimNotFoundException>(
				UserClaimExceptionErrorMessages.GetNotFoundMessage(idPropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowUserClaimAlreadyExistsExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, ApplicationClaims> claimPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<UserClaimAlreadyExistsException>(
				UserClaimExceptionErrorMessages.GetAlreadyExistsMessage(
					new(
						new(idPropertyExpression(request)),
						claimPropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowUserClaimAlreadyExistsExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, UserClaimId> idPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<UserClaimAlreadyExistsException>(
				UserClaimExceptionErrorMessages.GetAlreadyExistsMessage(idPropertyExpression(request)),
				cancellationToken);
		}
	}
}
