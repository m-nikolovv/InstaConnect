using InstaConnect.Chats.Domain.Features.Chats.Models.ValueObjects;
using InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.Chats.Utilities;

public static class ChatMockSetups
{
	extension(IChatCollection collection)
	{
		public void SetupAggregateFluent(
			ChatId id,
			IChatFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			ICollection<ChatId> ids,
			IChatFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			ChatId id,
			CurrentUserQuery currentUserQuery,
			IChatFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IChatFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			ChatsFilterQuery filterQuery,
			IChatFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(IChatFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}
	}

	extension(IChatFluent fluent)
	{
		public void SetupGetCountAsync(
			ChatsFilterQuery filterQuery,
			ICollection<Chat> chats,
			CancellationToken cancellationToken)
		{
			fluent.SetupGetCountAsync(chats.ToTotalCountResponse(filterQuery), cancellationToken);
		}

		public void SetupAnyAsync(
			ChatId id,
			Chat? chat,
			CancellationToken cancellationToken)
		{
			fluent.SetupAnyAsync(chat != null, cancellationToken);
		}

		public void SetupInclude(
			ChatId id,
			ChatInclude include)
		{
			fluent.SetupInclude(include);
		}

		public void SetupInclude(
			ICollection<ChatId> ids,
			ChatInclude include)
		{
			fluent.SetupInclude(include);
		}

		public void SetupInclude(
			ChatId id,
			CurrentUserQuery currentUserQuery,
			ChatInclude include)
		{
			fluent.SetupInclude(include);
		}

		public void SetupInclude(
			ChatsFilterQuery filterQuery,
			ChatInclude include)
		{
			fluent.SetupInclude(include);
		}

		public void SetupInclude(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ChatInclude include)
		{
			fluent.SetupInclude(include);
		}

		public void SetupInclude(ChatInclude include)
		{
			fluent.Include(include).ReturnsResponse(fluent);
		}

		public void SetupMatch(ChatId id)
		{
			fluent.Match(id).ReturnsResponse(fluent);
		}

		public void SetupMatch(ICollection<ChatId> ids)
		{
			fluent.Match(ids).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			ChatId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupMatch(id);
		}

		public void SetupMatch(ChatsFilterQuery filterQuery)
		{
			fluent.Match(filterQuery).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupMatch(filterQuery);
		}

		public void SetupProjectToFullResponse(
			ChatId id,
			CurrentUserQuery currentUserQuery,
			IChatResponseFluent responseFluent)
		{
			fluent.SetupProjectToFullResponse(currentUserQuery, responseFluent);
		}

		public void SetupProjectToFullResponse(
			CurrentUserQuery currentUserQuery,
			IChatResponseFluent responseFluent)
		{
			fluent.ProjectToFullResponse(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupProjectToResponseWithoutParticipantOne(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IChatResponseFluent responseFluent)
		{
			fluent.SetupProjectToResponseWithoutParticipantOne(currentUserQuery, responseFluent);
		}

		public void SetupProjectToResponseWithoutParticipantOne(
			CurrentUserQuery currentUserQuery,
			IChatResponseFluent responseFluent)
		{
			fluent.ProjectToResponseWithoutParticipantOne(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupFirstOrDefaultAsync(
			ChatId id,
			Chat chat,
			CancellationToken cancellationToken)
		{
			fluent.SetupFirstOrDefaultAsync(chat, cancellationToken);
		}

		public void SetupToListAsync(
			ICollection<ChatId> ids,
			ICollection<Chat> chats,
			CancellationToken cancellationToken)
		{
			fluent.SetupToListAsync(chats, cancellationToken);
		}
	}

	extension(IChatResponseFluent fluent)
	{
		public void SetupSort(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupSort(sortingQuery);
		}

		public void SetupSort(ChatsSortingQuery sortingQuery)
		{
			fluent.Sort(sortingQuery).ReturnsResponse(fluent);
		}

		public void SetupPaginate(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupPaginate(paginationQuery);
		}

		public void SetupPaginate(ChatsPaginationQuery paginationQuery)
		{
			fluent.Paginate(paginationQuery).ReturnsResponse(fluent);
		}

		public void SetupToListAsync(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<Chat> chats,
			CancellationToken cancellationToken)
		{
			fluent.SetupToListAsync(chats.ToResponse(filterQuery, paginationQuery), cancellationToken);
		}

		public void SetupFirstOrDefaultAsync(
			ChatId id,
			CurrentUserQuery currentUserQuery,
			Chat chat,
			CancellationToken cancellationToken)
		{
			fluent.SetupFirstOrDefaultAsync(chat.ToFullResponse(), cancellationToken);
		}
	}
}
