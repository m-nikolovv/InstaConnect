namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Builders;

public class GetAllChatMessagesApiRequestBuilder
{
	private string _participantTwoId;
	private string _currentUserId;
	private int _page;
	private int _pageSize;
	private CommonSortOrder _sortOrder;
	private ChatMessagesSortTerm _sortTerm;

	public GetAllChatMessagesApiRequestBuilder(ChatMessage chatMessage)
	{
		_participantTwoId = chatMessage.Id.Id.ParticipantTwoId.Id;
		_currentUserId = chatMessage.Id.Id.ParticipantOneId.Id;
		_page = ChatMessageDataFaker.GetPage();
		_pageSize = ChatMessageDataFaker.GetPageSize();
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = ChatMessageDataFaker.GetSortTerm();
	}

	public GetAllChatMessagesApiRequestBuilder WithParticipantTwoId(UserId participantTwoId, IStringTransformer? transformer = null)
	{
		_participantTwoId = transformer.TryTransform(participantTwoId.Id);

		return this;
	}

	public GetAllChatMessagesApiRequestBuilder WithParticipantTwoId(IStringTransformer transformer)
	{
		_participantTwoId = transformer.Transform(_participantTwoId);

		return this;
	}

	public GetAllChatMessagesApiRequestBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetAllChatMessagesApiRequestBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetAllChatMessagesApiRequestBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public GetAllChatMessagesApiRequestBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public GetAllChatMessagesApiRequestBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public GetAllChatMessagesApiRequestBuilder WithSortTerm(IEnumTransformer<ChatMessagesSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public GetAllChatMessagesApiRequest Build()
	{
		return new(_currentUserId, _participantTwoId, _sortOrder, _sortTerm, _page, _pageSize);
	}
}
