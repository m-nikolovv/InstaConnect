using InstaConnect.Follows.Infrastructure.Features.Common.Extensions;

using MongoDB.Bson.Serialization;

namespace InstaConnect.Follows.Infrastructure.Features.Users.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		internal IServiceCollection AddUserServices()
		{
			const string CollectionName = "users";

			serviceCollection.AddImplementationsOf<IUserIncluder>(FollowsInfrastructureReference.Assembly);

			serviceCollection.AddCollection<User>(CollectionName);

			BsonClassMap.TryRegisterClassMap<User>(cm =>
			{
				cm.MapIdMember(c => c.Id);

				cm.MapMember(c => c.Id);
				cm.MapMember(c => c.FirstName);
				cm.MapMember(c => c.LastName);
				cm.MapMember(c => c.Name);
				cm.MapMember(c => c.Email);
				cm.MapMember(c => c.ProfileImageUrl);
				cm.MapMember(c => c.CreatedAtUtc);
				cm.MapMember(c => c.UpdatedAtUtc);

				cm.MapMemberWithoutSerialization(c => c.FollowFollowers);
				cm.MapMemberWithoutSerialization(c => c.FollowFollowings);

				cm.MapCreator(c => new User(
					c.Id,
					c.FirstName,
					c.LastName,
					c.Email,
					c.Name,
					c.ProfileImageUrl,
					c.CreatedAtUtc,
					c.UpdatedAtUtc));
			});

			return serviceCollection;
		}
	}
}
