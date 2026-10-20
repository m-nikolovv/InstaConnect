namespace InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

public interface IIncluder<TEntity, TIncludeType, TDestinationType>
	where TIncludeType : Enum
	where TDestinationType : Enum
{
	public TDestinationType DestinationType { get; }

	public TIncludeType IncludeType { get; }

	public IAggregateFluent<TEntity> Include(IAggregateFluent<TEntity> aggregate);
}
