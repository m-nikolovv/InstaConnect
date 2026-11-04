namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.SortTermers;

internal class ByFirstNameSortTermer : IUsersSortTermer
{
	public UsersSortTerm SortTerm => UsersSortTerm.ByFirstName;

	public Expression<Func<User, object>> Term => p => p.FirstName;
}
