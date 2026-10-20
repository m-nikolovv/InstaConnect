using InstaConnect.Common.Domain.Features.ValueObjects.Models;

namespace InstaConnect.Chats.Application.Tests.Features.Chats.Builders;

public class GetAllChatsQueryRequestBuilder
{
	private string _participantTwoName;
	private string _currentUserId;
	private int _page;
	private int _pageSize;
	private CommonSortOrder _sortOrder;
	private ChatsSortTerm _sortTerm;

	public GetAllChatsQueryRequestBuilder(Chat chat)
	{
		_participantTwoName = DataFaker.GetPrefixString(chat.ParticipantTwo!.Name.Value);
		_currentUserId = chat.Id.ParticipantOneId.Id;
		_page = ChatDataFaker.GetPage();
		_pageSize = ChatDataFaker.GetPageSize();
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = ChatDataFaker.GetSortTerm();
	}

	public GetAllChatsQueryRequestBuilder WithParticipantTwoName(Name participantTwoName, IStringTransformer? transformer = null)
	{
		_participantTwoName = transformer.TryTransform(participantTwoName.Value);

		return this;
	}

	public GetAllChatsQueryRequestBuilder WithParticipantTwoName(IStringTransformer transformer)
	{
		_participantTwoName = transformer.Transform(_participantTwoName);

		return this;
	}

	public GetAllChatsQueryRequestBuilder WithCurrentUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(userId.Id);

		return this;
	}

	public GetAllChatsQueryRequestBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetAllChatsQueryRequestBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public GetAllChatsQueryRequestBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public GetAllChatsQueryRequestBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public GetAllChatsQueryRequestBuilder WithSortTerm(IEnumTransformer<ChatsSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public GetAllChatsQueryRequest Build()
	{
		return new(_participantTwoName, _currentUserId, _sortOrder, _sortTerm, _page, _pageSize);
	}
}
