using InstaConnect.Chats.Domain.Features.Users.Exceptions;
using InstaConnect.Common.Domain.Features.ValueObjects.Models;

namespace InstaConnect.Chats.Tests.Features.Users.Assertions;

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

		public async Task ShouldThrowUserAlreadyExistsExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<UserAlreadyExistsException>(
				UserExceptionErrorMessages.GetAlreadyExistsMessage(new(idPropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowUserAlreadyExistsExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, UserId> idPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<UserAlreadyExistsException>(
				UserExceptionErrorMessages.GetAlreadyExistsMessage(idPropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowUserNameAlreadyExistsExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, string> namePropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<UserNameAlreadyExistsException>(
				UserExceptionErrorMessages.GetNameAlreadyExistsMessage(new(namePropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowUserNameAlreadyExistsExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, Name> namePropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<UserNameAlreadyExistsException>(
				UserExceptionErrorMessages.GetNameAlreadyExistsMessage(namePropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailAlreadyExistsExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, string> emailPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<UserEmailAlreadyExistsException>(
				UserExceptionErrorMessages.GetEmailAlreadyExistsMessage(new(emailPropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailAlreadyExistsExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, Email> emailPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<UserEmailAlreadyExistsException>(
				UserExceptionErrorMessages.GetEmailAlreadyExistsMessage(emailPropertyExpression(request)),
				cancellationToken);
		}
	}
}
