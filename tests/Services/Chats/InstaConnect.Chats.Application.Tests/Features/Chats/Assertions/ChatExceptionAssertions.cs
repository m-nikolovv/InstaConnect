using InstaConnect.Common.Application.Features.Requests.Abstractions;

namespace InstaConnect.Chats.Application.Tests.Features.Chats.Assertions;

public static class ChatExceptionAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldThrowParticipantOneNotFoundExceptionAsync(
			GetAllChatsQueryRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.CurrentUserId,
				cancellationToken);
		}

		public async Task ShouldThrowParticipantOneNotFoundExceptionAsync(
			AddChatCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.ParticipantOneId,
				cancellationToken);
		}

		public async Task ShouldThrowParticipantTwoNotFoundExceptionAsync(
			AddChatCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.ParticipantTwoId,
				cancellationToken);
		}

		public async Task ShouldThrowChatNotFoundExceptionAsync(
			GetChatByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowChatNotFoundExceptionAsync(
				request,
				r => r.CurrentUserId,
				r => r.ParticipantTwoId,
				cancellationToken);
		}

		public async Task ShouldThrowChatAlreadyExistsExceptionAsync(
			AddChatCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowChatAlreadyExistsExceptionAsync(
				request,
				r => r.ParticipantOneId,
				r => r.ParticipantTwoId,
				cancellationToken);
		}
	}
}
