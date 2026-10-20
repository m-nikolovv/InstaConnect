using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Common.Application.Tests.Features.Assertions;

namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageMockAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldHaveReceivedOneSendAsync(
		GetAllChatMessagesApiRequest request,
		CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOneSendAsync(request.IsGetAllChatMessagesQueryRequest(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneSendAsync(
			GetChatMessageByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOneSendAsync(request.IsGetChatMessageByIdQueryRequest(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneSendAsync(
			AddChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOneSendAsync(request.IsAddChatMessageCommandRequest(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneSendAsync(
			UpdateChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOneSendAsync(request.IsUpdateChatMessageCommandRequest(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneSendAsync(
			DeleteChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOneSendAsync(request.IsDeleteChatMessageCommandRequest(), cancellationToken);
		}
	}
}
