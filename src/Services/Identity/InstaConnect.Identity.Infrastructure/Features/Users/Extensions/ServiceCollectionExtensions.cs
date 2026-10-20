namespace InstaConnect.Identity.Infrastructure.Features.Users.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		internal IServiceCollection AddUserServices()
		{
			const string CollectionName = "users";

			serviceCollection.AddImplementationsOf<IUsersSortTermer>(IdentityInfrastructureReference.Assembly);
			serviceCollection.AddImplementationsOf<IUserIncluder>(IdentityInfrastructureReference.Assembly);

			serviceCollection.AddCollection<User>(CollectionName);

			BsonClassMap.TryRegisterClassMap<User>(cm =>
			{
				cm.MapIdMember(c => c.Id);

				cm.MapMember(c => c.Id);
				cm.MapMember(c => c.FirstName);
				cm.MapMember(c => c.LastName);
				cm.MapMember(c => c.Name);
				cm.MapMember(c => c.Email);
				cm.MapMember(c => c.PasswordHash);
				cm.MapMember(c => c.IsEmailConfirmed);
				cm.MapMember(c => c.ProfileImageUrl);
				cm.MapMember(c => c.CreatedAtUtc);
				cm.MapMember(c => c.UpdatedAtUtc);

				cm.MapMemberWithoutSerialization(c => c.UserClaims);
				cm.MapMemberWithoutSerialization(c => c.RefreshTokens);
				cm.MapMemberWithoutSerialization(c => c.ForgotPasswordTokens);
				cm.MapMemberWithoutSerialization(c => c.EmailConfirmationTokens);

				cm.MapCreator(c => new User(
					c.Id,
					c.FirstName,
					c.LastName,
					c.Email,
					c.Name,
					c.PasswordHash,
					c.IsEmailConfirmed,
					c.ProfileImageUrl,
					c.CreatedAtUtc,
					c.UpdatedAtUtc));

				cm.SetIgnoreExtraElements(true);
			});

			return serviceCollection;
		}
	}
}
