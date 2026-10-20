using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IChatMessageQueryRepository GetMessageQueryRepository()
		{
			return serviceProvider.GetRequiredService<IChatMessageQueryRepository>();
		}

		public IChatMessageCommandRepository GetMessageCommandRepository()
		{
			return serviceProvider.GetRequiredService<IChatMessageCommandRepository>();
		}

		public IChatMessageIncludeBuilderFactory GetMessageIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IChatMessageIncludeBuilderFactory>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IChatMessageQueryRepository GetMessageQueryRepository()
		{
			return serviceScope.ServiceProvider.GetMessageQueryRepository();
		}

		public IChatMessageCommandRepository GetMessageCommandRepository()
		{
			return serviceScope.ServiceProvider.GetMessageCommandRepository();
		}

		public IChatMessageIncludeBuilderFactory GetMessageIncludeBuilderFactory()
		{
			return serviceScope.ServiceProvider.GetMessageIncludeBuilderFactory();
		}

		public async Task<ChatMessage?> GetByIdAsync(
			ChatMessageId id,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetIncludeBuilderFactory().Create().WithParticipantOne().WithParticipantTwo().Build();
			var messageInclude = serviceScope.GetMessageIncludeBuilderFactory().Create().WithSender().WithChat(include).WithChatMessageImages().Build();

			return (await serviceScope.GetMessageCommandRepository().GetByIdAsync(id, messageInclude, cancellationToken)).SetSender().SetChat().SetChatMessageImages();
		}

		public async Task AddAsync(
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetMessageCommandRepository().AddAsync(chatMessage, cancellationToken);
		}

		public async Task AddRangeAsync(
			IEnumerable<ChatMessage> chatMessages,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetMessageCommandRepository().AddRangeAsync(chatMessages, cancellationToken);
		}

		public async Task UpdateAsync(
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetMessageCommandRepository().UpdateAsync(chatMessage, cancellationToken);
		}

		public async Task DeleteAsync(
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetMessageCommandRepository().DeleteAsync(chatMessage, cancellationToken);
		}
	}
}
