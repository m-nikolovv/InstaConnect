namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageDomainSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IChatMessageCommandService GetChatMessageCommandService()
		{
			return serviceProvider.GetRequiredService<IChatMessageCommandService>();
		}

		public IChatMessageQueryService GetChatMessageQueryService()
		{
			return serviceProvider.GetRequiredService<IChatMessageQueryService>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IChatMessageCommandService GetChatMessageCommandService()
		{
			return serviceScope.ServiceProvider.GetChatMessageCommandService();
		}

		public IChatMessageQueryService GetChatMessageQueryService()
		{
			return serviceScope.ServiceProvider.GetChatMessageQueryService();
		}
	}
}
