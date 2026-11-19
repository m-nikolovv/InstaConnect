namespace InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;

public interface IUserResponseFluent : IMongoDbResponseFluent<UserResponse>
{
	public IUserResponseFluent Sort(UsersSortingQuery query);
	public IUserResponseFluent Paginate(UsersPaginationQuery query);
}
