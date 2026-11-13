using InstaConnect.Chats.Domain.Features.ChatMessages.Models.ValueObjects;
using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageMockAssertions
{
	extension(IChatMessageCollection collection)
	{
		public void ShouldHaveReceivedOneAggregateFluent(ChatMessageId id)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(ICollection<ChatMessageId> ids)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(
			ChatMessageId id,
			CurrentUserQuery currentUserQuery)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(ChatMessagesFilterQuery filterQuery)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(
			ChatMessagesFilterQuery filterQuery,
			ChatMessagesSortingQuery sortingQuery,
			ChatMessagesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent()
		{
			collection.ShouldHaveReceivedOne().AggregateFluent();
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().AddAsync(chatMessage, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddRangeAsync(
			ICollection<ChatMessage> chatMessages,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().AddRangeAsync(chatMessages, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().UpdateAsync(chatMessage, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().DeleteAsync(chatMessage, cancellationToken);
		}
	}

	extension(IChatMessageFluent fluent)
	{
		public void ShouldHaveReceivedOneMatch(ChatMessagesFilterQuery filterQuery)
		{
			fluent.ShouldHaveReceivedOne().Match(filterQuery);
		}

		public void ShouldHaveReceivedOneMatch(
			ChatMessagesFilterQuery filterQuery,
			ChatMessagesSortingQuery sortingQuery,
			ChatMessagesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneMatch(filterQuery);
		}

		public void ShouldHaveReceivedOneMatch(ChatMessageId id)
		{
			fluent.ShouldHaveReceivedOne().Match(id);
		}

		public void ShouldHaveReceivedOneMatch(ICollection<ChatMessageId> ids)
		{
			fluent.ShouldHaveReceivedOne().Match(ids);
		}

		public void ShouldHaveReceivedOneMatch(
			ChatMessageId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneMatch(id);
		}

		public void ShouldHaveReceivedOneInclude(
			ChatMessageId id,
			ChatMessageInclude include)
		{
			fluent.ShouldHaveReceivedOneInclude(include);
		}

		public void ShouldHaveReceivedOneInclude(
			ICollection<ChatMessageId> ids,
			ChatMessageInclude include)
		{
			fluent.ShouldHaveReceivedOneInclude(include);
		}

		public void ShouldHaveReceivedOneInclude(
			ChatMessageId id,
			CurrentUserQuery currentUserQuery,
			ChatMessageInclude include)
		{
			fluent.ShouldHaveReceivedOneInclude(include);
		}

		public void ShouldHaveReceivedOneInclude(
			ChatMessagesFilterQuery filterQuery,
			ChatMessageInclude include)
		{
			fluent.ShouldHaveReceivedOneInclude(include);
		}

		public void ShouldHaveReceivedOneInclude(
			ChatMessagesFilterQuery filterQuery,
			ChatMessagesSortingQuery sortingQuery,
			ChatMessagesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ChatMessageInclude include)
		{
			fluent.ShouldHaveReceivedOneInclude(include);
		}

		public void ShouldHaveReceivedOneInclude(ChatMessageInclude include)
		{
			fluent.ShouldHaveReceivedOne().Include(include);
		}

		public void ShouldHaveReceivedOneProjectToFullResponse(
			ChatMessageId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneProjectToFullResponse(currentUserQuery);
		}

		public void ShouldHaveReceivedOneProjectToFullResponse(CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().ProjectToFullResponse(currentUserQuery);
		}

		public void ShouldHaveReceivedOneProjectToResponseWithoutChat(
			ChatMessagesFilterQuery filterQuery,
			ChatMessagesSortingQuery sortingQuery,
			ChatMessagesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneProjectToResponseWithoutChat(currentUserQuery);
		}

		public void ShouldHaveReceivedOneProjectToResponseWithoutChat(CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().ProjectToResponseWithoutChat(currentUserQuery);
		}

		public async Task ShouldHaveReceivedOneAnyAsync(
			ChatMessageId id,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneAnyAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetCountAsync(
			ChatMessagesFilterQuery filterQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneGetCountAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneFirstOrDefaultAsync(
			ChatMessageId id,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneToListAsync(
			ICollection<ChatMessageId> ids,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneToListAsync(cancellationToken);
		}
	}

	extension(IChatMessageResponseFluent fluent)
	{
		public void ShouldHaveReceivedOneSort(
			ChatMessagesFilterQuery filterQuery,
			ChatMessagesSortingQuery sortingQuery,
			ChatMessagesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneSort(sortingQuery);
		}

		public void ShouldHaveReceivedOneSort(ChatMessagesSortingQuery sortingQuery)
		{
			fluent.ShouldHaveReceivedOne().Sort(sortingQuery);
		}

		public void ShouldHaveReceivedOnePaginate(
			ChatMessagesFilterQuery filterQuery,
			ChatMessagesSortingQuery sortingQuery,
			ChatMessagesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOnePaginate(paginationQuery);
		}

		public void ShouldHaveReceivedOnePaginate(ChatMessagesPaginationQuery paginationQuery)
		{
			fluent.ShouldHaveReceivedOne().Paginate(paginationQuery);
		}

		public async Task ShouldHaveReceivedOneFirstOrDefaultAsync(
			ChatMessageId id,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneToListAsync(
			ChatMessagesFilterQuery filterQuery,
			ChatMessagesSortingQuery sortingQuery,
			ChatMessagesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneToListAsync(cancellationToken);
		}
	}
}
