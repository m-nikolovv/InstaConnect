using InstaConnect.Identity.Domain.Features.UserClaims.Exceptions;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.SortTermers;

internal class UserClaimsSortTermerFactory : IUserClaimsSortTermerFactory
{
	private readonly IEnumerable<IUserClaimsSortTermer> _sortTermer;

	public UserClaimsSortTermerFactory(IEnumerable<IUserClaimsSortTermer> sortTermer)
	{
		_sortTermer = sortTermer;
	}

	public IUserClaimsSortTermer Create(UserClaimsSortTerm sortTerm)
	{
		var sortTermer = _sortTermer.FirstOrDefault(s => s.SortTerm == sortTerm);

		if (sortTermer == null)
		{
			throw new UserClaimsSortTermNotSupportedException(sortTerm);
		}

		return sortTermer;
	}
}
