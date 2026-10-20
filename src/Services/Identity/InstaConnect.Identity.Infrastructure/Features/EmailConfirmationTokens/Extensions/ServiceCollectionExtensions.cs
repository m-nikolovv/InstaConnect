using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Options;

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

			serviceCollection.AddCollection<EmailConfirmationToken>(CollectionName);

			BsonClassMap.TryRegisterClassMap<EmailConfirmationToken>(cm =>
			{
				cm.MapIdMember(c => c.Id);

				cm.MapMember(c => c.Id);
				cm.MapMember(c => c.ExpiresAtUtc);
				cm.MapMember(c => c.CreatedAtUtc);

				cm.MapMemberWithoutSerialization(c => c.User);

				cm.MapCreator(c => new EmailConfirmationToken(
					c.Id,
					c.ExpiresAtUtc,
					c.CreatedAtUtc));

				cm.SetIgnoreExtraElements(true);
			});

			return serviceCollection;
		}
	}
}
