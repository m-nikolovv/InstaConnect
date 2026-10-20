namespace InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;

public interface IUserResponseFluent : IMongoDbResponseFluent<UserResponse>
{
	public IUserResponseFluent ApplySorting(UsersSortingQuery query);
	public IUserResponseFluent ApplyPagination(UsersPaginationQuery query);
}
