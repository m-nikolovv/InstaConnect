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

			serviceCollection.AddCollection(
				CollectionName,
				new CreateIndexModel<Chat>(Builders<Chat>.IndexKeys.Ascending(c => c.Id.ParticipantOneId.Id).Ascending(c => c.CreatedAtUtc)),
				new CreateIndexModel<Chat>(Builders<Chat>.IndexKeys.Ascending(c => c.Id.ParticipantTwoId.Id).Ascending(c => c.CreatedAtUtc)),
				new CreateIndexModel<Chat>(Builders<Chat>.IndexKeys.Ascending(c => c.Id.ParticipantOneId)),
				new CreateIndexModel<Chat>(Builders<Chat>.IndexKeys.Ascending(c => c.Id.ParticipantTwoId)));

			BsonClassMap.TryRegisterClassMap<Chat>(cm =>
			{
				cm.MapIdMember(c => c.Id);

				cm.MapMember(c => c.Id);
				cm.MapMember(c => c.CreatedAtUtc);

				cm.MapMemberWithoutSerialization(c => c.ParticipantOne);
				cm.MapMemberWithoutSerialization(c => c.ParticipantTwo);
				cm.MapMemberWithoutSerialization(c => c.ChatMessages);

				cm.MapCreator(c => new Chat(
					c.Id,
					c.CreatedAtUtc));

				cm.SetIgnoreExtraElements(true);
			});

			return serviceCollection;
		}
	}
}
