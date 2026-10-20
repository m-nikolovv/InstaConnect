using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Options;

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

			serviceCollection.AddCollection<ForgotPasswordToken>(CollectionName);

			BsonClassMap.TryRegisterClassMap<ForgotPasswordToken>(cm =>
			{
				cm.MapIdMember(c => c.Id);

				cm.MapMember(c => c.Id);
				cm.MapMember(c => c.ExpiresAtUtc);
				cm.MapMember(c => c.CreatedAtUtc);

				cm.MapMemberWithoutSerialization(c => c.User);

				cm.MapCreator(c => new ForgotPasswordToken(
					c.Id,
					c.ExpiresAtUtc,
					c.CreatedAtUtc));

				cm.SetIgnoreExtraElements(true);
			});

			return serviceCollection;
		}
	}
}
