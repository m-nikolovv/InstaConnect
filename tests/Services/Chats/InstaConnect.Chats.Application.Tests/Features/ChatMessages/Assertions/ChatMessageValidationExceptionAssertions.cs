using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;

namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageValidationExceptionAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldThrowInvalidValidationExceptionForParticipantOneIdAsync(
			AddChatMessageCommandRequest request,
			IStringMessageTransformer messageTransformer,
		CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.ParticipantOneId,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForParticipantOneIdAsync(
			UpdateChatMessageCommandRequest request,
			IStringMessageTransformer messageTransformer,
		CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.ParticipantOneId,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForParticipantOneIdAsync(
			DeleteChatMessageCommandRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.ParticipantOneId,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForParticipantTwoIdAsync(
			AddChatMessageCommandRequest request,
			IStringMessageTransformer messageTransformer,
		CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.ParticipantTwoId,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForParticipantTwoIdAsync(
			UpdateChatMessageCommandRequest request,
			IStringMessageTransformer messageTransformer,
		CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.ParticipantTwoId,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForParticipantTwoIdAsync(
			DeleteChatMessageCommandRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.ParticipantTwoId,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForParticipantTwoIdAsync(
			GetChatMessageByIdQueryRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.ParticipantTwoId,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForParticipantTwoIdAsync(
			GetAllChatMessagesQueryRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.ParticipantTwoId,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForMessageIdAsync(
			UpdateChatMessageCommandRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.MessageId,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForMessageIdAsync(
			DeleteChatMessageCommandRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.MessageId,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForMessageIdAsync(
			GetChatMessageByIdQueryRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.MessageId,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForContentAsync(
			AddChatMessageCommandRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.Content,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForContentAsync(
			UpdateChatMessageCommandRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.Content,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
			GetChatMessageByIdQueryRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.CurrentUserId,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
			GetAllChatMessagesQueryRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.CurrentUserId,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForPageAsync(
			GetAllChatMessagesQueryRequest request,
			IIntMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.Page,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForPageSizeAsync(
			GetAllChatMessagesQueryRequest request,
			IIntMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.PageSize,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForSortOrderAsync(
			GetAllChatMessagesQueryRequest request,
			IEnumMessageTransformer<CommonSortOrder> messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.SortOrder,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForSortTermAsync(
			GetAllChatMessagesQueryRequest request,
			IEnumMessageTransformer<ChatMessagesSortTerm> messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.SortTerm,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForImagesAsync(
			AddChatMessageCommandRequest request,
			IFormFileCollectionMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.Images,
				messageTransformer,
				cancellationToken);
		}
	}
}
