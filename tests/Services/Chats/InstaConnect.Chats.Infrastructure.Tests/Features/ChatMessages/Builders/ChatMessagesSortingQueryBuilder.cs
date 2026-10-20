using InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Common.Domain.Features.Requests.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Base;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessages.Builders;

public class ChatMessagesSortingQueryBuilder
{
	private CommonSortOrder _sortOrder;
	private ChatMessagesSortTerm _sortTerm;

	public ChatMessagesSortingQueryBuilder()
	{
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = ChatMessageDataFaker.GetSortTerm();
	}

	public ChatMessagesSortingQueryBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public ChatMessagesSortingQueryBuilder WithSortTerm(IEnumTransformer<ChatMessagesSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public ChatMessagesSortingQuery Build()
	{
		return new(_sortOrder, _sortTerm);
	}
}
