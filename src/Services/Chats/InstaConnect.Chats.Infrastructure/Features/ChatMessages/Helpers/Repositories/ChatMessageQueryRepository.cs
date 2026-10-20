using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Domain.Features.Chats.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Repositories;

internal class ChatMessageQueryRepository : IChatMessageQueryRepository
{
	private readonly IChatMessageCollection _collection;
	private readonly IChatIncludeBuilderFactory _includeBuilderFactory;
	private readonly IChatMessageIncludeBuilderFactory _messageIncludeBuilderFactory;

	public ChatMessageQueryRepository(
		IChatMessageCollection collection,
		IChatIncludeBuilderFactory includeBuilderFactory,
		IChatMessageIncludeBuilderFactory messageIncludeBuilderFactory)
	{
		_collection = collection;
		_includeBuilderFactory = includeBuilderFactory;
		_messageIncludeBuilderFactory = messageIncludeBuilderFactory;
	}

	public async Task<ICollection<ChatMessageResponse>> GetAllAsync(
		ChatMessagesFilterQuery filter,
		ChatMessagesSortingQuery sorting,
		ChatMessagesPaginationQuery pagination,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var messageInclude = _messageIncludeBuilderFactory.Create().WithSender().WithChatMessageImages().Build();

		return await _collection
			.AggregateFluent()
			.ApplyIncludes(messageInclude)
			.Match(filter)
			.ProjectToResponseWithoutChat(currentUser)
			.ApplySorting(sorting)
			.ApplyPagination(pagination)
			.ToListAsync(cancellationToken);
	}

	public async Task<long> GetTotalCountAsync(
		ChatMessagesFilterQuery filter,
		CancellationToken cancellationToken)
	{
		var messageInclude = _messageIncludeBuilderFactory.Create().WithSender().WithChatMessageImages().Build();

		return await _collection
			.AggregateFluent()
			.ApplyIncludes(messageInclude)
			.Match(filter)
			.GetCountAsync(cancellationToken);
	}

	public async Task<ChatMessageResponse?> GetByIdAsync(
		ChatMessageId id,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithParticipantOne().WithParticipantTwo().Build();
		var messageInclude = _messageIncludeBuilderFactory.Create().WithSender().WithChat(include).WithChatMessageImages().Build();

		return await _collection
			.AggregateFluent()
			.ApplyIncludes(messageInclude)
			.Match(id)
			.ProjectToFullResponse(currentUser)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<bool> ExistsByIdAsync(
		ChatMessageId id,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(id)
			.AnyAsync(cancellationToken);
	}
}
