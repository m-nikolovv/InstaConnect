namespace InstaConnect.Chats.Infrastructure.Features.Users.Abstractions;

public interface IUserResponseFluentFactory
{
	public IUserResponseFluent Create(IAggregateFluent<UserResponse> fluent);
}
