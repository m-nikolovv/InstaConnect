using InstaConnect.Identity.Domain.Features.UserClaims.Models.Requests;

namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Assertions;

public static class UserClaimValidationProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		public void ShouldSatisfyInvalidValidationForId(
			DeleteUserClaimApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Id,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForId(
			AddUserClaimApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Id,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForId(
			GetAllUserClaimsApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Id,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForClaim(
			DeleteUserClaimApiRequest request,
			IEnumMessageTransformer<ApplicationClaims> messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Claim,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForClaim(
			AddUserClaimApiRequest request,
			IEnumMessageTransformer<ApplicationClaims> messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Body.Claim,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForCurrentId(
			GetAllUserClaimsApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.CurrentId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForPage(
			GetAllUserClaimsApiRequest request,
			IIntMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Page,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForPageSize(
			GetAllUserClaimsApiRequest request,
			IIntMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.PageSize,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForSortOrder(
			GetAllUserClaimsApiRequest request,
			IEnumMessageTransformer<CommonSortOrder> messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.SortOrder,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForSortTerm(
			GetAllUserClaimsApiRequest request,
			IEnumMessageTransformer<UserClaimsSortTerm> messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.SortTerm,
				messageTransformer);
		}
	}
}
