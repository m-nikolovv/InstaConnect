namespace InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

public interface ISortOrdererFactory
{
	public ISortOrderer Create(CommonSortOrder sortOrder);
}
