namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		internal IServiceCollection AddUserClaimServices()
		{
			const string CollectionName = "user_claims";

			serviceCollection.AddImplementationsOf<IUserClaimsSortTermer>(IdentityInfrastructureReference.Assembly);
			serviceCollection.AddImplementationsOf<IUserClaimIncluder>(IdentityInfrastructureReference.Assembly);

			serviceCollection.AddCollection<UserClaim>(CollectionName);

			BsonClassMap.TryRegisterClassMap<UserClaim>(cm =>
			{
				cm.MapIdMember(c => c.Id);

				cm.MapMember(c => c.Id);
				cm.MapMember(c => c.CreatedAtUtc);

				cm.MapMemberWithoutSerialization(c => c.User);

				cm.MapCreator(c => new UserClaim(
					c.Id,
					c.CreatedAtUtc));

				cm.SetIgnoreExtraElements(true);
			});

			return serviceCollection;
		}
	}
}
