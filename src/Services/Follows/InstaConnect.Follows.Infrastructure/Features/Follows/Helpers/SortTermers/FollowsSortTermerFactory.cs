using InstaConnect.Follows.Domain.Features.Follows.Exceptions;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.SortTermers;

internal class FollowsSortTermerFactory : IFollowsSortTermerFactory
{
	private readonly IEnumerable<IFollowsSortTermer> _sortTermer;

	public FollowsSortTermerFactory(IEnumerable<IFollowsSortTermer> sortTermer)
	{
		_sortTermer = sortTermer;
	}

	public IFollowsSortTermer Create(FollowsSortTerm sortTerm)
	{
		var sortTermer = _sortTermer.FirstOrDefault(s => s.SortTerm == sortTerm);

		if (sortTermer == null)
		{
			throw new FollowsSortTermNotSupportedException(sortTerm);
		}

		return sortTermer;
	}
}
