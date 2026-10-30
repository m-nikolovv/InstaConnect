using InstaConnect.Common.Domain.Features.Mappers.Extensions;
using InstaConnect.Common.Domain.Features.Validations.Extensions;
using InstaConnect.Common.Infrastructure.Features.AccessTokens.Extensions;
using InstaConnect.Common.Infrastructure.Features.Caches.Extensions;
using InstaConnect.Common.Infrastructure.Features.Common.Extensions;
using InstaConnect.Common.Infrastructure.Features.DateTimes.Extensions;
using InstaConnect.Common.Infrastructure.Features.Events.Extensions;
using InstaConnect.Common.Infrastructure.Features.Guids.Extensions;
using InstaConnect.Common.Infrastructure.Features.Hubs.Extensions;
using InstaConnect.Common.Infrastructure.Features.Jsons.Extensions;
using InstaConnect.Common.Infrastructure.Features.OutboxEvents.Extensions;
using InstaConnect.Common.Infrastructure.Features.Telemetries.Extensions;
using InstaConnect.Follows.Infrastructure.Features.Common.Utilities;
using InstaConnect.Follows.Infrastructure.Features.Follows.Extensions;
using InstaConnect.Follows.Infrastructure.Features.Users.Extensions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace InstaConnect.Follows.Infrastructure.Features.Common.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddInfrastructure(
			IConfiguration configuration,
			IWebHostEnvironment webHostEnvironment)
		{
			serviceCollection
				.AddUserServices()
				.AddFollowServices();

			serviceCollection
				.AddTelemetries(configuration, webHostEnvironment)
				.AddMappers(FollowsInfrastructureReference.Assembly)
				.AddValidations(FollowsInfrastructureReference.Assembly, CommonInfrastructureReference.Assembly)
				.AddServicesWithMatchingInterfacesExceptFluents(FollowsInfrastructureReference.Assembly)
				.AddDatabases(configuration)
				.AddEvents(configuration, riderConfigurator => riderConfigurator.MapFollowEventProducer(), (context, kafkaConfigurator, consumerOptions) => kafkaConfigurator.MapUserEventHandler(context, FollowsEventHandlerUtilities.Prefix, consumerOptions), FollowsInfrastructureReference.Assembly)
				.AddOutboxEvents()
				.AddAccessTokens(configuration)
				.AddCaches(configuration)
				.AddHubs(configuration)
				.AddJsons()
				.AddGuids()
				.AddDateTimes()
				.AddDatabaseSortOrders();

			return serviceCollection;
		}
	}
}
