using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Options;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Helpers.Repositories;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Models.Options;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		internal IServiceCollection AddForgotPasswordTokenServices()
		{
			const string CollectionName = "forgot_password_tokens";

			serviceCollection.AddValidatedOptions<ForgotPasswordTokenOptions>(ForgotPasswordTokenOptions.SectionName);

			serviceCollection.AddImplementationsOf<IForgotPasswordTokenIncluder>(IdentityInfrastructureReference.Assembly);

			serviceCollection.AddValidatedOptions<ForgotPasswordTokenCacheOptions>(ForgotPasswordTokenCacheOptions.SectionName);

			serviceCollection.AddCollection<ForgotPasswordToken, ForgotPasswordTokenId>(CollectionName);

			serviceCollection.AddScoped<IForgotPasswordTokenCommandRepository, ForgotPasswordTokenCommandRepository>()
							 .Decorate<IForgotPasswordTokenCommandRepository, CachedForgotPasswordTokenCommandRepository>();

			BsonClassMap.TryRegisterClassMap<ForgotPasswordToken>(cm =>
			{
				cm.MapIdMember(c => c.Id);

				cm.MapMember(c => c.Id);
				cm.MapDateTimeMember(c => c.ExpiresAtUtc);
				cm.MapDateTimeMember(c => c.CreatedAtUtc);

				cm.MapMemberWithoutSerialization(c => c.User);

				cm.MapCreator(c => new ForgotPasswordToken(
					c.Id,
					c.ExpiresAtUtc,
					c.CreatedAtUtc));

				cm.IgnoreExtraElements();
			});

			return serviceCollection;
		}
	}
}
