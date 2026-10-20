using InstaConnect.Identity.Domain.Features.RefreshTokens.Exceptions;

namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenExceptionAssertions
{
	extension(Func<Task> func)
	{
		public async Task ShouldThrowRefreshTokenNotFoundExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> valueropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<RefreshTokenNotFoundException>(
				RefreshTokenExceptionErrorMessages.GetNotFoundMessage(
					new(
						new(idPropertyExpression(request)),
						valueropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowRefreshTokenNotFoundExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, RefreshTokenId> idPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<RefreshTokenNotFoundException>(
				RefreshTokenExceptionErrorMessages.GetNotFoundMessage(idPropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowRefreshTokenExpiredExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> valuePropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<RefreshTokenExpiredException>(
				RefreshTokenExceptionErrorMessages.GetExpiredMessage(
					new(
						new(idPropertyExpression(request)),
						valuePropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowRefreshTokenExpiredExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, RefreshTokenId> idPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<RefreshTokenExpiredException>(
				RefreshTokenExceptionErrorMessages.GetExpiredMessage(idPropertyExpression(request)),
				cancellationToken);
		}
	}
}
