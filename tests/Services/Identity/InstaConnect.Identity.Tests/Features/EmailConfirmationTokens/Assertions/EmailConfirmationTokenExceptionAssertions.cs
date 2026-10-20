using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Exceptions;

namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenExceptionAssertions
{
	extension(Func<Task> func)
	{
		public async Task ShouldThrowEmailConfirmationTokenNotFoundExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> valueropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<EmailConfirmationTokenNotFoundException>(
				EmailConfirmationTokenExceptionErrorMessages.GetNotFoundMessage(
					new(
						new(idPropertyExpression(request)),
						valueropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowEmailConfirmationTokenNotFoundExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, EmailConfirmationTokenId> idPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<EmailConfirmationTokenNotFoundException>(
				EmailConfirmationTokenExceptionErrorMessages.GetNotFoundMessage(idPropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowEmailConfirmationTokenExpiredExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> valuePropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<EmailConfirmationTokenExpiredException>(
				EmailConfirmationTokenExceptionErrorMessages.GetExpiredMessage(
					new(
						new(idPropertyExpression(request)),
						valuePropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowEmailConfirmationTokenExpiredExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, EmailConfirmationTokenId> idPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<EmailConfirmationTokenExpiredException>(
				EmailConfirmationTokenExceptionErrorMessages.GetExpiredMessage(idPropertyExpression(request)),
				cancellationToken);
		}
	}
}
