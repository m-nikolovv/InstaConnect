using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Exceptions;

namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenExceptionAssertions
{
	extension(Func<Task> func)
	{
		public async Task ShouldThrowForgotPasswordTokenNotFoundExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> valueropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<ForgotPasswordTokenNotFoundException>(
				ForgotPasswordTokenExceptionErrorMessages.GetNotFoundMessage(
					new(
						new(idPropertyExpression(request)),
						valueropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowForgotPasswordTokenNotFoundExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, ForgotPasswordTokenId> idPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<ForgotPasswordTokenNotFoundException>(
				ForgotPasswordTokenExceptionErrorMessages.GetNotFoundMessage(idPropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowForgotPasswordTokenExpiredExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> valuePropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<ForgotPasswordTokenExpiredException>(
				ForgotPasswordTokenExceptionErrorMessages.GetExpiredMessage(
					new(
						new(idPropertyExpression(request)),
						valuePropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowForgotPasswordTokenExpiredExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, ForgotPasswordTokenId> idPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<ForgotPasswordTokenExpiredException>(
				ForgotPasswordTokenExceptionErrorMessages.GetExpiredMessage(idPropertyExpression(request)),
				cancellationToken);
		}
	}
}
