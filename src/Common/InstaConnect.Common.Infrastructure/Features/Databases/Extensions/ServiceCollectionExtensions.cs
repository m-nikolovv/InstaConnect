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
		public IServiceCollection AddCollection<TEntity>(string name)
			where TEntity : IEntity
		{
			serviceCollection.AddScoped(sp => sp.GetRequiredService<IMongoDatabase>().GetCollection<TEntity>(name));

			return serviceCollection;
		}

		public IServiceCollection AddDatabases(IConfiguration configuration)
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
				.AddScoped<ISessionHandler, SessionHandler>();

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

		public IServiceCollection AddDatabaseSortOrders()
		{
			serviceCollection.AddScoped<ISortOrdererFactory, SortOrdererFactory>()
							 .AddImplementationsOf<ISortOrderer>(CommonInfrastructureReference.Assembly);

			return serviceCollection;
		}

		public IServiceCollection AddServicesWithMatchingInterfacesExceptFluents(params Assembly[] assemblies)
		{
			Type[] fluentTypes = [typeof(MongoDbFluent<>), typeof(MongoDbResponseFluent<>)];

			return serviceCollection.AddServicesWithMatchingInterfaces(
				type => type.BaseType is not { IsGenericType: true } baseType ||
						!fluentTypes.Contains(baseType.GetGenericTypeDefinition()),
				assemblies);
		}
	}
}
