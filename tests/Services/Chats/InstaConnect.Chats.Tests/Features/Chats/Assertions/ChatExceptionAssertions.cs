using InstaConnect.Chats.Domain.Features.Chats.Exceptions;

namespace InstaConnect.Chats.Tests.Features.Chats.Assertions;

public static class ChatExceptionAssertions
{
	extension(Func<Task> func)
	{
		public async Task ShouldThrowChatNotFoundExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, string> participantOneIdPropertyExpression,
			Func<TRequest, string> participantTwoIdPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<ChatNotFoundException>(
				ChatExceptionErrorMessages.GetNotFoundMessage(new(new(participantOneIdPropertyExpression(request)), new(participantTwoIdPropertyExpression(request)))),
				cancellationToken);
		}

		public async Task ShouldThrowChatNotFoundExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, ChatId> idPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<ChatNotFoundException>(
				ChatExceptionErrorMessages.GetNotFoundMessage(idPropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowChatAlreadyExistsExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, string> participantOneIdPropertyExpression,
			Func<TRequest, string> participantTwoIdPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<ChatAlreadyExistsException>(
				ChatExceptionErrorMessages.GetAlreadyExistsMessage(new(new(participantOneIdPropertyExpression(request)), new(participantTwoIdPropertyExpression(request)))),
				cancellationToken);
		}

		public async Task ShouldThrowChatAlreadyExistsExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, ChatId> idPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<ChatAlreadyExistsException>(
				ChatExceptionErrorMessages.GetAlreadyExistsMessage(idPropertyExpression(request)),
				cancellationToken);
		}
	}
}
