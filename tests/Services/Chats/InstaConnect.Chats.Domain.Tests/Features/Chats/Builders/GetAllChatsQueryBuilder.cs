using InstaConnect.Common.Domain.Features.Requests.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Base;
using InstaConnect.Common.Tests.Features.DataAttributes.Ints.Base;

namespace InstaConnect.Chats.Domain.Tests.Features.Chats.Builders;

public class GetAllChatsQueryBuilder
{
	private string _participantTwoName;
	private string _currentUserId;
	private int _page;
	private int _pageSize;
	private CommonSortOrder _sortOrder;
	private ChatsSortTerm _sortTerm;

	public GetAllChatsQueryBuilder(Chat chat)
	{
		_participantTwoName = DataFaker.GetPrefixString(chat.ParticipantTwo!.Name.Value);
		_currentUserId = chat.Id.ParticipantOneId.Id;
		_page = ChatDataFaker.GetPage();
		_pageSize = ChatDataFaker.GetPageSize();
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = ChatDataFaker.GetSortTerm();
	}

	public GetAllChatsQueryBuilder WithParticipantTwoName(Name participantTwoName, IStringTransformer? transformer = null)
	{
		_participantTwoName = transformer.TryTransform(participantTwoName.Value);

		return this;
	}

	public GetAllChatsQueryBuilder WithParticipantTwoName(IStringTransformer transformer)
	{
		_participantTwoName = transformer.Transform(_participantTwoName);

		return this;
	}

	public GetAllChatsQueryBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetAllChatsQueryBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetAllChatsQueryBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public GetAllChatsQueryBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public GetAllChatsQueryBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public GetAllChatsQueryBuilder WithSortTerm(IEnumTransformer<ChatsSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public GetAllChatsQuery Build()
	{
		return new(
			new(
				new(_currentUserId),
				new(_participantTwoName)),
			new(_sortOrder, _sortTerm),
			new(_page, _pageSize),
			new(
				new(_currentUserId)));
	}
}
