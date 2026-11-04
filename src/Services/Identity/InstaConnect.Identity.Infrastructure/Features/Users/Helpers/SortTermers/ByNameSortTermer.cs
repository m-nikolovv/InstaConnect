namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.SortTermers;

internal class ByNameSortTermer : IUsersSortTermer
{
	public UsersSortTerm SortTerm => UsersSortTerm.ByName;

	public Expression<Func<User, object>> Term => p => p.Name.Value;
}
