using InstaConnect.Chats.Tests.Features.ChatMessages.Assertions;

namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageExceptionAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldThrowChatNotFoundExceptionAsync(
			AddChatMessageCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowChatNotFoundExceptionAsync(
				request,
				r => r.ParticipantOneId,
				r => r.ParticipantTwoId,
				cancellationToken);
		}

		public async Task ShouldThrowChatNotFoundExceptionAsync(
			UpdateChatMessageCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowChatNotFoundExceptionAsync(
				request,
				r => r.ParticipantOneId,
				r => r.ParticipantTwoId,
				cancellationToken);
		}

		public async Task ShouldThrowChatNotFoundExceptionAsync(
			DeleteChatMessageCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowChatNotFoundExceptionAsync(
				request,
				r => r.ParticipantOneId,
				r => r.ParticipantTwoId,
				cancellationToken);
		}

		public async Task ShouldThrowChatNotFoundExceptionAsync(
			GetChatMessageByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowChatNotFoundExceptionAsync(
				request,
				r => r.CurrentUserId,
				r => r.ParticipantTwoId,
				cancellationToken);
		}

		public async Task ShouldThrowChatNotFoundExceptionAsync(
			GetAllChatMessagesQueryRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowChatNotFoundExceptionAsync(
				request,
				r => r.CurrentUserId,
				r => r.ParticipantTwoId,
				cancellationToken);
		}

		public async Task ShouldThrowChatMessageNotFoundExceptionAsync(
			UpdateChatMessageCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowChatMessageNotFoundExceptionAsync(
				request,
				r => r.ParticipantOneId,
				r => r.ParticipantTwoId,
				r => r.MessageId,
				cancellationToken);
		}

		public async Task ShouldThrowChatMessageNotFoundExceptionAsync(
			DeleteChatMessageCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowChatMessageNotFoundExceptionAsync(
				request,
				r => r.ParticipantOneId,
				r => r.ParticipantTwoId,
				r => r.MessageId,
				cancellationToken);
		}

		public async Task ShouldThrowChatMessageNotFoundExceptionAsync(
			GetChatMessageByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowChatMessageNotFoundExceptionAsync(
				request,
				r => r.CurrentUserId,
				r => r.ParticipantTwoId,
				r => r.MessageId,
				cancellationToken);
		}

		public async Task ShouldThrowChatMessageForbiddenExceptionAsync(
			DeleteChatMessageCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowChatMessageForbiddenExceptionAsync(
				request,
				r => r.ParticipantOneId,
				r => r.ParticipantTwoId,
				r => r.MessageId,
				r => r.ParticipantOneId,
				cancellationToken);
		}

		public async Task ShouldThrowChatMessageForbiddenExceptionAsync(
			UpdateChatMessageCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowChatMessageForbiddenExceptionAsync(
				request,
				r => r.ParticipantOneId,
				r => r.ParticipantTwoId,
				r => r.MessageId,
				r => r.ParticipantOneId,
				cancellationToken);
		}
	}
}
