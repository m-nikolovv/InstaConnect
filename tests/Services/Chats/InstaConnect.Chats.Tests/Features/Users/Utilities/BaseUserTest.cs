namespace InstaConnect.Chats.Tests.Features.Users.Utilities;

public abstract class BaseUserTest : BaseTest
{
	protected UserBuilderFactory UserBuilderFactory { get; }
	protected UserBuilder UserBuilder { get; }
	protected User User { get; }

	protected BaseUserTest()
	{
		UserBuilderFactory = new();
		UserBuilder = UserBuilderFactory.Create();
		User = UserBuilder.Build();
	}
}
