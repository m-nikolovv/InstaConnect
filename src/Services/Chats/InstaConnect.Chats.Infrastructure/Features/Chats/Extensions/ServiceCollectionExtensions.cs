using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Repositories;
using InstaConnect.Chats.Infrastructure.Features.Chats.Models.Options;
using InstaConnect.Chats.Infrastructure.Features.Common.Extensions;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		internal IServiceCollection AddChatServices()
		{
			const string CollectionName = "chats";

			serviceCollection.AddImplementationsOf<IChatsSortTermer>(ChatsInfrastructureReference.Assembly);
			serviceCollection.AddImplementationsOf<IChatIncluder>(ChatsInfrastructureReference.Assembly);

			serviceCollection.AddValidatedOptions<ChatCacheOptions>(ChatCacheOptions.SectionName);

			serviceCollection.AddCollection<Chat, ChatId>(CollectionName);

			serviceCollection.AddScoped<IChatCommandRepository, ChatCommandRepository>()
							 .Decorate<IChatCommandRepository, CachedChatCommandRepository>();

			serviceCollection.AddScoped<IChatQueryRepository, ChatQueryRepository>()
							 .Decorate<IChatQueryRepository, CachedChatQueryRepository>();

			BsonClassMap.TryRegisterClassMap<Chat>(cm =>
			{
				cm.MapIdMember(c => c.Id);

				cm.MapMember(c => c.Id);
				cm.MapDateTimeMember(c => c.CreatedAtUtc);

				cm.MapMemberWithoutSerialization(c => c.ParticipantOne);
				cm.MapMemberWithoutSerialization(c => c.ParticipantTwo);
				cm.MapMemberWithoutSerialization(c => c.ChatMessages);

				cm.MapCreator(c => new Chat(
					c.Id,
					c.CreatedAtUtc));

				cm.IgnoreExtraElements();
			});

			return serviceCollection;
		}
	}
}
