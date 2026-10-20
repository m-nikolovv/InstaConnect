using InstaConnect.Chats.Application.Features.Users.Commands.Add;
using InstaConnect.Chats.Application.Features.Users.Commands.Delete;
using InstaConnect.Chats.Application.Features.Users.Commands.Update;
using InstaConnect.Chats.Domain.Features.Users.Utilities;

namespace InstaConnect.Chats.Presentation.Tests.Features.Users.Assertions;

public static class UserProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		public void ShouldSatisfyUserNotFound(
		UpdateUserCommandRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				request,
				r => r.Id);
		}

		public void ShouldSatisfyUserNotFound(
			DeleteUserCommandRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				request,
				r => r.Id);
		}

		public void ShouldSatisfyUserAlreadyExists(
			AddUserCommandRequest request)
		{
			problemDetails.ShouldSatisfyUserAlreadyExists(
				request,
				r => r.Id);
		}

		public void ShouldSatisfyUserNameAlreadyExists(
			AddUserCommandRequest request)
		{
			problemDetails.ShouldSatisfyUserNameAlreadyExists(
				request,
				r => r.Name);
		}

		public void ShouldSatisfyUserNameAlreadyExists(
			UpdateUserCommandRequest request)
		{
			problemDetails.ShouldSatisfyUserNameAlreadyExists(
				request,
				r => r.Name);
		}

		public void ShouldSatisfyUserEmailAlreadyExists(
			AddUserCommandRequest request)
		{
			problemDetails.ShouldSatisfyUserEmailAlreadyExists(
				request,
				r => r.Email);
		}

		public void ShouldSatisfyUserEmailAlreadyExists(
			UpdateUserCommandRequest request)
		{
			problemDetails.ShouldSatisfyUserEmailAlreadyExists(
				request,
				r => r.Email);
		}

		internal void ShouldSatisfyUserNotFound<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression)
		{
			problemDetails.ShouldSatisfyNotFound(
				UserExceptionErrorMessages.GetNotFoundMessage(new(idPropertyExpression(request))));
		}

		internal void ShouldSatisfyUserAlreadyExists<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression)
		{
			problemDetails.ShouldSatisfyBadRequest(
				UserExceptionErrorMessages.GetAlreadyExistsMessage(new(idPropertyExpression(request))));
		}

		internal void ShouldSatisfyUserNameAlreadyExists<TRequest>(
			TRequest request,
			Func<TRequest, string> namePropertyExpression)
		{
			problemDetails.ShouldSatisfyBadRequest(
				UserExceptionErrorMessages.GetNameAlreadyExistsMessage(new(namePropertyExpression(request))));
		}

		internal void ShouldSatisfyUserEmailAlreadyExists<TRequest>(
			TRequest request,
			Func<TRequest, string> emailPropertyExpression)
		{
			problemDetails.ShouldSatisfyBadRequest(
				UserExceptionErrorMessages.GetEmailAlreadyExistsMessage(new(emailPropertyExpression(request))));
		}
	}
}
