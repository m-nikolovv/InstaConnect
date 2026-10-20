using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;

namespace InstaConnect.Chats.Domain.Tests.Features.Chats.Utilities;

public static class ChatMockSetups
{
	extension(IDateTimeProvider dateTimeProvider)
	{
		public void SetupGetOffsetUtcNow(Chat chat)
		{
			dateTimeProvider.SetupGetOffsetUtcNow(chat.CreatedAtUtc);
		}
	}

	extension(IChatFactory factory)
	{
		public void SetupCreate(
			AddChatCommand command,
			Chat chat)
		{
			factory.SetupCreate(
				command.ParticipantOneId,
				command.ParticipantTwoId,
				chat.To(command));
		}

		public void SetupCreate(
			UserId participantOneId,
			UserId participantTwoId,
			Chat chat)
		{
			factory
				.Create(
					participantOneId,
					participantTwoId)
				.ReturnsResponse(chat);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public void SetupGetParticipantOneByIdAsync(
			AddChatCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.ParticipantOneId, user, cancellationToken);
		}

		public void SetupGetParticipantTwoByIdAsync(
			AddChatCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.ParticipantTwoId, user, cancellationToken);
		}

		public void RemoveGetParticipantOneByIdAsync(
			AddChatCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.ParticipantOneId, null, cancellationToken);
		}

		public void RemoveGetParticipantTwoByIdAsync(
			AddChatCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(command.ParticipantTwoId, null, cancellationToken);
		}
	}

	extension(IChatCommandRepository repository)
	{
		public void RemoveGetByIdAsync(
			AddChatCommand command,
			Chat chat,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(chat.Id, null, cancellationToken);
		}

		public void SetupGetByIdAsync(
			AddChatCommand command,
			Chat chat,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(chat.Id, chat, cancellationToken);
		}

		public void SetupGetByIdAsync(
			ChatId id,
			Chat? chat,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(id, cancellationToken)
				.ReturnsTaskResponse(chat);
		}

		public void SetupGetByIdAsync(
			ChatId id,
			ChatInclude include,
			Chat? chat,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(id, include, cancellationToken)
				.ReturnsTaskResponse(chat);
		}

		public void SetupExistsByIdAsync(
			ChatId id,
			bool exists,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(id, cancellationToken)
				.ReturnsTaskResponse(exists);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public void SetupGetByIdAsync(
			GetAllChatsQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Filter.ParticipantOneId, query.CurrentUser, user.ToResponse(query), cancellationToken);
		}

		public void RemoveGetByIdAsync(
			GetAllChatsQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Filter.ParticipantOneId, query.CurrentUser, null, cancellationToken);
		}
	}

	extension(IChatQueryRepository repository)
	{
		public void SetupGetAllAsync(
			GetAllChatsQuery query,
			ICollection<Chat> chats,
			CancellationToken cancellationToken)
		{
			repository.SetupGetAllAsync(query.Filter, query.Sorting, query.Pagination, query.CurrentUser, chats.ToResponse(query), cancellationToken);
		}

		public void SetupGetAllAsync(
			ChatsFilterQuery filter,
			ChatsSortingQuery sorting,
			ChatsPaginationQuery pagination,
			CurrentUserQuery currentUser,
			ICollection<ChatResponse> responses,
			CancellationToken cancellationToken)
		{
			repository
				.GetAllAsync(filter, sorting, pagination, currentUser, cancellationToken)
				.ReturnsTaskResponse(responses);
		}

		public void SetupGetTotalCountAsync(
			GetAllChatsQuery query,
			ICollection<Chat> chats,
			CancellationToken cancellationToken)
		{
			repository.SetupGetTotalCountAsync(query.Filter, chats.ToTotalCountResponse(query), cancellationToken);
		}

		public void SetupGetTotalCountAsync(
			ChatsFilterQuery filter,
			long totalCount,
			CancellationToken cancellationToken)
		{
			repository
				.GetTotalCountAsync(filter, cancellationToken)
				.ReturnsTaskResponse(totalCount);
		}

		public void SetupGetByIdAsync(
			GetChatByIdQuery query,
			Chat chat,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Id, query.CurrentUser, chat.ToResponse(query), cancellationToken);
		}

		public void SetupGetByIdAsync(
			ChatId id,
			CurrentUserQuery currentUser,
			ChatResponse? response,
			CancellationToken cancellationToken)
		{
			repository
				.GetByIdAsync(id, currentUser, cancellationToken)
				.ReturnsTaskResponse(response);
		}

		public void RemoveGetByIdAsync(
			GetChatByIdQuery query,
			Chat chat,
			CancellationToken cancellationToken)
		{
			repository.SetupGetByIdAsync(query.Id, query.CurrentUser, null, cancellationToken);
		}

		public void SetupExistsByIdAsync(
			ChatId id,
			bool exists,
			CancellationToken cancellationToken)
		{
			repository
				.ExistsByIdAsync(id, cancellationToken)
				.ReturnsTaskResponse(exists);
		}
	}

	extension(IChatQueryService service)
	{
		public void SetupGetAllAsync(
			GetAllChatsQuery query,
			ChatCollectionResponse response,
			CancellationToken cancellationToken)
		{
			service
				.GetAllAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}

		public void SetupGetByIdAsync(
			GetChatByIdQuery query,
			ChatResponse response,
			CancellationToken cancellationToken)
		{
			service
				.GetByIdAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}
	}

	extension(IChatCommandService service)
	{
		public void SetupAddAsync(
			AddChatCommand command,
			ChatId id,
			CancellationToken cancellationToken)
		{
			service
				.AddAsync(command, cancellationToken)
				.ReturnsTaskResponse(id);
		}
	}
}
