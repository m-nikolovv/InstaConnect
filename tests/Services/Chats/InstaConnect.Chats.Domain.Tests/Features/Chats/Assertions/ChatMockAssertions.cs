using InstaConnect.Common.Events.Features.Events.Abstractions;

namespace InstaConnect.Chats.Domain.Tests.Features.Chats.Assertions;

public static class ChatMockAssertions
{
	extension(IChatFactory factory)
	{
		public void ShouldHaveReceivedOneCreate(
			AddChatCommand command)
		{
			factory.ShouldHaveReceivedOneCreate(
				command.ParticipantOneId,
				command.ParticipantTwoId);
		}

		public void ShouldHaveReceivedOneCreate(
			UserId participantOneId,
			UserId participantTwoId)
		{
			factory.ShouldHaveReceivedOne().Create(
				participantOneId,
				participantTwoId);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByParticipantOneIdAsync(
			AddChatCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				command.ParticipantOneId,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByParticipantTwoIdAsync(
			AddChatCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				command.ParticipantTwoId,
				cancellationToken);
		}
	}

	extension(IChatCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			AddChatCommand command,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				chat.Id,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			ChatId id,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				id,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			ChatId id,
			ChatInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneExistsByIdAsync(
			ChatId id,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().ExistsByIdAsync(
				id,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			AddChatCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneAddAsync(command.IsChat(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			Chat chat,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(chat, cancellationToken);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetAllChatsQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				query.Filter.ParticipantOneId,
				query.CurrentUser,
				cancellationToken);
		}
	}

	extension(IChatQueryRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(
			GetAllChatsQuery query,
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
			ChatsFilterQuery filter,
			ChatsSortingQuery sorting,
			ChatsPaginationQuery pagination,
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
			GetAllChatsQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetTotalCountAsync(
				query.Filter,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetTotalCountAsync(
			ChatsFilterQuery filter,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetTotalCountAsync(
				filter,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetChatByIdQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOneGetByIdAsync(
				query.Id,
				query.CurrentUser,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			ChatId id,
			CurrentUserQuery currentUser,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				id,
				currentUser,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneExistsByIdAsync(
			ChatId id,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().ExistsByIdAsync(
				id,
				cancellationToken);
		}
	}

	extension(IEventPublisher eventPublisher)
	{
		public async Task ShouldHaveReceivedOnePublishAsync(
			AddChatCommand command,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOnePublishAsync(command.IsChatAddedEventRequest(chat), cancellationToken);
		}
	}

	extension(IChatQueryService service)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(
			GetAllChatsQuery query,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().GetAllAsync(query, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetChatByIdQuery query,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().GetByIdAsync(query, cancellationToken);
		}
	}

	extension(IChatCommandService service)
	{
		public async Task ShouldHaveReceivedOneAddAsync(
			AddChatCommand command,
			CancellationToken cancellationToken)
		{
			await service.ShouldHaveReceivedOne().AddAsync(command, cancellationToken);
		}
	}
}
