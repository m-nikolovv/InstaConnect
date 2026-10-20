using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		public void ShouldSatisfyUserNameNotFound(
			AddEmailConfirmationTokenApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNameNotFound(
				request,
				r => r.Name);
		}

		public void ShouldSatisfyUserNameEmailAlreadyConfirmed(
			AddEmailConfirmationTokenApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNameEmailAlreadyConfirmed(
				request,
				r => r.Name);
		}

		public void ShouldSatisfyUserNotFound(
			VerifyEmailConfirmationTokenApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				request,
				r => r.Id);
		}

		public void ShouldSatisfyUserEmailAlreadyConfirmed(
			VerifyEmailConfirmationTokenApiRequest request)
		{
			problemDetails.ShouldSatisfyUserEmailAlreadyConfirmed(
				request,
				r => r.Id);
		}

		public void ShouldSatisfyEmailConfirmationTokenNotFound(
			VerifyEmailConfirmationTokenApiRequest request)
		{
			problemDetails.ShouldSatisfyEmailConfirmationTokenNotFound(
				request,
				r => r.Id,
				r => r.Value);
		}

		public void ShouldSatisfyEmailConfirmationTokenExpired(
			VerifyEmailConfirmationTokenApiRequest request)
		{
			problemDetails.ShouldSatisfyEmailConfirmationTokenExpired(
				request,
				r => r.Id,
				r => r.Value);
		}

		internal void ShouldSatisfyEmailConfirmationTokenNotFound<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> valuePropertyExpression)
		{
			problemDetails.ShouldSatisfyNotFound(
				EmailConfirmationTokenExceptionErrorMessages.GetNotFoundMessage(
					new EmailConfirmationTokenId(
						new UserId(idPropertyExpression(request)),
						valuePropertyExpression(request))));
		}

		internal void ShouldSatisfyEmailConfirmationTokenExpired<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> valuePropertyExpression)
		{
			problemDetails.ShouldSatisfyBadRequest(
				EmailConfirmationTokenExceptionErrorMessages.GetExpiredMessage(
					new EmailConfirmationTokenId(
						new UserId(idPropertyExpression(request)),
						valuePropertyExpression(request))));
		}
	}
}
