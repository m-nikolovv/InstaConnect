using InstaConnect.Common.Domain.Features.Mappers.Extensions;
using InstaConnect.Common.Domain.Features.Validations.Extensions;
using InstaConnect.Common.Presentation.Features.Common.Extensions;
using InstaConnect.Common.Presentation.Features.Common.Models;
using InstaConnect.Common.Presentation.Features.Controllers.Extensions;
using InstaConnect.Common.Presentation.Features.Emails.Extensions;
using InstaConnect.Common.Presentation.Features.Exceptions.Extensions;
using InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.Identity.Presentation.Features.RefreshTokens.Extensions;
using InstaConnect.Identity.Presentation.Features.UserClaims.Extensions;
using InstaConnect.Identity.Presentation.Features.Users.Extensions;

namespace InstaConnect.Identity.Presentation.Features.Common.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddPresentation(IConfiguration configuration)
		{
			const string RootNamespace = "InstaConnect.Identity.Presentation";

			serviceCollection
				.AddUserServices()
				.AddUserClaimServices()
				.AddRefreshTokenServices()
				.AddForgotPasswordTokenServices()
				.AddEmailConfirmationTokenServices();

			serviceCollection
				.AddValidatedOptions<MainOptions>(MainOptions.SectionName)
				.AddServicesWithMatchingInterfaces(IdentityPresentationReference.Assembly)
				.AddApiControllers()
				.AddMappers(IdentityPresentationReference.Assembly, CommonPresentationReference.Assembly)
				.AddValidations(IdentityPresentationReference.Assembly, CommonPresentationReference.Assembly)
				.AddAuthorizationPolicies()
				.AddCorsPolicies(configuration)
				.AddRateLimiterPolicies()
				.AddEmailRenderers(IdentityPresentationReference.Assembly, RootNamespace)
				.AddExceptions();

			serviceCollection.AddEndpointsApiExplorer();

			return serviceCollection;
		}
	}
}
