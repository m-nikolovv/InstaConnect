namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Builders;

public class GetAllChatMessagesQueryRequestBuilder
{
	private string _participantTwoId;
	private string _currentUserId;
	private int _page;
	private int _pageSize;
	private CommonSortOrder _sortOrder;
	private ChatMessagesSortTerm _sortTerm;

	public GetAllChatMessagesQueryRequestBuilder(ChatMessage chatMessage)
	{
		_participantTwoId = chatMessage.Id.Id.ParticipantTwoId.Id;
		_currentUserId = chatMessage.Id.Id.ParticipantOneId.Id;
		_page = ChatMessageDataFaker.GetPage();
		_pageSize = ChatMessageDataFaker.GetPageSize();
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = ChatMessageDataFaker.GetSortTerm();
	}

	public GetAllChatMessagesQueryRequestBuilder WithParticipantTwoId(UserId participantTwoId, IStringTransformer? transformer = null)
	{
		_participantTwoId = transformer.TryTransform(participantTwoId.Id);

		return this;
	}

	public GetAllChatMessagesQueryRequestBuilder WithParticipantTwoId(IStringTransformer transformer)
	{
		_participantTwoId = transformer.Transform(_participantTwoId);

		return this;
	}

	public GetAllChatMessagesQueryRequestBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetAllChatMessagesQueryRequestBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetAllChatMessagesQueryRequestBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public GetAllChatMessagesQueryRequestBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public GetAllChatMessagesQueryRequestBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public GetAllChatMessagesQueryRequestBuilder WithSortTerm(IEnumTransformer<ChatMessagesSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public GetAllChatMessagesQueryRequest Build()
	{
		return new(_participantTwoId, _currentUserId, _sortOrder, _sortTerm, _page, _pageSize);
	}
}
