namespace InstaConnect.Follows.Infrastructure.Features.Users.Abstractions;

public interface IUserResponseFluentFactory
{
	public IUserResponseFluent Create(IAggregateFluent<UserResponse> fluent);
}
