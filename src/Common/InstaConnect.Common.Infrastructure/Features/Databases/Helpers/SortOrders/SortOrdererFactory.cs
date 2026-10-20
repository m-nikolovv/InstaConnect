using InstaConnect.Common.Domain.Features.Exceptions.Exceptions;

namespace InstaConnect.Common.Infrastructure.Features.Databases.Helpers.SortOrders;

internal class SortOrdererFactory : ISortOrdererFactory
{
	private readonly IEnumerable<ISortOrderer> _sortOrderers;

	public SortOrdererFactory(IEnumerable<ISortOrderer> sortOrders)
	{
		_sortOrderers = sortOrders;
	}

	public ISortOrderer Create(CommonSortOrder sortOrder)
	{
		var sortOrderers = _sortOrderers.FirstOrDefault(s => s.SortOrder == sortOrder);

		if (sortOrderers == null)
		{
			throw new SortOrderNotSupportedException(sortOrder);
		}

		return sortOrderers;
	}
}
