namespace InstaConnect.Common.Infrastructure.Features.Databases.Helpers;

internal class MongoDbFluentHandlerFactory : IMongoDbFluentHandlerFactory
{
	public IMongoDbFluentHandler<TEntity, TEntityId> Create<TEntity, TEntityId>(IAggregateFluent<TEntity> fluent)
		where TEntity : ICreatable, IEntityWithId<TEntityId>
		where TEntityId : IEntityId
	{
		return new MongoDbFluentHandler<TEntity, TEntityId>(fluent);
	}

	public IMongoDbResponseFluentHandler<TEntity> CreateResponse<TEntity>(IAggregateFluent<TEntity> fluent)
		where TEntity : ICreatable
	{
		return new MongoDbResponseFluentHandler<TEntity>(fluent);
	}
}
