using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Options;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		internal IServiceCollection AddRefreshTokenServices()
		{
			const string CollectionName = "refresh_tokens";

			serviceCollection.AddValidatedOptions<RefreshTokenOptions>(RefreshTokenOptions.SectionName);

			serviceCollection.AddImplementationsOf<IRefreshTokenIncluder>(IdentityInfrastructureReference.Assembly);

			serviceCollection.AddCollection<RefreshToken>(CollectionName);

			BsonClassMap.TryRegisterClassMap<RefreshToken>(cm =>
			{
				cm.MapIdMember(c => c.Id);

				cm.MapMember(c => c.Id);
				cm.MapMember(c => c.ExpiresAtUtc);
				cm.MapMember(c => c.CreatedAtUtc);

				cm.MapMemberWithoutSerialization(c => c.User);

				cm.MapCreator(c => new RefreshToken(
					c.Id,
					c.ExpiresAtUtc,
					c.CreatedAtUtc));

				cm.SetIgnoreExtraElements(true);
			});

			return serviceCollection;
		}
	}
}
