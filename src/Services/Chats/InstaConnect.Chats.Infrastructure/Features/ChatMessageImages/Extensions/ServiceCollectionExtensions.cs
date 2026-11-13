using InstaConnect.Chats.Domain.Features.ChatMessageImages.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Helpers.Repositories;
using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Models.Options;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		internal IServiceCollection AddChatMessageImageServices()
		{
			const string CollectionName = "chat_message_images";

			serviceCollection.AddValidatedOptions<ChatMessageImageCacheOptions>(ChatMessageImageCacheOptions.SectionName);

			serviceCollection.AddCollection<ChatMessageImage, ChatMessageImageId>(CollectionName);

			serviceCollection.AddScoped<IChatMessageImageCommandRepository, ChatMessageImageCommandRepository>()
							 .Decorate<IChatMessageImageCommandRepository, CachedChatMessageImageCommandRepository>();

			BsonClassMap.TryRegisterClassMap<ChatMessageImage>(cm =>
			{
				cm.MapIdMember(c => c.Id);

				cm.MapMember(c => c.Id);
				cm.MapMember(c => c.Url);
				cm.MapDateTimeMember(c => c.CreatedAtUtc);

				cm.MapMemberWithoutSerialization(c => c.ChatMessage);

				cm.MapCreator(c => new ChatMessageImage(
					c.Id,
					c.Url,
					c.CreatedAtUtc));

				cm.IgnoreExtraElements();
			});

			return serviceCollection;
		}
	}
}
