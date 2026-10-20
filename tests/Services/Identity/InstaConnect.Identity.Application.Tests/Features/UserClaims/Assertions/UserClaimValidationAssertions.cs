using InstaConnect.Common.Events.Features.AccessTokens.Models;

namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Assertions;

public static class UserClaimValidationAssertions
{
	extension(TestValidationResult<DeleteUserClaimCommandRequest> response)
	{
		public void ShouldHaveValidationErrorForId(
			DeleteUserClaimCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForClaim(
			DeleteUserClaimCommandRequest request,
			IEnumMessageTransformer<ApplicationClaims> messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.Claim, messageTransformer);
		}
	}

	extension(TestValidationResult<AddUserClaimCommandRequest> response)
	{
		public void ShouldHaveValidationErrorForId(
			AddUserClaimCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForClaim(
			AddUserClaimCommandRequest request,
			IEnumMessageTransformer<ApplicationClaims> messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.Claim, messageTransformer);
		}
	}

	extension(TestValidationResult<GetAllUserClaimsQueryRequest> response)
	{
		public void ShouldHaveValidationErrorForId(
			GetAllUserClaimsQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentId(
			GetAllUserClaimsQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.CurrentId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPage(
			GetAllUserClaimsQueryRequest request,
			IIntMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.Page, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPageSize(
			GetAllUserClaimsQueryRequest request,
			IIntMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.PageSize, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortOrder(
			GetAllUserClaimsQueryRequest request,
			IEnumMessageTransformer<CommonSortOrder> messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.SortOrder, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortTerm(
			GetAllUserClaimsQueryRequest request,
			IEnumMessageTransformer<UserClaimsSortTerm> messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.SortTerm, messageTransformer);
		}
	}
}
