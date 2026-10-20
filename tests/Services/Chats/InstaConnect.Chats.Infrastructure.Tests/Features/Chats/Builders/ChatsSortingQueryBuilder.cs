using InstaConnect.Chats.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.Chats.Builders;

public class ChatsSortingQueryBuilder
{
	private CommonSortOrder _sortOrder;
	private ChatsSortTerm _sortTerm;

	public ChatsSortingQueryBuilder()
	{
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = ChatDataFaker.GetSortTerm();
	}

	public ChatsSortingQueryBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public ChatsSortingQueryBuilder WithSortTerm(IEnumTransformer<ChatsSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public ChatsSortingQuery Build()
	{
		return new(_sortOrder, _sortTerm);
	}
}
