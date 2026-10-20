namespace InstaConnect.Common.Infrastructure.Features.Databases.Helpers.SortOrders;

public class AscendingSortOrderer : ISortOrderer
{
	public CommonSortOrder SortOrder => CommonSortOrder.Ascending;

	public SortDefinition<TDocument> Sort<TDocument>(Expression<Func<TDocument, object>> sortTerm)
	{
		return Builders<TDocument>.Sort.Ascending(sortTerm);
	}
}
