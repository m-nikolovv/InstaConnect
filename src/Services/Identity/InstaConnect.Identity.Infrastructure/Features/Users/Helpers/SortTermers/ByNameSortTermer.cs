namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.SortTermers;

internal class ByNameSortTermer : IUsersSortTermer
{
	public UsersSortTerm SortTerm => UsersSortTerm.ByName;

	public Expression<Func<UserResponse, object>> Term => p => p.Name.Value;
}
