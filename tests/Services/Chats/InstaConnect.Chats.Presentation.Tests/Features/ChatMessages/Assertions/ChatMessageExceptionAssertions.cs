using InstaConnect.Chats.Presentation.Features.ChatMessages.Controllers.v1;
using InstaConnect.Chats.Tests.Features.ChatMessages.Assertions;
using InstaConnect.Chats.Tests.Features.Chats.Assertions;

namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageExceptionAssertions
{
	extension(ChatMessageController controller)
	{
		public async Task ShouldThrowChatNotFoundExceptionAsync(
			AddChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.AddAsync(request, cancellationToken);

			await func.ShouldThrowChatNotFoundExceptionAsync(
				request,
				r => r.ParticipantOneId,
				r => r.ParticipantTwoId,
				cancellationToken);
		}

		public async Task ShouldThrowChatNotFoundExceptionAsync(
			UpdateChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.UpdateAsync(request, cancellationToken);

			await func.ShouldThrowChatNotFoundExceptionAsync(
				request,
				r => r.ParticipantOneId,
				r => r.ParticipantTwoId,
				cancellationToken);
		}

		public async Task ShouldThrowChatNotFoundExceptionAsync(
			DeleteChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowChatNotFoundExceptionAsync(
				request,
				r => r.ParticipantOneId,
				r => r.ParticipantTwoId,
				cancellationToken);
		}

		public async Task ShouldThrowChatNotFoundExceptionAsync(
			GetChatMessageByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetByIdAsync(request, cancellationToken);

			await func.ShouldThrowChatNotFoundExceptionAsync(
				request,
				r => r.CurrentUserId,
				r => r.ParticipantTwoId,
				cancellationToken);
		}

		public async Task ShouldThrowChatNotFoundExceptionAsync(
			GetAllChatMessagesApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetAllAsync(request, cancellationToken);

			await func.ShouldThrowChatNotFoundExceptionAsync(
				request,
				r => r.CurrentUserId,
				r => r.ParticipantTwoId,
				cancellationToken);
		}

		public async Task ShouldThrowChatMessageNotFoundExceptionAsync(
			UpdateChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.UpdateAsync(request, cancellationToken);

			await func.ShouldThrowChatMessageNotFoundExceptionAsync(
				request,
				r => r.ParticipantOneId,
				r => r.ParticipantTwoId,
				r => r.MessageId,
				cancellationToken);
		}

		public async Task ShouldThrowChatMessageNotFoundExceptionAsync(
			DeleteChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowChatMessageNotFoundExceptionAsync(
				request,
				r => r.ParticipantOneId,
				r => r.ParticipantTwoId,
				r => r.MessageId,
				cancellationToken);
		}

		public async Task ShouldThrowChatMessageNotFoundExceptionAsync(
			GetChatMessageByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetByIdAsync(request, cancellationToken);

			await func.ShouldThrowChatMessageNotFoundExceptionAsync(
				request,
				r => r.CurrentUserId,
				r => r.ParticipantTwoId,
				r => r.MessageId,
				cancellationToken);
		}

		public async Task ShouldThrowChatMessageForbiddenExceptionAsync(
			UpdateChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.UpdateAsync(request, cancellationToken);

			await func.ShouldThrowChatMessageForbiddenExceptionAsync(
				request,
				r => r.ParticipantOneId,
				r => r.ParticipantTwoId,
				r => r.MessageId,
				r => r.ParticipantOneId,
				cancellationToken);
		}

		public async Task ShouldThrowChatMessageForbiddenExceptionAsync(
			DeleteChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.DeleteAsync(request, cancellationToken);

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
