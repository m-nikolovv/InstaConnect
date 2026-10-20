using InstaConnect.Chats.Domain.Features.ChatMessages.Exceptions;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageExceptionAssertions
{
	extension(Func<Task> func)
	{
		public async Task ShouldThrowChatMessageNotFoundExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, string> participantOneIdPropertyExpression,
			Func<TRequest, string> participantTwoIdPropertyExpression,
			Func<TRequest, string> messageIdPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<ChatMessageNotFoundException>(
				ChatMessageExceptionErrorMessages.GetNotFoundMessage(
					new(
						new(
							new(participantOneIdPropertyExpression(request)),
							new(participantTwoIdPropertyExpression(request))),
						messageIdPropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowChatMessageNotFoundExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, ChatMessageId> idPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<ChatMessageNotFoundException>(
				ChatMessageExceptionErrorMessages.GetNotFoundMessage(idPropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowChatMessageForbiddenExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, string> participantOneIdPropertyExpression,
			Func<TRequest, string> participantTwoIdPropertyExpression,
			Func<TRequest, string> messageIdPropertyExpression,
			Func<TRequest, string> senderIdPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<ChatMessageForbiddenException>(
				ChatMessageExceptionErrorMessages.GetForbiddenMessage(
					new(
						new(
							new(participantOneIdPropertyExpression(request)),
							new(participantTwoIdPropertyExpression(request))),
						messageIdPropertyExpression(request)),
					new(senderIdPropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowChatMessageForbiddenExceptionAsync<TRequest>(
			TRequest request,
			Func<TRequest, ChatMessageId> idPropertyExpression,
			Func<TRequest, UserId> senderIdPropertyExpression,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<ChatMessageForbiddenException>(
				ChatMessageExceptionErrorMessages.GetForbiddenMessage(idPropertyExpression(request), senderIdPropertyExpression(request)),
				cancellationToken);
		}
	}
}
