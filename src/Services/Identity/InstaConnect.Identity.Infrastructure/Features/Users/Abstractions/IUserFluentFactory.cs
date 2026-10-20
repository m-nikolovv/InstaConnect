namespace InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;

public interface IUserFluentFactory
{
	public IUserFluent Create(IAggregateFluent<User> fluent);
}
