using InstaConnect.Identity.Domain.Features.UserClaims.Models.ValueObjects;
using InstaConnect.Identity.Domain.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Assertions;

public static class UserClaimProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		public void ShouldSatisfyUserNotFound(
			GetAllUserClaimsApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				request,
				r => r.Id);
		}

		public void ShouldSatisfyUserNotFound(
			AddUserClaimApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				request,
				r => r.Id);
		}

		public void ShouldSatisfyUserNotFound(
			DeleteUserClaimApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				request,
				r => r.Id);
		}

		public void ShouldSatisfyUserClaimAlreadyExists(
			AddUserClaimApiRequest request)
		{
			problemDetails.ShouldSatisfyUserClaimAlreadyExists(
				request,
				r => r.Id,
				r => r.Body.Claim);
		}

		public void ShouldSatisfyUserClaimNotFound(
			DeleteUserClaimApiRequest request)
		{
			problemDetails.ShouldSatisfyUserClaimNotFound(
				request,
				r => r.Id,
				r => r.Claim);
		}

		internal void ShouldSatisfyUserClaimNotFound<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, ApplicationClaims> claimPropertyExpression)
		{
			problemDetails.ShouldSatisfyNotFound(
				UserClaimExceptionErrorMessages.GetNotFoundMessage(new UserClaimId(new UserId(idPropertyExpression(request)), claimPropertyExpression(request))));
		}

		internal void ShouldSatisfyUserClaimAlreadyExists<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, ApplicationClaims> claimPropertyExpression)
		{
			problemDetails.ShouldSatisfyBadRequest(
				UserClaimExceptionErrorMessages.GetAlreadyExistsMessage(new UserClaimId(new UserId(idPropertyExpression(request)), claimPropertyExpression(request))));
		}
	}
}
