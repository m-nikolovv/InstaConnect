using InstaConnect.Chats.Infrastructure.Features.Common.Extensions;

namespace InstaConnect.Chats.Infrastructure.Features.Users.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		internal IServiceCollection AddUserServices()
		{
			const string CollectionName = "users";

			serviceCollection.AddImplementationsOf<IUserIncluder>(ChatsInfrastructureReference.Assembly);

			serviceCollection.AddCollection<User>(CollectionName);

			BsonClassMap.TryRegisterClassMap<User>(cm =>
			{
				cm.MapIdMember(c => c.Id);

				cm.MapMember(c => c.FirstName);
				cm.MapMember(c => c.LastName);
				cm.MapMember(c => c.Name);
				cm.MapMember(c => c.Email);
				cm.MapMember(c => c.ProfileImageUrl);
				cm.MapDateTimeMember(c => c.CreatedAtUtc);
				cm.MapDateTimeMember(c => c.UpdatedAtUtc);

				cm.MapMemberWithoutSerialization(c => c.Chats);
				cm.MapMemberWithoutSerialization(c => c.ChatMessages);

				cm.MapCreator(c => new User(
					c.Id,
					c.FirstName,
					c.LastName,
					c.Email,
					c.Name,
					c.ProfileImageUrl,
					c.CreatedAtUtc,
					c.UpdatedAtUtc));

				cm.IgnoreExtraElements();
			});

			return serviceCollection;
		}
	}
}
