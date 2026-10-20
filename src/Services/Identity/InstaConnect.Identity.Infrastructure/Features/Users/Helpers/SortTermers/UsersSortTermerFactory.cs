using InstaConnect.Identity.Domain.Features.Users.Exceptions;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.SortTermers;

internal class UsersSortTermerFactory : IUsersSortTermerFactory
{
	private readonly IEnumerable<IUsersSortTermer> _sortTermer;

	public UsersSortTermerFactory(IEnumerable<IUsersSortTermer> sortTermer)
	{
		_sortTermer = sortTermer;
	}

	public IUsersSortTermer Create(UsersSortTerm sortTerm)
	{
		var sortTermer = _sortTermer.FirstOrDefault(s => s.SortTerm == sortTerm);

		if (sortTermer == null)
		{
			throw new UsersSortTermNotSupportedException(sortTerm);
		}

		return sortTermer;
	}
}
