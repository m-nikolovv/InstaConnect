namespace InstaConnect.Common.Infrastructure.Features.Databases.Extensions;

public static class AggregateFluentExtensions
{
	extension<TEntity>(IAggregateFluent<TEntity> fluent)
		where TEntity : IEntity
	{
		public IAggregateFluent<TEntity> IncludeMany<TForeignEntity, TKey>(
			IMongoCollection<TForeignEntity> foreignCollection,
			Expression<Func<TEntity, TKey>> entityKey,
			Expression<Func<TForeignEntity, TKey>> foreignEntityKey,
			Expression<Func<TEntity, ICollection<TForeignEntity>>> destination)
			where TForeignEntity : IEntity
			where TKey : IEntityId
		{
			return fluent.Lookup(foreignCollection,
								 entityKey.Box(),
								 foreignEntityKey.Box(),
								 destination.Box());
		}

		public IAggregateFluent<TEntity> IncludeOne<TForeignEntity, TKey>(
			IMongoCollection<TForeignEntity> foreignCollection,
			Expression<Func<TEntity, TKey>> entityKey,
			Expression<Func<TForeignEntity, TKey>> foreignEntityKey,
			Expression<Func<TEntity, TForeignEntity>> destination)
			where TForeignEntity : IEntity
			where TKey : IEntityId
		{
			return fluent.Lookup(foreignCollection,
								 entityKey.Box(),
								 foreignEntityKey.Box(),
								 destination.Box())
						 .Unwind(destination.Box(), new AggregateUnwindOptions<TEntity>() { PreserveNullAndEmptyArrays = true });
		}
	}
}
