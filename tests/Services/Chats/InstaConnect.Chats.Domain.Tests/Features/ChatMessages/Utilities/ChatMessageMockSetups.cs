using InstaConnect.Chats.Domain.Features.ChatMessageImages.Abstractions;
using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Responses;
using InstaConnect.Common.Domain.Features.Guids.Abstractions;

namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageMockSetups
{
	extension(IGuidProvider guidProvider)
	{
		public void SetupNewStringGuid(ChatMessage chatMessage)
		{
			guidProvider.SetupNewStringGuid(chatMessage.Id.MessageId);
		}
	}

	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(ChatMessage chatMessage)
		{
			dateTimeProvider.SetupGetOffsetUtcNow(chatMessage.CreatedAtUtc);
		}

		public void SetupGetOffsetUtcNow(
			UpdateChatMessageCommand command,
			ChatMessage chatMessage)
		{
			dateTimeProvider.SetupGetOffsetUtcNow(chatMessage.UpdatedAtUtc);
		}
	}

	extension(IChatMessageFactory factory)
	{
		public void SetupCreate(
			AddChatMessageCommand command,
			ChatMessage chatMessage)
		{
			factory.SetupCreate(
				command.Id,
				command.Id.ParticipantOneId,
				command.Content,
				chatMessage.To(command));
		}

		public void SetupCreate(
			ChatId id,
			UserId senderId,
			string content,
			ChatMessage chatMessage)
		{
			factory
				.Create(
					id,
					senderId,
					content)
				.ReturnsResponse(chatMessage);
		}
	}

	extension(IChatCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			AddChatMessageCommand command,
			ChatInclude include,
			Chat chat,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, include, chat, cancellationToken);
		}

		public void RemoveGetByIdAsync(
			AddChatMessageCommand command,
			ChatInclude include,
			Chat chat,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, include, null, cancellationToken);
		}

		public void SetupExistsByIdAsync(
			UpdateChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(command.Id.Id, true, cancellationToken);
		}

		public void SetupExistsByIdAsync(
			DeleteChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(command.Id.Id, true, cancellationToken);
		}

		public void RemoveExistsByIdAsync(
			UpdateChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(command.Id.Id, false, cancellationToken);
		}

		public void RemoveExistsByIdAsync(
			DeleteChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(command.Id.Id, false, cancellationToken);
		}
	}

	extension(IChatMessageCommandRepository repository)
	{
		public void SetupGetByIdAsync(
			UpdateChatMessageCommand command,
			ChatMessageInclude include,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, include, chatMessage, cancellationToken);
		}

		public void SetupGetByIdAsync(
			DeleteChatMessageCommand command,
			ChatMessageInclude include,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, include, chatMessage, cancellationToken);
		}

		public void SetupGetByIdAsync(
			ChatMessageId id,
			ChatMessageInclude include,
			ChatMessage? chatMessage,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(id, include, cancellationToken)
				.ReturnsTaskResponse(chatMessage);
		}

		public void RemoveGetByIdAsync(
			UpdateChatMessageCommand command,
			ChatMessageInclude include,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, include, null, cancellationToken);
		}

		public void RemoveGetByIdAsync(
			DeleteChatMessageCommand command,
			ChatMessageInclude include,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.Id, include, null, cancellationToken);
		}
	}

	extension(IChatQueryRepository repository)
	{
		public void SetupGetByIdAsync(
			GetAllChatMessagesQuery query,
			Chat chat,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Filter.Id, query.CurrentUser, chat.ToResponse(query), cancellationToken);
		}

		public void RemoveGetByIdAsync(
			GetAllChatMessagesQuery query,
			Chat chat,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Filter.Id, query.CurrentUser, null, cancellationToken);
		}

		public void SetupExistsByIdAsync(
			GetChatMessageByIdQuery query,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(query.Id.Id, true, cancellationToken);
		}

		public void RemoveExistsByIdAsync(
			GetChatMessageByIdQuery query,
			CancellationToken cancellationToken)
		{
			repository.SetupExistsByIdAsync(query.Id.Id, false, cancellationToken);
		}
	}

	extension(IChatMessageQueryRepository repository)
	{
		public void SetupGetAllAsync(
			GetAllChatMessagesQuery query,
			ICollection<ChatMessage> chatMessages,
			CancellationToken cancellationToken)
		{
			repository.SetupGetAllAsync(query.Filter, query.Sorting, query.Pagination, query.CurrentUser, chatMessages.ToResponse(query), cancellationToken);
		}

		public void SetupGetAllAsync(
			ChatMessagesFilterQuery filter,
			ChatMessagesSortingQuery sorting,
			ChatMessagesPaginationQuery pagination,
			CurrentUserQuery currentUser,
			ICollection<ChatMessageResponse> responses,
			CancellationToken cancellationToken)
		{
			repository
				.GetAllAsync(filter, sorting, pagination, currentUser, cancellationToken)
				.ReturnsTaskResponse(responses);
		}

		public void SetupGetTotalCountAsync(
			GetAllChatMessagesQuery query,
			ICollection<ChatMessage> chatMessages,
			CancellationToken cancellationToken)
		{
			repository.SetupGetTotalCountAsync(query.Filter, chatMessages.ToTotalCountResponse(query), cancellationToken);
		}

		public void SetupGetTotalCountAsync(
			ChatMessagesFilterQuery filter,
			long totalCount,
			CancellationToken cancellationToken)
		{
			repository
				.GetTotalCountAsync(filter, cancellationToken)
				.ReturnsTaskResponse(totalCount);
		}

		public void SetupGetByIdAsync(
			GetChatMessageByIdQuery query,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Id, query.CurrentUser, chatMessage.ToResponse(query), cancellationToken);
		}

		public void SetupGetByIdAsync(
			ChatMessageId id,
			CurrentUserQuery currentUser,
			ChatMessageResponse? response,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(id, currentUser, cancellationToken)
				.ReturnsTaskResponse(response);
		}

		public void RemoveGetByIdAsync(
			GetChatMessageByIdQuery query,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Id, query.CurrentUser, null, cancellationToken);
		}
	}

	extension(IChatMessageQueryService service)
	{
		public void SetupGetAllAsync(
			GetAllChatMessagesQuery query,
			ChatMessageCollectionResponse response,
			CancellationToken cancellationToken)
		{
			service
				.GetAllAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}

		public void SetupGetByIdAsync(
			GetChatMessageByIdQuery query,
			ChatMessageResponse response,
			CancellationToken cancellationToken)
		{
			service
				.GetByIdAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}
	}

	extension(IChatMessageCommandService service)
	{
		public void SetupAddAsync(
			AddChatMessageCommand command,
			ChatMessageId id,
			CancellationToken cancellationToken)
		{
			service
				.AddAsync(command, cancellationToken)
				.ReturnsTaskResponse(id);
		}

		public void SetupUpdateAsync(
			UpdateChatMessageCommand command,
			ChatMessageId id,
			CancellationToken cancellationToken)
		{
			service
				.UpdateAsync(command, cancellationToken)
				.ReturnsTaskResponse(id);
		}
	}

	extension(IChatMessageImageFactory factory)
	{
		public void SetupCreateRange(
			AddChatMessageCommand command,
			ChatMessage chatMessage)
		{
			factory.SetupCreateRange(
				chatMessage.Id,
				command.IsImages(),
				chatMessage.ChatMessageImages.To(command));
		}

		public void SetupCreateRange(
			ChatMessageId id,
			ICollection<Url> urls,
			ICollection<ChatMessageImage> chatMessageImages)
		{
			factory
				.CreateRange(id, urls)
				.ReturnsResponse(chatMessageImages);
		}
	}
}
