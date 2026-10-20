namespace InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;

public static class UserSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IUserCommandService GetUserCommandService()
		{
			return serviceProvider.GetRequiredService<IUserCommandService>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IUserCommandService GetUserCommandService()
		{
			return serviceScope.ServiceProvider.GetUserCommandService();
		}
	}
}
