using InstaConnect.Chats.Domain.Features.ChatMessages.Models.ValueObjects;
using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageMockSetups
{
	extension(IChatMessageCollection collection)
	{
		public void SetupAggregateFluent(
			ChatMessageId id,
			IChatMessageFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			ChatMessageId id,
			CurrentUserQuery currentUserQuery,
			IChatMessageFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			ChatMessagesFilterQuery filterQuery,
			ChatMessagesSortingQuery sortingQuery,
			ChatMessagesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IChatMessageFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			ChatMessagesFilterQuery filterQuery,
			IChatMessageFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(IChatMessageFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}
	}

	extension(IChatMessageFluent fluent)
	{
		public void SetupGetCountAsync(
			ChatMessagesFilterQuery filterQuery,
			ICollection<ChatMessage> chatMessages,
			CancellationToken cancellationToken)
		{
			fluent.SetupGetCountAsync(chatMessages.ToTotalCountResponse(filterQuery), cancellationToken);
		}

		public void SetupAnyAsync(
			ChatMessageId id,
			ChatMessage? chatMessage,
			CancellationToken cancellationToken)
		{
			fluent.SetupAnyAsync(chatMessage != null, cancellationToken);
		}

		public void SetupApplyIncludes(
			ChatMessageId id,
			ChatMessageInclude include)
		{
			fluent.SetupApplyIncludes(include);
		}

		public void SetupApplyIncludes(
			ChatMessageId id,
			CurrentUserQuery currentUserQuery,
			ChatMessageInclude include)
		{
			fluent.SetupApplyIncludes(include);
		}

		public void SetupApplyIncludes(
			ChatMessagesFilterQuery filterQuery,
			ChatMessageInclude include)
		{
			fluent.SetupApplyIncludes(include);
		}

		public void SetupApplyIncludes(
			ChatMessagesFilterQuery filterQuery,
			ChatMessagesSortingQuery sortingQuery,
			ChatMessagesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ChatMessageInclude include)
		{
			fluent.SetupApplyIncludes(include);
		}

		public void SetupApplyIncludes(ChatMessageInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupMatch(ChatMessageId id)
		{
			fluent.Match(id).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			ChatMessageId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupMatch(id);
		}

		public void SetupMatch(ChatMessagesFilterQuery filterQuery)
		{
			fluent.Match(filterQuery).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			ChatMessagesFilterQuery filterQuery,
			ChatMessagesSortingQuery sortingQuery,
			ChatMessagesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupMatch(filterQuery);
		}

		public void SetupProjectToFullResponse(
			ChatMessageId id,
			CurrentUserQuery currentUserQuery,
			IChatMessageResponseFluent responseFluent)
		{
			fluent.SetupProjectToFullResponse(currentUserQuery, responseFluent);
		}

		public void SetupProjectToFullResponse(
			CurrentUserQuery currentUserQuery,
			IChatMessageResponseFluent responseFluent)
		{
			fluent.ProjectToFullResponse(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupProjectToResponseWithoutChat(
			ChatMessagesFilterQuery filterQuery,
			ChatMessagesSortingQuery sortingQuery,
			ChatMessagesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IChatMessageResponseFluent responseFluent)
		{
			fluent.SetupProjectToResponseWithoutChat(currentUserQuery, responseFluent);
		}

		public void SetupProjectToResponseWithoutChat(
			CurrentUserQuery currentUserQuery,
			IChatMessageResponseFluent responseFluent)
		{
			fluent.ProjectToResponseWithoutChat(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupFirstOrDefaultAsync(
			ChatMessageId id,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			fluent.SetupFirstOrDefaultAsync(chatMessage, cancellationToken);
		}
	}

	extension(IChatMessageResponseFluent fluent)
	{
		public void SetupApplySorting(
			ChatMessagesFilterQuery filterQuery,
			ChatMessagesSortingQuery sortingQuery,
			ChatMessagesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupApplySorting(sortingQuery);
		}

		public void SetupApplySorting(ChatMessagesSortingQuery sortingQuery)
		{
			fluent.ApplySorting(sortingQuery).ReturnsResponse(fluent);
		}

		public void SetupApplyPagination(
			ChatMessagesFilterQuery filterQuery,
			ChatMessagesSortingQuery sortingQuery,
			ChatMessagesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.SetupApplyPagination(paginationQuery);
		}

		public void SetupApplyPagination(ChatMessagesPaginationQuery paginationQuery)
		{
			fluent.ApplyPagination(paginationQuery).ReturnsResponse(fluent);
		}

		public void SetupToListAsync(
			ChatMessagesFilterQuery filterQuery,
			ChatMessagesSortingQuery sortingQuery,
			ChatMessagesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<ChatMessage> chatMessages,
			CancellationToken cancellationToken)
		{
			fluent.SetupToListAsync(chatMessages.ToResponse(filterQuery, paginationQuery), cancellationToken);
		}

		public void SetupFirstOrDefaultAsync(
			ChatMessageId id,
			CurrentUserQuery currentUserQuery,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			fluent.SetupFirstOrDefaultAsync(chatMessage.ToFullResponse(), cancellationToken);
		}
	}
}
