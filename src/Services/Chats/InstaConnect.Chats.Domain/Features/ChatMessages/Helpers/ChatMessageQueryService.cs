using InstaConnect.Chats.Domain.Features.ChatMessages.Exceptions;
using InstaConnect.Chats.Domain.Features.Chats.Exceptions;

namespace InstaConnect.Chats.Domain.Features.ChatMessages.Helpers;

internal class ChatMessageQueryService : IChatMessageQueryService
{
	private readonly IChatQueryRepository _repository;
	private readonly IChatMessageQueryRepository _messageRepository;
	private readonly IChatMessageCollectionResponseFactory _messageCollectionResponseFactory;

	public ChatMessageQueryService(
		IChatQueryRepository repository,
		IChatMessageQueryRepository messageRepository,
		IChatMessageCollectionResponseFactory messageCollectionResponseFactory)
	{
		_repository = repository;
		_messageRepository = messageRepository;
		_messageCollectionResponseFactory = messageCollectionResponseFactory;
	}

	public async Task<ChatMessageCollectionResponse> GetAllAsync(GetAllChatMessagesQuery query, CancellationToken cancellationToken)
	{
		var chat = await _repository.GetByIdAsync(query.Filter.Id, query.CurrentUser, cancellationToken);

		if (chat == null)
		{
			throw new ChatNotFoundException(query.Filter.Id);
		}

		var chatMessages = await _messageRepository.GetAllAsync(
			query.Filter,
			query.Sorting,
			query.Pagination,
			query.CurrentUser,
			cancellationToken);

		var totalCount = await _messageRepository.GetTotalCountAsync(query.Filter, cancellationToken);

		return _messageCollectionResponseFactory.Create(chat, chatMessages, totalCount, query.Pagination);
	}

	public async Task<ChatMessageResponse> GetByIdAsync(GetChatMessageByIdQuery query, CancellationToken cancellationToken)
	{
		var chatNotExists = !await _repository.ExistsByIdAsync(query.Id.Id, cancellationToken);

		if (chatNotExists)
		{
			throw new ChatNotFoundException(query.Id.Id);
		}

		var chatMessage = await _messageRepository.GetByIdAsync(
			query.Id,
			query.CurrentUser,
			cancellationToken);

		if (chatMessage == null)
		{
			throw new ChatMessageNotFoundException(query.Id);
		}

		return chatMessage;
	}
}
