namespace InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

public interface ISortOrderer
{
	public CommonSortOrder SortOrder { get; }

	public SortDefinition<TDocument> Sort<TDocument>(Expression<Func<TDocument, object>> sortTerm);
}
