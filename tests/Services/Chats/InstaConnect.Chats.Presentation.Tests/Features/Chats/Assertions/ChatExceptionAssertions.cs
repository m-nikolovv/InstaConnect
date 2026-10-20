namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Assertions;

public static class ChatExceptionAssertions
{
	extension(ChatController controller)
	{
		public async Task ShouldThrowParticipantOneNotFoundExceptionAsync(
			AddChatApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.AddAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.ParticipantOneId,
				cancellationToken);
		}

		public async Task ShouldThrowParticipantOneNotFoundExceptionAsync(
			GetAllChatsApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetAllAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.CurrentUserId,
				cancellationToken);
		}

		public async Task ShouldThrowParticipantTwoNotFoundExceptionAsync(
			AddChatApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.AddAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.Body.ParticipantTwoId,
				cancellationToken);
		}

		public async Task ShouldThrowChatNotFoundExceptionAsync(
			GetChatByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetByIdAsync(request, cancellationToken);

			await func.ShouldThrowChatNotFoundExceptionAsync(
				request,
				r => r.CurrentUserId,
				r => r.ParticipantTwoId,
				cancellationToken);
		}

		public async Task ShouldThrowChatAlreadyExistsExceptionAsync(
			AddChatApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.AddAsync(request, cancellationToken);

			await func.ShouldThrowChatAlreadyExistsExceptionAsync(
				request,
				r => r.ParticipantOneId,
				r => r.Body.ParticipantTwoId,
				cancellationToken);
		}
	}
}
