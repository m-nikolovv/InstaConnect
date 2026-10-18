using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Domain.Tests.Features.Chats.Assertions;
using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Images.Abstractions;

namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageMockAssertions
{
	extension(IChatMessageFactory factory)
	{
		public void ShouldHaveReceivedOneCreate(
			AddChatMessageCommand command)
		{
			factory.ShouldHaveReceivedOneCreate(
				command.Id,
				command.Id.ParticipantOneId,
				command.Content);
		}

		public void ShouldHaveReceivedOneCreate(
			ChatId id,
			UserId senderId,
			string content)
		{
			factory.ShouldHaveReceivedOne().Create(
				id,
				senderId,
				content);
		}
	}

	extension(IChatCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			AddChatMessageCommand command,
			ChatInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				command.Id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneExistsByIdAsync(
			UpdateChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneExistsByIdAsync(
				command.Id.Id,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneExistsByIdAsync(
			DeleteChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneExistsByIdAsync(
				command.Id.Id,
				cancellationToken);
		}
	}

	extension(IChatMessageCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			UpdateChatMessageCommand command,
			ChatMessageInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				command.Id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			DeleteChatMessageCommand command,
			ChatMessageInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				command.Id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			ChatMessageId id,
			ChatMessageInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			AddChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneAddAsync(command.IsChatMessage(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(chatMessage, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			UpdateChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneUpdateAsync(command.IsChatMessage(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().UpdateAsync(chatMessage, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeleteChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneDeleteAsync(command.IsChatMessage(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteAsync(chatMessage, cancellationToken);
		}
	}

	extension(IChatQueryRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetAllChatMessagesQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				query.Filter.Id,
				query.CurrentUser,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneExistsByIdAsync(
			GetChatMessageByIdQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneExistsByIdAsync(
				query.Id.Id,
				cancellationToken);
		}
	}

	extension(IChatMessageQueryRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(
			GetAllChatMessagesQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetAllAsync(
				query.Filter,
				query.Sorting,
				query.Pagination,
				query.CurrentUser,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllAsync(
			ChatMessagesFilterQuery filter,
			ChatMessagesSortingQuery sorting,
			ChatMessagesPaginationQuery pagination,
			CurrentUserQuery currentUser,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetAllAsync(
				filter,
				sorting,
				pagination,
				currentUser,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetTotalCountAsync(
			GetAllChatMessagesQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetTotalCountAsync(
				query.Filter,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetTotalCountAsync(
			ChatMessagesFilterQuery filter,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetTotalCountAsync(
				filter,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetChatMessageByIdQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				query.Id,
				query.CurrentUser,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			ChatMessageId id,
			CurrentUserQuery currentUser,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				id,
				currentUser,
				cancellationToken);
		}
	}

	extension(IDateTimeProvider dateTimeProvider)
	{
		public void ShouldHaveReceivedOneGetOffsetUtcNow(UpdateChatMessageCommand command)
		{
			dateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow();
		}
	}

	extension(IChatMessageNotificationService notificationService)
	{
		public async Task ShouldHaveReceivedOneAddedAsync(
			AddChatMessageCommand command,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await notificationService.ShouldHaveReceivedOneAddedAsync(command.IsChatMessageAddedNotificationRequest(chatMessage), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddedAsync(
			ChatMessageAddedNotificationRequest request,
			CancellationToken cancellationToken)
		{
			await notificationService.ShouldHaveReceivedOne().AddedAsync(request, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdatedAsync(
			UpdateChatMessageCommand command,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await notificationService.ShouldHaveReceivedOneUpdatedAsync(command.IsChatMessageUpdatedNotificationRequest(chatMessage), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdatedAsync(
			ChatMessageUpdatedNotificationRequest request,
			CancellationToken cancellationToken)
		{
			await notificationService.ShouldHaveReceivedOne().UpdatedAsync(request, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeletedAsync(
			DeleteChatMessageCommand command,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await notificationService.ShouldHaveReceivedOneDeletedAsync(command.IsChatMessageDeletedNotificationRequest(chatMessage), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeletedAsync(
			ChatMessageDeletedNotificationRequest request,
			CancellationToken cancellationToken)
		{
			await notificationService.ShouldHaveReceivedOne().DeletedAsync(request, cancellationToken);
		}
	}

	extension(IChatMessageQueryService service)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(
			GetAllChatMessagesQuery query,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().GetAllAsync(query, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetChatMessageByIdQuery query,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().GetByIdAsync(query, cancellationToken);
		}
	}

	extension(IChatMessageCommandService service)
	{
		public async Task ShouldHaveReceivedOneAddAsync(
			AddChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().AddAsync(command, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			UpdateChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().UpdateAsync(command, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeleteChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().DeleteAsync(command, cancellationToken);
		}
	}

	extension(IChatMessageSummarizer summarizer)
	{
		public async Task ShouldHaveReceivedOneSummarizeAsync(
			AddChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			await summarizer.ShouldHaveReceivedOneSummarizeAsync(command.IsChatMessage(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneSummarizeAsync(
			UpdateChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			await summarizer.ShouldHaveReceivedOneSummarizeAsync(command.IsChatMessage(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneSummarizeAsync(
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await summarizer.ShouldHaveReceivedOne().SummarizeAsync(chatMessage, cancellationToken);
		}
	}

	extension(IImageHandler imageHandler)
	{
		public async Task ShouldHaveReceivedOneUploadRangeAsync(
			AddChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			await imageHandler.ShouldHaveReceivedOneUploadRangeAsync(command.Images, cancellationToken);
		}

		public async Task ShouldHaveReceivedZeroUploadRangeAsync(
			AddChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			await imageHandler.ShouldHaveReceivedZeroUploadRangeAsync(command.Images, cancellationToken);
		}
	}

	extension(IChatMessageImageFactory factory)
	{
		public void ShouldHaveReceivedOneCreateRange(
			AddChatMessageCommand command,
			ChatMessage chatMessage)
		{
			factory.ShouldHaveReceivedOne().CreateRange(chatMessage.Id, command.IsImages());
		}

		public void ShouldHaveReceivedZeroCreateRange(
			AddChatMessageCommand command,
			ChatMessage chatMessage)
		{
			factory.ShouldHaveReceivedZero().CreateRange(chatMessage.Id, command.IsImages());
		}
	}

	extension(IChatMessageImageCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneAddRangeAsync(
			AddChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddRangeAsync(command.IsChatMessageImages(), cancellationToken);
		}

		public async Task ShouldHaveReceivedZeroAddRangeAsync(
			AddChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedZero().AddRangeAsync(command.IsChatMessageImages(), cancellationToken);
		}
	}
}
