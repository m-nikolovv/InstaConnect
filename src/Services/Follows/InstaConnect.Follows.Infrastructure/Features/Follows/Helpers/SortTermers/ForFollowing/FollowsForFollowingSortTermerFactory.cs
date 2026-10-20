using InstaConnect.Follows.Domain.Features.Follows.Exceptions;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.SortTermers.ForFollowing;

internal class FollowsForFollowingSortTermerFactory : IFollowsForFollowingSortTermerFactory
{
	private readonly IEnumerable<IFollowsForFollowingSortTermer> _sortTermer;

	public FollowsForFollowingSortTermerFactory(IEnumerable<IFollowsForFollowingSortTermer> sortTermer)
	{
		_sortTermer = sortTermer;
	}

	public IFollowsForFollowingSortTermer Create(FollowsForFollowingSortTerm sortTerm)
	{
		var sortTermer = _sortTermer.FirstOrDefault(s => s.SortTerm == sortTerm);

		if (sortTermer == null)
		{
			throw new FollowsForFollowingSortTermNotSupportedException(sortTerm);
		}

		return sortTermer;
	}
}
