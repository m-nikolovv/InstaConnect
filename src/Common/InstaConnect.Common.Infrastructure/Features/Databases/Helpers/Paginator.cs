namespace InstaConnect.Common.Infrastructure.Features.Databases.Helpers;

public class Paginator : IPaginator
{
	public int GetOffset(int page, int pageSize)
	{
		return (page - 1) * pageSize;
	}

	public bool HasNextPage(int page, int pageSize, long totalCount)
	{
		return page * pageSize < totalCount;
	}

	public bool HasPreviousPage(int page)
	{
		return page > 1;
	}
}
