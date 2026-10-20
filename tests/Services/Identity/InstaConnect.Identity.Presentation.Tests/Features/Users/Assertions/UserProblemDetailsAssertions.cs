using InstaConnect.Identity.Domain.Features.Users.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Assertions;

public static class UserProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		public void ShouldSatisfyUserNotFound(
			UpdateCurrentUserApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				request,
				r => r.Id);
		}

		public void ShouldSatisfyUserNotFound(
			GetUserByIdApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				request,
				r => r.Id);
		}

		public void ShouldSatisfyUserNotFound(
			GetUserDetailsByIdApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				request,
				r => r.Id);
		}

		public void ShouldSatisfyUserNotFound(
			GetCurrentUserByIdApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				request,
				r => r.CurrentId);
		}

		public void ShouldSatisfyUserNotFound(
			GetCurrentUserDetailsByIdApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				request,
				r => r.CurrentId);
		}

		public void ShouldSatisfyUserNotFound(
			DeleteUserApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				request,
				r => r.Id);
		}

		public void ShouldSatisfyUserNotFound(
			DeleteCurrentUserApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				request,
				r => r.CurrentId);
		}

		public void ShouldSatisfyUserNameAlreadyTaken(
			AddUserApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNameAlreadyTaken(
				request,
				r => r.Form.Name);
		}

		public void ShouldSatisfyUserNameAlreadyTaken(
			UpdateCurrentUserApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNameAlreadyTaken(
				request,
				r => r.Form.Name);
		}

		public void ShouldSatisfyUserEmailAlreadyTaken(
			AddUserApiRequest request)
		{
			problemDetails.ShouldSatisfyUserEmailAlreadyTaken(
				request,
				r => r.Form.Email);
		}

		public void ShouldSatisfyUserEmailAlreadyTaken(
			UpdateCurrentUserApiRequest request)
		{
			problemDetails.ShouldSatisfyUserEmailAlreadyTaken(
				request,
				r => r.Form.Email);
		}

		internal void ShouldSatisfyUserNotFound<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression)
		{
			problemDetails.ShouldSatisfyNotFound(
				UserExceptionErrorMessages.GetNotFoundMessage(
					new(idPropertyExpression(request))));
		}

		internal void ShouldSatisfyUserNameNotFound<TRequest>(
			TRequest request,
			Func<TRequest, string> namePropertyExpression)
		{
			problemDetails.ShouldSatisfyNotFound(
				UserExceptionErrorMessages.GetNameNotFoundMessage(
					new(namePropertyExpression(request))));
		}

		internal void ShouldSatisfyUserEmailAlreadyTaken<TRequest>(
			TRequest request,
			Func<TRequest, string> emailPropertyExpression)
		{
			problemDetails.ShouldSatisfyBadRequest(
				UserExceptionErrorMessages.GetEmailAlreadyTakenMessage(
					new(emailPropertyExpression(request))));
		}

		internal void ShouldSatisfyUserNameAlreadyTaken<TRequest>(
			TRequest request,
			Func<TRequest, string> namePropertyExpression)
		{
			problemDetails.ShouldSatisfyBadRequest(
				UserExceptionErrorMessages.GetNameAlreadyTakenMessage(
					new(namePropertyExpression(request))));
		}

		internal void ShouldSatisfyUserInvalidDetails<TRequest>(
			TRequest request,
			Func<TRequest, string> namePropertyExpression)
		{
			problemDetails.ShouldSatisfyBadRequest(
				UserExceptionErrorMessages.GetInvalidDetailsMessage(
					new(namePropertyExpression(request))));
		}

		internal void ShouldSatisfyUserEmailAlreadyConfirmed<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression)
		{
			problemDetails.ShouldSatisfyBadRequest(
				UserExceptionErrorMessages.GetEmailAlreadyConfirmedMessage(
					new(idPropertyExpression(request))));
		}

		internal void ShouldSatisfyUserNameEmailAlreadyConfirmed<TRequest>(
			TRequest request,
			Func<TRequest, string> namePropertyExpression)
		{
			problemDetails.ShouldSatisfyBadRequest(
				UserExceptionErrorMessages.GetNameEmailAlreadyConfirmedMessage(
					new(namePropertyExpression(request))));
		}

		internal void ShouldSatisfyUserEmailNotConfirmed<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression)
		{
			problemDetails.ShouldSatisfyBadRequest(
				UserExceptionErrorMessages.GetEmailNotConfirmedMessage(
					new(idPropertyExpression(request))));
		}

		internal void ShouldSatisfyUserNameEmailNotConfirmed<TRequest>(
			TRequest request,
			Func<TRequest, string> namePropertyExpression)
		{
			problemDetails.ShouldSatisfyBadRequest(
				UserExceptionErrorMessages.GetNameEmailNotConfirmedMessage(
					new(namePropertyExpression(request))));
		}
	}
}
