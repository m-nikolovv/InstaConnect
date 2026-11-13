using System.Reflection;

using InstaConnect.Common.Application.Features.Databases.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Common.Extensions;
using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Common.Infrastructure.Features.Databases.Helpers.Conventions;
using InstaConnect.Common.Infrastructure.Features.Databases.Helpers.SortOrders;
using InstaConnect.Common.Infrastructure.Features.Databases.Models;

using MongoDB.Bson.Serialization.Conventions;

namespace InstaConnect.Common.Infrastructure.Features.Databases.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddCollection<TEntity, TEntityId>(string name)
			where TEntity : IEntity, IEntityWithId<TEntityId>
			where TEntityId : IEntityId
		{
			serviceCollection
				.AddScoped(sp => sp.GetRequiredService<IMongoDatabase>().GetCollection<TEntity>(name))
				.AddScoped<IMongoDbCollectionHandler<TEntity, TEntityId>, MongoDbCollectionHandler<TEntity, TEntityId>>();

			return serviceCollection;
		}

		public IServiceCollection AddDatabases(IConfiguration configuration, params Assembly[] assemblies)
		{
			const string ConventionName = "ApplicationConventionPack";

			serviceCollection.AddValidatedOptions<MongoOptions>(MongoOptions.SectionName);
			var options = configuration.GetOptions<MongoOptions>(MongoOptions.SectionName);

			serviceCollection.AddSingleton<IMongoClient>(_ =>
				new MongoClient(options.ConnectionString));

			serviceCollection.AddSingleton(sp =>
				sp.GetRequiredService<IMongoClient>()
				  .GetDatabase(options.Name));

			serviceCollection
				.AddScoped<IPaginator, Paginator>()
				.AddScoped<IUnitOfWork, UnitOfWork>()
				.AddScoped<ISessionHandler, SessionHandler>()
				.AddScoped<IMongoDbFluentHandlerFactory, MongoDbFluentHandlerFactory>();

			serviceCollection
				.AddScoped<ISortOrdererFactory, SortOrdererFactory>()
				.AddImplementationsOf<ISortOrderer>(CommonInfrastructureReference.Assembly);

			serviceCollection
				.AddScoped<IDatabaseInitializer, DatabaseInitializer>()
				.AddImplementationsOf<IMongoDbCollectionInitializer>(assemblies);

			serviceCollection
				.AddScoped<IDatabaseSeeder, DatabaseSeeder>()
				.AddImplementationsOf<IMongoDbCollectionSeeder>(assemblies);

			var conventionPack = new ConventionPack
			{
				new SnakeCaseElementNameConvention(),
				new IgnoreExtraElementsConvention(true)
			};

			ConventionRegistry.Register(ConventionName, conventionPack, t => true);

			serviceCollection.AddHealthChecks()
				 .AddMongoDb(sp => sp.GetRequiredService<IMongoClient>(),
							 _ => options.Name);

			return serviceCollection;
		}
	}
}
