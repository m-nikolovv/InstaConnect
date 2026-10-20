using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		public void ShouldSatisfyUserNameNotFound(
			AddForgotPasswordTokenApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNameNotFound(
				request,
				r => r.Name);
		}

		public void ShouldSatisfyUserNotFound(
			VerifyForgotPasswordTokenApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				request,
				r => r.Id);
		}

		public void ShouldSatisfyForgotPasswordTokenNotFound(
			VerifyForgotPasswordTokenApiRequest request)
		{
			problemDetails.ShouldSatisfyForgotPasswordTokenNotFound(
				request,
				r => r.Id,
				r => r.Value);
		}

		public void ShouldSatisfyForgotPasswordTokenExpired(
			VerifyForgotPasswordTokenApiRequest request)
		{
			problemDetails.ShouldSatisfyForgotPasswordTokenExpired(
				request,
				r => r.Id,
				r => r.Value);
		}

		internal void ShouldSatisfyForgotPasswordTokenNotFound<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> valuePropertyExpression)
		{
			problemDetails.ShouldSatisfyNotFound(
				ForgotPasswordTokenExceptionErrorMessages.GetNotFoundMessage(
					new ForgotPasswordTokenId(
						new UserId(idPropertyExpression(request)),
						valuePropertyExpression(request))));
		}

		internal void ShouldSatisfyForgotPasswordTokenExpired<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> valuePropertyExpression)
		{
			problemDetails.ShouldSatisfyBadRequest(
				ForgotPasswordTokenExceptionErrorMessages.GetExpiredMessage(
					new ForgotPasswordTokenId(
						new UserId(idPropertyExpression(request)),
						valuePropertyExpression(request))));
		}
	}
}
