using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Extensions;
using InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;
using InstaConnect.Chats.Infrastructure.Features.Common.Utilities;
using InstaConnect.Common.Domain.Features.Mappers.Extensions;
using InstaConnect.Common.Domain.Features.Validations.Extensions;
using InstaConnect.Common.Infrastructure.Features.AccessTokens.Extensions;
using InstaConnect.Common.Infrastructure.Features.Caches.Extensions;
using InstaConnect.Common.Infrastructure.Features.Common.Extensions;
using InstaConnect.Common.Infrastructure.Features.DateTimes.Extensions;
using InstaConnect.Common.Infrastructure.Features.Events.Extensions;
using InstaConnect.Common.Infrastructure.Features.Guids.Extensions;
using InstaConnect.Common.Infrastructure.Features.Hubs.Extensions;
using InstaConnect.Common.Infrastructure.Features.Images.Extensions;
using InstaConnect.Common.Infrastructure.Features.Jsons.Extensions;
using InstaConnect.Common.Infrastructure.Features.OutboxEvents.Extensions;
using InstaConnect.Common.Infrastructure.Features.Summarizers.Extensions;
using InstaConnect.Common.Infrastructure.Features.Telemetries.Extensions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace InstaConnect.Chats.Infrastructure.Features.Common.Extensions;

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
				.AddChatServices()
				.AddChatMessageServices()
				.AddChatMessageImageServices();

			serviceCollection
				.AddTelemetries(configuration, webHostEnvironment)
				.AddMappers(ChatsInfrastructureReference.Assembly, CommonInfrastructureReference.Assembly)
				.AddValidations(ChatsInfrastructureReference.Assembly, CommonInfrastructureReference.Assembly)
				.AddServicesWithMatchingInterfacesExceptFluents(ChatsInfrastructureReference.Assembly)
				.AddDatabases(configuration)
				.AddEvents(configuration, riderConfigurator => riderConfigurator.MapChatEventProducer(), (context, kafkaConfigurator, consumerOptions) => kafkaConfigurator.MapUserEventHandler(context, ChatsEventHandlerUtilities.Prefix, consumerOptions), ChatsInfrastructureReference.Assembly)
				.AddOutboxEvents()
				.AddAccessTokens(configuration)
				.AddCaches(configuration)
				.AddHubs(configuration)
				.AddImages(configuration)
				.AddSummarizers(configuration)
				.AddJsons()
				.AddGuids()
				.AddDateTimes()
				.AddDatabaseSortOrders();

			return serviceCollection;
		}
	}
}
