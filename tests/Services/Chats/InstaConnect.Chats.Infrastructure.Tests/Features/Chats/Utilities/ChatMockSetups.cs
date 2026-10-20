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

		public void SetupApplyIncludes(
			ChatId id,
			ChatInclude include)
		{
			fluent.SetupApplyIncludes(include);
		}

		public void SetupApplyIncludes(
			ChatId id,
			CurrentUserQuery currentUserQuery,
			ChatInclude include)
		{
			fluent.SetupApplyIncludes(include);
		}

		public void SetupApplyIncludes(
			ChatsFilterQuery filterQuery,
			ChatInclude include)
		{
			fluent.SetupApplyIncludes(include);
		}

		public void SetupApplyIncludes(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ChatInclude include)
		{
			fluent.SetupApplyIncludes(include);
		}

		public void SetupApplyIncludes(ChatInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupMatch(ChatId id)
		{
			fluent.Match(id).ReturnsResponse(fluent);
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
	}

	extension(IChatResponseFluent fluent)
	{
		public void SetupApplySorting(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupApplySorting(sortingQuery);
		}

		public void SetupApplySorting(ChatsSortingQuery sortingQuery)
		{
			fluent.ApplySorting(sortingQuery).ReturnsResponse(fluent);
		}

		public void SetupApplyPagination(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupApplyPagination(paginationQuery);
		}

		public void SetupApplyPagination(ChatsPaginationQuery paginationQuery)
		{
			fluent.ApplyPagination(paginationQuery).ReturnsResponse(fluent);
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
