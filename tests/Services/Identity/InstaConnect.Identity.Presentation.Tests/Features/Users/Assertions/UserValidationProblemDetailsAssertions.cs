using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;
using InstaConnect.Identity.Domain.Features.Users.Models.Requests;

namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Assertions;

public static class UserValidationProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		public void ShouldSatisfyInvalidValidationForId(
			DeleteUserApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Id,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForId(
			UpdateCurrentUserApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Id,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForId(
			DeleteCurrentUserApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.CurrentId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForId(
			GetUserByIdApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Id,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForId(
			GetUserDetailsByIdApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Id,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForCurrentId(
			GetUserByIdApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.CurrentId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForCurrentId(
			GetCurrentUserByIdApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.CurrentId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForCurrentId(
			GetUserDetailsByIdApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.CurrentId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForCurrentId(
			GetCurrentUserDetailsByIdApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.CurrentId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForCurrentId(
			GetAllUsersApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.CurrentId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForFirstName(
			AddUserApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Form.FirstName,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForFirstName(
			UpdateCurrentUserApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Form.FirstName,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForFirstName(
			GetAllUsersApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.FirstName,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForLastName(
			AddUserApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Form.LastName,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForLastName(
			UpdateCurrentUserApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Form.LastName,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForLastName(
			GetAllUsersApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.LastName,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForName(
			AddUserApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Form.Name,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForName(
			UpdateCurrentUserApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Form.Name,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForName(
			GetAllUsersApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Name,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForEmail(
			AddUserApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Form.Email,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForEmail(
			UpdateCurrentUserApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Form.Email,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForPassword(
			AddUserApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Form.Password,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForConfirmPassword(
			AddUserApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Form.ConfirmPassword,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForPage(
			GetAllUsersApiRequest request,
			IIntMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Page,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForPageSize(
			GetAllUsersApiRequest request,
			IIntMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.PageSize,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForSortOrder(
			GetAllUsersApiRequest request,
			IEnumMessageTransformer<CommonSortOrder> messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.SortOrder,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForSortTerm(
			GetAllUsersApiRequest request,
			IEnumMessageTransformer<UsersSortTerm> messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.SortTerm,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForProfileImage(
			AddUserApiRequest request,
			IFormFileMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Form.ProfileImage,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForProfileImage(
			UpdateCurrentUserApiRequest request,
			IFormFileMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Form.ProfileImage,
				messageTransformer);
		}
	}
}
