namespace InstaConnect.Follows.Infrastructure.Features.Users.Abstractions;

public interface IUserFluentFactory
{
	public IUserFluent Create(IAggregateFluent<User> fluent);
}
