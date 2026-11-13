using InstaConnect.Chats.Domain.Features.Chats.Models.ValueObjects;
using InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.Chats.Assertions;

public static class ChatMockAssertions
{
	extension(IChatCollection collection)
	{
		public void ShouldHaveReceivedOneAggregateFluent(ChatId id)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(ICollection<ChatId> ids)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(
			ChatId id,
			CurrentUserQuery currentUserQuery)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(ChatsFilterQuery filterQuery)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent()
		{
			collection.ShouldHaveReceivedOne().AggregateFluent();
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			Chat chat,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().AddAsync(chat, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddRangeAsync(
			ICollection<Chat> chats,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().AddRangeAsync(chats, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			Chat chat,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().DeleteAsync(chat, cancellationToken);
		}
	}

	extension(IChatFluent fluent)
	{
		public void ShouldHaveReceivedOneMatch(ChatsFilterQuery filterQuery)
		{
			fluent.ShouldHaveReceivedOne().Match(filterQuery);
		}

		public void ShouldHaveReceivedOneMatch(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneMatch(filterQuery);
		}

		public void ShouldHaveReceivedOneMatch(ChatId id)
		{
			fluent.ShouldHaveReceivedOne().Match(id);
		}

		public void ShouldHaveReceivedOneMatch(ICollection<ChatId> ids)
		{
			fluent.ShouldHaveReceivedOne().Match(ids);
		}

		public void ShouldHaveReceivedOneMatch(
			ChatId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneMatch(id);
		}

		public void ShouldHaveReceivedOneInclude(
			ChatId id,
			ChatInclude include)
		{
			fluent.ShouldHaveReceivedOneInclude(include);
		}

		public void ShouldHaveReceivedOneInclude(
			ICollection<ChatId> ids,
			ChatInclude include)
		{
			fluent.ShouldHaveReceivedOneInclude(include);
		}

		public void ShouldHaveReceivedOneInclude(
			ChatId id,
			CurrentUserQuery currentUserQuery,
			ChatInclude include)
		{
			fluent.ShouldHaveReceivedOneInclude(include);
		}

		public void ShouldHaveReceivedOneInclude(
			ChatsFilterQuery filterQuery,
			ChatInclude include)
		{
			fluent.ShouldHaveReceivedOneInclude(include);
		}

		public void ShouldHaveReceivedOneInclude(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ChatInclude include)
		{
			fluent.ShouldHaveReceivedOneInclude(include);
		}

		public void ShouldHaveReceivedOneInclude(ChatInclude include)
		{
			fluent.ShouldHaveReceivedOne().Include(include);
		}

		public void ShouldHaveReceivedOneProjectToFullResponse(
			ChatId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneProjectToFullResponse(currentUserQuery);
		}

		public void ShouldHaveReceivedOneProjectToFullResponse(CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().ProjectToFullResponse(currentUserQuery);
		}

		public void ShouldHaveReceivedOneProjectToResponseWithoutParticipantOne(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneProjectToResponseWithoutParticipantOne(currentUserQuery);
		}

		public void ShouldHaveReceivedOneProjectToResponseWithoutParticipantOne(CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOne().ProjectToResponseWithoutParticipantOne(currentUserQuery);
		}

		public async Task ShouldHaveReceivedOneAnyAsync(
			ChatId id,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneAnyAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetCountAsync(
			ChatsFilterQuery filterQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneGetCountAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneFirstOrDefaultAsync(
			ChatId id,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneToListAsync(
			ICollection<ChatId> ids,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneToListAsync(cancellationToken);
		}
	}

	extension(IChatResponseFluent fluent)
	{
		public void ShouldHaveReceivedOneSort(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneSort(sortingQuery);
		}

		public void ShouldHaveReceivedOneSort(ChatsSortingQuery sortingQuery)
		{
			fluent.ShouldHaveReceivedOne().Sort(sortingQuery);
		}

		public void ShouldHaveReceivedOnePaginate(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOnePaginate(paginationQuery);
		}

		public void ShouldHaveReceivedOnePaginate(ChatsPaginationQuery paginationQuery)
		{
			fluent.ShouldHaveReceivedOne().Paginate(paginationQuery);
		}

		public async Task ShouldHaveReceivedOneFirstOrDefaultAsync(
			ChatId id,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneToListAsync(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneToListAsync(cancellationToken);
		}
	}
}
