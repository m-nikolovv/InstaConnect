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

		public void ShouldHaveReceivedOneMatch(
			ChatId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneMatch(id);
		}

		public void ShouldHaveReceivedOneApplyIncludes(
			ChatId id,
			ChatInclude include)
		{
			fluent.ShouldHaveReceivedOneApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneApplyIncludes(
			ChatId id,
			CurrentUserQuery currentUserQuery,
			ChatInclude include)
		{
			fluent.ShouldHaveReceivedOneApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneApplyIncludes(
			ChatsFilterQuery filterQuery,
			ChatInclude include)
		{
			fluent.ShouldHaveReceivedOneApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneApplyIncludes(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ChatInclude include)
		{
			fluent.ShouldHaveReceivedOneApplyIncludes(include);
		}

		public void ShouldHaveReceivedOneApplyIncludes(ChatInclude include)
		{
			fluent.ShouldHaveReceivedOne().ApplyIncludes(include);
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
	}

	extension(IChatResponseFluent fluent)
	{
		public void ShouldHaveReceivedOneApplySorting(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneApplySorting(sortingQuery);
		}

		public void ShouldHaveReceivedOneApplySorting(ChatsSortingQuery sortingQuery)
		{
			fluent.ShouldHaveReceivedOne().ApplySorting(sortingQuery);
		}

		public void ShouldHaveReceivedOneApplyPagination(
			ChatsFilterQuery filterQuery,
			ChatsSortingQuery sortingQuery,
			ChatsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ShouldHaveReceivedOneApplyPagination(paginationQuery);
		}

		public void ShouldHaveReceivedOneApplyPagination(ChatsPaginationQuery paginationQuery)
		{
			fluent.ShouldHaveReceivedOne().ApplyPagination(paginationQuery);
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
