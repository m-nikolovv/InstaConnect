using MongoDB.Bson.Serialization;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		internal IServiceCollection AddChatMessageImageServices()
		{
			const string CollectionName = "chat_message_images";

			serviceCollection.AddCollection<ChatMessageImage>(CollectionName);

			BsonClassMap.TryRegisterClassMap<ChatMessageImage>(cm =>
			{
				cm.MapIdMember(c => c.Id);

				cm.MapMember(c => c.Id);
				cm.MapMember(c => c.Url);
				cm.MapMember(c => c.CreatedAtUtc);

				cm.MapMemberWithoutSerialization(c => c.ChatMessage);

				cm.MapCreator(c => new ChatMessageImage(
					c.Id,
					c.Url,
					c.CreatedAtUtc));

				cm.SetIgnoreExtraElements(true);
			});

			return serviceCollection;
		}
	}
}
