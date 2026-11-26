using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Domain.Features.Chats.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Repositories;

internal class ChatMessageQueryRepository : IChatMessageQueryRepository
{
	private readonly IChatMessageCollection _collection;
	private readonly IChatMessageCacheHandler _messageCacheHandler;
	private readonly IChatIncludeBuilderFactory _includeBuilderFactory;
	private readonly IChatMessageIncludeBuilderFactory _messageIncludeBuilderFactory;

	public ChatMessageQueryRepository(
		IChatMessageCollection collection,
		IChatMessageCacheHandler messageCacheHandler,
		IChatIncludeBuilderFactory includeBuilderFactory,
		IChatMessageIncludeBuilderFactory messageIncludeBuilderFactory)
	{
		_collection = collection;
		_messageCacheHandler = messageCacheHandler;
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
			.Match(filter)
			.Include(messageInclude)
			.ProjectToResponseWithoutChat(currentUser)
			.Sort(sorting)
			.Paginate(pagination)
			.ToListAsync(cancellationToken);
	}

	public async Task<long> GetTotalCountAsync(
		ChatMessagesFilterQuery filter,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(filter)
			.GetCountAsync(cancellationToken);
	}

	public async Task<ChatMessageResponse?> GetByIdAsync(
		ChatMessageId id,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var cachedResponse = await _messageCacheHandler.GetByIdAsync(id, currentUser.Id, cancellationToken);

		if (cachedResponse != null)
		{
			return cachedResponse;
		}

		var include = _includeBuilderFactory.Create().WithParticipantOne().WithParticipantTwo().WithChatMessages().Build();
		var messageInclude = _messageIncludeBuilderFactory.Create().WithSender().WithChat(include).WithChatMessageImages().Build();
		var response = await _collection
			.AggregateFluent()
			.Match(id)
			.Include(messageInclude)
			.ProjectToFullResponse(currentUser)
			.FirstOrDefaultAsync(cancellationToken);

		if (response != null)
		{
			await _messageCacheHandler.AddAsync(response, currentUser.Id, cancellationToken);
		}

		return response;
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
