using InstaConnect.Follows.Infrastructure.Features.Common.Extensions;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		internal IServiceCollection AddFollowServices()
		{
			const string CollectionName = "follows";

			serviceCollection.AddImplementationsOf<IFollowsSortTermer>(FollowsInfrastructureReference.Assembly);
			serviceCollection.AddImplementationsOf<IFollowsForFollowingSortTermer>(FollowsInfrastructureReference.Assembly);
			serviceCollection.AddImplementationsOf<IFollowIncluder>(FollowsInfrastructureReference.Assembly);

			serviceCollection.AddCollection<Follow>(CollectionName);

			BsonClassMap.TryRegisterClassMap<Follow>(cm =>
			{
				cm.MapIdMember(c => c.Id);

				cm.MapMember(c => c.Id);
				cm.MapMember(c => c.CreatedAtUtc);

				cm.MapMemberWithoutSerialization(c => c.Follower);
				cm.MapMemberWithoutSerialization(c => c.Following);

				cm.MapCreator(c => new Follow(
					c.Id,
					c.CreatedAtUtc));

				cm.SetIgnoreExtraElements(true);
			});

			return serviceCollection;
		}
	}
}
