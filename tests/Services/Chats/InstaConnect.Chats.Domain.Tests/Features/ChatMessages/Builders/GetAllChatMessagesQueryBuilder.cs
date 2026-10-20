namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Builders;

public class GetAllChatMessagesQueryBuilder
{
	private string _participantTwoId;
	private string _currentUserId;
	private int _page;
	private int _pageSize;
	private CommonSortOrder _sortOrder;
	private ChatMessagesSortTerm _sortTerm;

	public GetAllChatMessagesQueryBuilder(ChatMessage chatMessage)
	{
		_participantTwoId = chatMessage.Id.Id.ParticipantTwoId.Id;
		_currentUserId = chatMessage.Id.Id.ParticipantOneId.Id;
		_page = ChatMessageDataFaker.GetPage();
		_pageSize = ChatMessageDataFaker.GetPageSize();
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = ChatMessageDataFaker.GetSortTerm();
	}

	public GetAllChatMessagesQueryBuilder WithParticipantTwoId(UserId participantTwoId, IStringTransformer? transformer = null)
	{
		_participantTwoId = transformer.TryTransform(participantTwoId.Id);

		return this;
	}

	public GetAllChatMessagesQueryBuilder WithParticipantTwoId(IStringTransformer transformer)
	{
		_participantTwoId = transformer.Transform(_participantTwoId);

		return this;
	}

	public GetAllChatMessagesQueryBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetAllChatMessagesQueryBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetAllChatMessagesQueryBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public GetAllChatMessagesQueryBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public GetAllChatMessagesQueryBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public GetAllChatMessagesQueryBuilder WithSortTerm(IEnumTransformer<ChatMessagesSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public GetAllChatMessagesQuery Build()
	{
		return new(
			new(
				new(
					new(_currentUserId),
					new(_participantTwoId))),
			new(_sortOrder, _sortTerm),
			new(_page, _pageSize),
			new(
				new(_currentUserId)));
	}
}
