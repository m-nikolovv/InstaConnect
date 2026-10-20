using InstaConnect.Common.Application.Features.Common.Extensions;
using InstaConnect.Common.Application.Features.Requests.Extensions;
using InstaConnect.Common.Domain.Features.Mappers.Extensions;
using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.Identity.Application.Features.RefreshTokens.Extensions;
using InstaConnect.Identity.Application.Features.UserClaims.Extensions;

namespace InstaConnect.Identity.Application.Features.Common.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddApplication()
		{
			serviceCollection
				.AddUserServices()
				.AddUserClaimServices()
				.AddRefreshTokenServices()
				.AddForgotPasswordTokenServices()
				.AddEmailConfirmationTokenServices();

			serviceCollection
				.AddValidations(IdentityApplicationReference.Assembly)
				.AddRequests(IdentityApplicationReference.Assembly)
				.AddMappers(IdentityApplicationReference.Assembly, CommonApplicationReference.Assembly);

			return serviceCollection;
		}
	}
}
