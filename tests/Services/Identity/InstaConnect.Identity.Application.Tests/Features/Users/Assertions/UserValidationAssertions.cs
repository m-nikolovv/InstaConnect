namespace InstaConnect.Identity.Application.Tests.Features.Users.Assertions;

public static class UserValidationAssertions
{
	extension(TestValidationResult<UpdateCurrentUserCommandRequest> response)
	{
		public void ShouldHaveValidationErrorForId(
			UpdateCurrentUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForFirstName(
			UpdateCurrentUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.FirstName, messageTransformer);
		}

		public void ShouldHaveValidationErrorForLastName(
			UpdateCurrentUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.LastName, messageTransformer);
		}

		public void ShouldHaveValidationErrorForName(
			UpdateCurrentUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.Name, messageTransformer);
		}

		public void ShouldHaveValidationErrorForEmail(
			UpdateCurrentUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.Email, messageTransformer);
		}
	}

	extension(TestValidationResult<DeleteUserCommandRequest> response)
	{
		public void ShouldHaveValidationErrorForId(
			DeleteUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}
	}

	extension(TestValidationResult<DeleteCurrentUserCommandRequest> response)
	{
		public void ShouldHaveValidationErrorForId(
			DeleteCurrentUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.CurrentId, messageTransformer);
		}
	}

	extension(TestValidationResult<GetUserByIdQueryRequest> response)
	{
		public void ShouldHaveValidationErrorForId(
			GetUserByIdQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentId(
			GetUserByIdQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.CurrentId, messageTransformer);
		}
	}

	extension(TestValidationResult<GetCurrentUserByIdQueryRequest> response)
	{
		public void ShouldHaveValidationErrorForCurrentId(
			GetCurrentUserByIdQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.CurrentId, messageTransformer);
		}
	}

	extension(TestValidationResult<GetUserDetailsByIdQueryRequest> response)
	{
		public void ShouldHaveValidationErrorForId(
			GetUserDetailsByIdQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentId(
			GetUserDetailsByIdQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.CurrentId, messageTransformer);
		}
	}

	extension(TestValidationResult<GetCurrentUserDetailsByIdQueryRequest> response)
	{
		public void ShouldHaveValidationErrorForCurrentId(
			GetCurrentUserDetailsByIdQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.CurrentId, messageTransformer);
		}
	}

	extension(TestValidationResult<AddUserCommandRequest> response)
	{
		public void ShouldHaveValidationErrorForFirstName(
			AddUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.FirstName, messageTransformer);
		}

		public void ShouldHaveValidationErrorForLastName(
			AddUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.LastName, messageTransformer);
		}

		public void ShouldHaveValidationErrorForName(
			AddUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.Name, messageTransformer);
		}

		public void ShouldHaveValidationErrorForEmail(
			AddUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.Email, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPassword(
			AddUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.Password, messageTransformer);
		}

		public void ShouldHaveValidationErrorForConfirmPassword(
			AddUserCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.ConfirmPassword, messageTransformer);
		}
	}

	extension(TestValidationResult<GetAllUsersQueryRequest> response)
	{
		public void ShouldHaveValidationErrorForName(
			GetAllUsersQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.Name, messageTransformer);
		}

		public void ShouldHaveValidationErrorForFirstName(
			GetAllUsersQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.FirstName, messageTransformer);
		}

		public void ShouldHaveValidationErrorForLastName(
			GetAllUsersQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.LastName, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentId(
			GetAllUsersQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.CurrentId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPage(
			GetAllUsersQueryRequest request,
			IIntMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.Page, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPageSize(
			GetAllUsersQueryRequest request,
			IIntMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.PageSize, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortOrder(
			GetAllUsersQueryRequest request,
			IEnumMessageTransformer<CommonSortOrder> messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.SortOrder, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortTerm(
			GetAllUsersQueryRequest request,
			IEnumMessageTransformer<UsersSortTerm> messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.SortTerm, messageTransformer);
		}
	}
}
