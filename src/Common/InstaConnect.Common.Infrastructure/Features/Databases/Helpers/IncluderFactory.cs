namespace InstaConnect.Common.Infrastructure.Features.Databases.Helpers;

public abstract class IncluderFactory<TIncludeType, TDestinationType, TIncludeDescriptor, TIncluder, TEntity>
	: IIncluderFactory<TIncludeType, TDestinationType, TIncludeDescriptor, TIncluder, TEntity>
	where TIncludeType : Enum
	where TDestinationType : Enum
	where TIncluder : IIncluder<TEntity, TIncludeType, TDestinationType>
	where TIncludeDescriptor : IIncludeDescriptor<TDestinationType, TIncludeType>
{
	private readonly IEnumerable<TIncluder> _includers;

	protected IncluderFactory(IEnumerable<TIncluder> includers)
	{
		_includers = includers;
	}

	public IEnumerable<TIncluder> Create(ICollection<TIncludeDescriptor> descriptor)
	{
		return descriptor
			.Select(d => _includers.Single(includer =>
				includer.DestinationType.Equals(d.DestinationType) &&
				includer.IncludeType.Equals(d.IncludeType)));
	}
}
