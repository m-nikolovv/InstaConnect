using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Repositories;
using InstaConnect.Identity.Infrastructure.Features.Users.Models.Options;

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

			serviceCollection.AddValidatedOptions<UserCacheOptions>(UserCacheOptions.SectionName);

			serviceCollection.AddCollection<User, UserId>(CollectionName);

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
				cm.MapMember(c => c.PasswordHash);
				cm.MapMember(c => c.IsEmailConfirmed);
				cm.MapMember(c => c.ProfileImageUrl);
				cm.MapDateTimeMember(c => c.CreatedAtUtc);
				cm.MapDateTimeMember(c => c.UpdatedAtUtc);

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

				cm.IgnoreExtraElements();
			});

			return serviceCollection;
		}
	}
}
