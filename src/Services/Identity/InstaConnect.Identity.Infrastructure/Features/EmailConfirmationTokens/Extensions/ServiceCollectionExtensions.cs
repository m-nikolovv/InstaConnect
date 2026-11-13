using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Options;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Helpers.Repositories;
using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Models.Options;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		internal IServiceCollection AddEmailConfirmationTokenServices()
		{
			const string CollectionName = "email_confirmation_tokens";

			serviceCollection.AddValidatedOptions<EmailConfirmationTokenOptions>(EmailConfirmationTokenOptions.SectionName);

			serviceCollection.AddImplementationsOf<IEmailConfirmationTokenIncluder>(IdentityInfrastructureReference.Assembly);

			serviceCollection.AddValidatedOptions<EmailConfirmationTokenCacheOptions>(EmailConfirmationTokenCacheOptions.SectionName);

			serviceCollection.AddCollection<EmailConfirmationToken, EmailConfirmationTokenId>(CollectionName);

			serviceCollection.AddScoped<IEmailConfirmationTokenCommandRepository, EmailConfirmationTokenCommandRepository>()
							 .Decorate<IEmailConfirmationTokenCommandRepository, CachedEmailConfirmationTokenCommandRepository>();

			BsonClassMap.TryRegisterClassMap<EmailConfirmationToken>(cm =>
			{
				cm.MapIdMember(c => c.Id);

				cm.MapMember(c => c.Id);
				cm.MapDateTimeMember(c => c.ExpiresAtUtc);
				cm.MapDateTimeMember(c => c.CreatedAtUtc);

				cm.MapMemberWithoutSerialization(c => c.User);

				cm.MapCreator(c => new EmailConfirmationToken(
					c.Id,
					c.ExpiresAtUtc,
					c.CreatedAtUtc));

				cm.IgnoreExtraElements();
			});

			return serviceCollection;
		}
	}
}
