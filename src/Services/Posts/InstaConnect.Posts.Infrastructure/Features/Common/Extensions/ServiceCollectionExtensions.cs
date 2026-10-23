using InstaConnect.Common.Domain.Features.Mappers.Extensions;
using InstaConnect.Common.Domain.Features.Validations.Extensions;
using InstaConnect.Common.Infrastructure.Features.AccessTokens.Extensions;
using InstaConnect.Common.Infrastructure.Features.Common.Extensions;
using InstaConnect.Common.Infrastructure.Features.DateTimes.Extensions;
using InstaConnect.Common.Infrastructure.Features.Events.Extensions;
using InstaConnect.Common.Infrastructure.Features.Guids.Extensions;
using InstaConnect.Common.Infrastructure.Features.Images.Extensions;
using InstaConnect.Common.Infrastructure.Features.Jsons.Extensions;
using InstaConnect.Common.Infrastructure.Features.OutboxEvents.Extensions;
using InstaConnect.Common.Infrastructure.Features.Summarizers.Extensions;
using InstaConnect.Common.Infrastructure.Features.Telemetries.Extensions;
using InstaConnect.Posts.Infrastructure.Features.Common.Utilities;
using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Extensions;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Infrastructure.Features.PostImages.Extensions;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace InstaConnect.Posts.Infrastructure.Features.Common.Extensions;

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
				.AddPostServices()
				.AddPostLikeServices()
				.AddPostImageServices()
				.AddPostCommentImageServices()
				.AddPostCommentServices()
				.AddPostCommentLikeServices();

			serviceCollection
				.AddTelemetries(configuration, webHostEnvironment)
				.AddMappers(PostsInfrastructureReference.Assembly, CommonInfrastructureReference.Assembly)
				.AddValidations(PostsInfrastructureReference.Assembly, CommonInfrastructureReference.Assembly)
				.AddServicesWithMatchingInterfacesExceptFluents(PostsInfrastructureReference.Assembly)
				.AddDatabases(configuration)
				.AddEvents(configuration, riderConfigurator => riderConfigurator.MapPostEventProducer().MapPostCommentEventProducer().MapPostLikeEventProducer().MapPostCommentLikeEventProducer(), (context, kafkaConfigurator, consumerOptions) => kafkaConfigurator.MapUserEventHandler(context, PostsEventHandlerUtilities.Prefix, consumerOptions), PostsInfrastructureReference.Assembly)
				.AddOutboxEvents()
				.AddAccessTokens(configuration)
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
