using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		public void ShouldSatisfyUserInvalidDetails(
			IssueRefreshTokenApiRequest request)
		{
			problemDetails.ShouldSatisfyUserInvalidDetails(
				request,
				r => r.Name);
		}

		public void ShouldSatisfyUserNameEmailNotConfirmed(
			IssueRefreshTokenApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNameEmailNotConfirmed(
				request,
				r => r.Name);
		}

		public void ShouldSatisfyUserEmailNotConfirmed(
			RotateRefreshTokenApiRequest request)
		{
			problemDetails.ShouldSatisfyUserEmailNotConfirmed(
				request,
				r => r.Id);
		}

		public void ShouldSatisfyUserNotFound(
			RotateRefreshTokenApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				request,
				r => r.Id);
		}

		public void ShouldSatisfyUserNotFound(
			DeleteCurrentRefreshTokenApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				request,
				r => r.Id);
		}

		public void ShouldSatisfyRefreshTokenNotFound(
			RotateRefreshTokenApiRequest request)
		{
			problemDetails.ShouldSatisfyRefreshTokenNotFound(
				request,
				r => r.Id,
				r => r.Value);
		}

		public void ShouldSatisfyRefreshTokenNotFound(
			DeleteCurrentRefreshTokenApiRequest request)
		{
			problemDetails.ShouldSatisfyRefreshTokenNotFound(
				request,
				r => r.Id,
				r => r.Value);
		}

		public void ShouldSatisfyRefreshTokenExpired(
			RotateRefreshTokenApiRequest request)
		{
			problemDetails.ShouldSatisfyRefreshTokenExpired(
				request,
				r => r.Id,
				r => r.Value);
		}

		public void ShouldSatisfyRefreshTokenExpired(
			DeleteCurrentRefreshTokenApiRequest request)
		{
			problemDetails.ShouldSatisfyRefreshTokenExpired(
				request,
				r => r.Id,
				r => r.Value);
		}

		internal void ShouldSatisfyRefreshTokenNotFound<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> valuePropertyExpression)
		{
			problemDetails.ShouldSatisfyNotFound(
				RefreshTokenExceptionErrorMessages.GetNotFoundMessage(
					new RefreshTokenId(
						new UserId(idPropertyExpression(request)),
						valuePropertyExpression(request))));
		}

		internal void ShouldSatisfyRefreshTokenExpired<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> valuePropertyExpression)
		{
			problemDetails.ShouldSatisfyBadRequest(
				RefreshTokenExceptionErrorMessages.GetExpiredMessage(
					new RefreshTokenId(
						new UserId(idPropertyExpression(request)),
						valuePropertyExpression(request))));
		}
	}
}
