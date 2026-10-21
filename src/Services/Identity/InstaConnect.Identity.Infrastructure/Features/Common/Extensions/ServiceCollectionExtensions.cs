using InstaConnect.Common.Domain.Features.Mappers.Extensions;
using InstaConnect.Common.Domain.Features.Validations.Extensions;
using InstaConnect.Common.Infrastructure.Features.AccessTokens.Extensions;
using InstaConnect.Common.Infrastructure.Features.Caches.Extensions;
using InstaConnect.Common.Infrastructure.Features.Common.Extensions;
using InstaConnect.Common.Infrastructure.Features.DateTimes.Extensions;
using InstaConnect.Common.Infrastructure.Features.Emails.Extensions;
using InstaConnect.Common.Infrastructure.Features.Events.Extensions;
using InstaConnect.Common.Infrastructure.Features.Guids.Extensions;
using InstaConnect.Common.Infrastructure.Features.Images.Extensions;
using InstaConnect.Common.Infrastructure.Features.Seeders.Extensions;
using InstaConnect.Common.Infrastructure.Features.Telemetries.Extensions;
using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Infrastructure.Features.Common.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.Common.Helpers;
using InstaConnect.Identity.Infrastructure.Features.Common.Models.Options;
using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.UserClaims.Extensions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace InstaConnect.Identity.Infrastructure.Features.Common.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddInfrastructure(
			IConfiguration configuration,
			IWebHostEnvironment webHostEnvironment)
		{
			serviceCollection.AddValidatedOptions<AdminOptions>(AdminOptions.SectionName);

			serviceCollection.AddSingleton<IPasswordHasher, PasswordHasher>();

			serviceCollection
				.AddUserServices()
				.AddUserClaimServices()
				.AddRefreshTokenServices()
				.AddForgotPasswordTokenServices()
				.AddEmailConfirmationTokenServices();

			serviceCollection
				.AddTelemetries(configuration, webHostEnvironment)
				.AddMappers(IdentityInfrastructureReference.Assembly)
				.AddValidations(IdentityInfrastructureReference.Assembly, CommonInfrastructureReference.Assembly)
				.AddEmailSenders(configuration)
				.AddServicesWithMatchingInterfacesExceptFluents(IdentityInfrastructureReference.Assembly)
				.AddCaches(configuration)
				.AddDatabases(configuration)
				.AddSeeders<IIdentityDatabaseSeeder>()
				.AddImages(configuration)
				.AddEvents(configuration, null, IdentityInfrastructureReference.Assembly)
				.AddAccessTokens(configuration)
				.AddGuids()
				.AddDateTimes()
				.AddDatabaseSortOrders();

			return serviceCollection;
		}
	}
}
