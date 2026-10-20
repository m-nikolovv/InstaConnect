namespace InstaConnect.Chats.Domain.Tests.Features.Chats.Utilities;

public static class ChatDomainSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IChatCommandService GetChatCommandService()
		{
			return serviceProvider.GetRequiredService<IChatCommandService>();
		}

		public IChatQueryService GetChatQueryService()
		{
			return serviceProvider.GetRequiredService<IChatQueryService>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IChatCommandService GetChatCommandService()
		{
			return serviceScope.ServiceProvider.GetChatCommandService();
		}

		public IChatQueryService GetChatQueryService()
		{
			return serviceScope.ServiceProvider.GetChatQueryService();
		}
	}
}
