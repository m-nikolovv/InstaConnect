using InstaConnect.Common.Domain.Features.Requests.Models;
using InstaConnect.Common.Presentation.Tests.Features.Assertions;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Base;
using InstaConnect.Common.Tests.Features.DataAttributes.Ints.Base;

namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Assertions;

public static class FollowValidationProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		public void ShouldSatisfyInvalidValidationForFollowerId(
			DeleteFollowApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.FollowerId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForFollowerId(
			GetFollowByIdApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.FollowerId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForFollowerId(
			AddFollowApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.FollowerId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForFollowerId(
			GetAllFollowsApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.FollowerId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForCurrentUserId(
			GetFollowByIdApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.CurrentUserId,
			   messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForCurrentUserId(
			GetAllFollowsApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.CurrentUserId,
			   messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForCurrentUserId(
			GetAllFollowsForFollowingApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.CurrentUserId,
			   messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForFollowingId(
			GetAllFollowsForFollowingApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.FollowingId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForFollowingId(
			GetFollowByIdApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.FollowingId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForFollowingId(
			AddFollowApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Body.FollowingId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForFollowingId(
			DeleteFollowApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.FollowingId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForFollowingName(
			GetAllFollowsApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.FollowingName,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForFollowerName(
			GetAllFollowsForFollowingApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.FollowerName,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForPage(
			GetAllFollowsApiRequest request,
			IIntMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Page,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForPage(
			GetAllFollowsForFollowingApiRequest request,
			IIntMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Page,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForPageSize(
			GetAllFollowsApiRequest request,
			IIntMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.PageSize,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForPageSize(
			GetAllFollowsForFollowingApiRequest request,
			IIntMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.PageSize,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForSortOrder(
			GetAllFollowsApiRequest request,
			IEnumMessageTransformer<CommonSortOrder> messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.SortOrder,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForSortOrder(
			GetAllFollowsForFollowingApiRequest request,
			IEnumMessageTransformer<CommonSortOrder> messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.SortOrder,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForSortTerm(
			GetAllFollowsApiRequest request,
			IEnumMessageTransformer<FollowsSortTerm> messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.SortTerm,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForSortTerm(
			GetAllFollowsForFollowingApiRequest request,
			IEnumMessageTransformer<FollowsForFollowingSortTerm> messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.SortTerm,
				messageTransformer);
		}
	}
}
