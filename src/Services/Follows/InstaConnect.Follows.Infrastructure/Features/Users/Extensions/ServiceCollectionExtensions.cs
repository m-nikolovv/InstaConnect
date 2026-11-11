using InstaConnect.Follows.Domain.Features.Users.Abstractions;
using InstaConnect.Follows.Infrastructure.Features.Common.Extensions;
using InstaConnect.Follows.Infrastructure.Features.Users.Helpers.Repositories;
using InstaConnect.Follows.Infrastructure.Features.Users.Models.Options;

namespace InstaConnect.Follows.Infrastructure.Features.Users.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		internal IServiceCollection AddUserServices()
		{
			const string CollectionName = "users";

			serviceCollection.AddImplementationsOf<IUserIncluder>(FollowsInfrastructureReference.Assembly);

			serviceCollection.AddValidatedOptions<UserCacheOptions>(UserCacheOptions.SectionName);
			serviceCollection.AddValidatedOptions<UserEventHandlerOptions>(UserEventHandlerOptions.SectionName);

			serviceCollection.AddCollection<User>(CollectionName);

			serviceCollection.AddScoped<IUserCommandRepository, UserCommandRepository>()
							 .Decorate<IUserCommandRepository, CachedUserCommandRepository>();

			serviceCollection.AddScoped<IUserQueryRepository, UserQueryRepository>()
							 .Decorate<IUserQueryRepository, CachedUserQueryRepository>();

			BsonClassMap.TryRegisterClassMap<User>(cm =>
			{
				cm.MapIdMember(c => c.Id);

				cm.MapMember(c => c.Id);
				cm.MapMember(c => c.FirstName);
				cm.MapMember(c => c.LastName);
				cm.MapMember(c => c.Name);
				cm.MapMember(c => c.Email);
				cm.MapMember(c => c.ProfileImageUrl);
				cm.MapDateTimeMember(c => c.CreatedAtUtc);
				cm.MapDateTimeMember(c => c.UpdatedAtUtc);

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

				cm.IgnoreExtraElements();
			});

			return serviceCollection;
		}
	}
}
