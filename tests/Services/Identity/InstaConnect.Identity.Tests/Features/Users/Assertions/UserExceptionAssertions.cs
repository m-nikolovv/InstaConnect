using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Identity.Domain.Features.Users.Exceptions;

namespace InstaConnect.Identity.Tests.Features.Users.Assertions;

public static class UserExceptionAssertions
{
	extension(Func<Task> func)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<UserNotFoundException>(
				UserExceptionErrorMessages.GetNotFoundMessage(new(idPropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, UserId> idPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<UserNotFoundException>(
				UserExceptionErrorMessages.GetNotFoundMessage(idPropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowUserNameNotFoundExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, string> namePropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<UserNameNotFoundException>(
				UserExceptionErrorMessages.GetNameNotFoundMessage(new(namePropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowUserNameNotFoundExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, Name> namePropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<UserNameNotFoundException>(
				UserExceptionErrorMessages.GetNameNotFoundMessage(namePropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailAlreadyTakenExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, string> emailPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<UserEmailAlreadyTakenException>(
				UserExceptionErrorMessages.GetEmailAlreadyTakenMessage(new(emailPropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailAlreadyTakenExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, Email> emailPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<UserEmailAlreadyTakenException>(
				UserExceptionErrorMessages.GetEmailAlreadyTakenMessage(emailPropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowUserNameAlreadyTakenExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, string> namePropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<UserNameAlreadyTakenException>(
				UserExceptionErrorMessages.GetNameAlreadyTakenMessage(new(namePropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowUserNameAlreadyTakenExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, Name> namePropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<UserNameAlreadyTakenException>(
				UserExceptionErrorMessages.GetNameAlreadyTakenMessage(namePropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowUserInvalidDetailsExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, string> namePropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<UserInvalidDetailsException>(
				UserExceptionErrorMessages.GetInvalidDetailsMessage(new(namePropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowUserInvalidDetailsExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, Name> namePropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<UserInvalidDetailsException>(
				UserExceptionErrorMessages.GetInvalidDetailsMessage(namePropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailAlreadyConfirmedExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<UserEmailAlreadyConfirmedException>(
				UserExceptionErrorMessages.GetEmailAlreadyConfirmedMessage(new(idPropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailAlreadyConfirmedExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, UserId> idPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<UserEmailAlreadyConfirmedException>(
				UserExceptionErrorMessages.GetEmailAlreadyConfirmedMessage(idPropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowUserNameEmailAlreadyConfirmedExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, string> namePropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<UserNameEmailAlreadyConfirmedException>(
				UserExceptionErrorMessages.GetNameEmailAlreadyConfirmedMessage(new(namePropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowUserNameEmailAlreadyConfirmedExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, Name> namePropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<UserNameEmailAlreadyConfirmedException>(
				UserExceptionErrorMessages.GetNameEmailAlreadyConfirmedMessage(namePropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailNotConfirmedExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<UserEmailNotConfirmedException>(
				UserExceptionErrorMessages.GetEmailNotConfirmedMessage(new(idPropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailNotConfirmedExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, UserId> idPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<UserEmailNotConfirmedException>(
				UserExceptionErrorMessages.GetEmailNotConfirmedMessage(idPropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowUserNameEmailNotConfirmedExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, string> namePropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<UserNameEmailNotConfirmedException>(
				UserExceptionErrorMessages.GetNameEmailNotConfirmedMessage(new(namePropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowUserNameEmailNotConfirmedExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, Name> namePropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<UserNameEmailNotConfirmedException>(
				UserExceptionErrorMessages.GetNameEmailNotConfirmedMessage(namePropertyExpression(request)),
				cancellationToken);
		}
	}
}
