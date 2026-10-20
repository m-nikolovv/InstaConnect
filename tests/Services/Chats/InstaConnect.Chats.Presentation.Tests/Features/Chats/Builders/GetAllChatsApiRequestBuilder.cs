using InstaConnect.Common.Domain.Features.ValueObjects.Models;

namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Builders;

public class GetAllChatsApiRequestBuilder
{
	private string _participantTwoName;
	private string _currentUserId;
	private int _page;
	private int _pageSize;
	private CommonSortOrder _sortOrder;
	private ChatsSortTerm _sortTerm;

	public GetAllChatsApiRequestBuilder(Chat chat)
	{
		_participantTwoName = DataFaker.GetPrefixString(chat.ParticipantTwo!.Name.Value);
		_currentUserId = chat.Id.ParticipantOneId.Id;
		_page = ChatDataFaker.GetPage();
		_pageSize = ChatDataFaker.GetPageSize();
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = ChatDataFaker.GetSortTerm();
	}

	public GetAllChatsApiRequestBuilder WithParticipantTwoName(Name participantTwoName, IStringTransformer? transformer = null)
	{
		_participantTwoName = transformer.TryTransform(participantTwoName.Value);

		return this;
	}

	public GetAllChatsApiRequestBuilder WithParticipantTwoName(IStringTransformer transformer)
	{
		_participantTwoName = transformer.Transform(_participantTwoName);

		return this;
	}

	public GetAllChatsApiRequestBuilder WithCurrentUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(userId.Id);

		return this;
	}

	public GetAllChatsApiRequestBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetAllChatsApiRequestBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public GetAllChatsApiRequestBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public GetAllChatsApiRequestBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public GetAllChatsApiRequestBuilder WithSortTerm(IEnumTransformer<ChatsSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public GetAllChatsApiRequest Build()
	{
		return new(_currentUserId, _participantTwoName, _sortOrder, _sortTerm, _page, _pageSize);
	}
}
